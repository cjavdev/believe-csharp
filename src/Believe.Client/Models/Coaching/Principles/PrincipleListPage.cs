using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Services.Coaching;

namespace Believe.Client.Models.Coaching.Principles;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IPrincipleService.List(PrincipleListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class PrincipleListPage(
    IPrincipleServiceWithRawResponse service,
    PrincipleListParams parameters,
    PrincipleListPageResponse response
) : IPage<CoachingPrinciple>
{
    /// <inheritdoc/>
    public IReadOnlyList<CoachingPrinciple> Items
    {
        get { return response.Data; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            if (this.Items.Count == 0)
            {
                return false;
            }
            var totalCount = response.Total;

            return this.Items.Count < totalCount;
        }
        catch (BelieveInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<CoachingPrinciple>> IPage<CoachingPrinciple>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<PrincipleListPage> Next(CancellationToken cancellationToken = default)
    {
        var currentOffset = parameters.Skip ?? 0;
        using var nextResponse = await service
            .List(parameters with { Skip = currentOffset + this.Items.Count }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not PrincipleListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}

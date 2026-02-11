using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Core;
using Believe.Exceptions;
using Believe.Services;

namespace Believe.Models.TeamMembers;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ITeamMemberService.ListCoaches(TeamMemberListCoachesParams, CancellationToken)"/> queries.
/// </summary>
public sealed class TeamMemberListCoachesPage(
    ITeamMemberServiceWithRawResponse service,
    TeamMemberListCoachesParams parameters,
    TeamMemberListCoachesPageResponse response
) : IPage<TeamMemberCoach>
{
    /// <inheritdoc/>
    public IReadOnlyList<TeamMemberCoach> Items
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
    async Task<IPage<TeamMemberCoach>> IPage<TeamMemberCoach>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<TeamMemberListCoachesPage> Next(CancellationToken cancellationToken = default)
    {
        var currentOffset = parameters.Skip ?? 0;
        using var nextResponse = await service
            .ListCoaches(
                parameters with
                {
                    Skip = currentOffset + this.Items.Count,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this.Items, ModelBase.ToStringSerializerOptions);

    public override bool Equals(object? obj)
    {
        if (obj is not TeamMemberListCoachesPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}

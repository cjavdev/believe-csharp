using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Services;

namespace Believe.Client.Models.TeamMembers;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ITeamMemberService.ListPlayers(TeamMemberListPlayersParams, CancellationToken)"/> queries.
/// </summary>
public sealed class TeamMemberListPlayersPage(
    ITeamMemberServiceWithRawResponse service,
    TeamMemberListPlayersParams parameters,
    TeamMemberListPlayersPageResponse response
) : IPage<TeamMemberPlayer>
{
    /// <inheritdoc/>
    public IReadOnlyList<TeamMemberPlayer> Items
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
    async Task<IPage<TeamMemberPlayer>> IPage<TeamMemberPlayer>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<TeamMemberListPlayersPage> Next(CancellationToken cancellationToken = default)
    {
        var currentOffset = parameters.Skip ?? 0;
        using var nextResponse = await service
            .ListPlayers(
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
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not TeamMemberListPlayersPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}

using System;
using Believe.Client.Core;
using Believe.Client.Models.TeamMembers;

namespace Believe.Client.Tests.Models.TeamMembers;

public class TeamMemberListCoachesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamMemberListCoachesParams
        {
            Limit = 10,
            Skip = 0,
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
        };

        long expectedLimit = 10;
        long expectedSkip = 0;
        ApiEnum<string, CoachSpecialty> expectedSpecialty = CoachSpecialty.HeadCoach;
        string expectedTeamID = "team_id";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedSpecialty, parameters.Specialty);
        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TeamMemberListCoachesParams
        {
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TeamMemberListCoachesParams
        {
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Skip = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TeamMemberListCoachesParams { Limit = 10, Skip = 0 };

        Assert.Null(parameters.Specialty);
        Assert.False(parameters.RawQueryData.ContainsKey("specialty"));
        Assert.Null(parameters.TeamID);
        Assert.False(parameters.RawQueryData.ContainsKey("team_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TeamMemberListCoachesParams
        {
            Limit = 10,
            Skip = 0,

            Specialty = null,
            TeamID = null,
        };

        Assert.Null(parameters.Specialty);
        Assert.True(parameters.RawQueryData.ContainsKey("specialty"));
        Assert.Null(parameters.TeamID);
        Assert.True(parameters.RawQueryData.ContainsKey("team_id"));
    }

    [Fact]
    public void Url_Works()
    {
        TeamMemberListCoachesParams parameters = new()
        {
            Limit = 10,
            Skip = 0,
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://believe.cjav.dev/team-members/coaches/?limit=10&skip=0&specialty=head_coach&team_id=team_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamMemberListCoachesParams
        {
            Limit = 10,
            Skip = 0,
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
        };

        TeamMemberListCoachesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

using System;
using Believe.Client.Core;
using Believe.Client.Models.Characters;

namespace Believe.Client.Tests.Models.Characters;

public class CharacterListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CharacterListParams
        {
            Limit = 10,
            MinOptimism = 0,
            Role = CharacterRole.Coach,
            Skip = 0,
            TeamID = "team_id",
        };

        long expectedLimit = 10;
        long expectedMinOptimism = 0;
        ApiEnum<string, CharacterRole> expectedRole = CharacterRole.Coach;
        long expectedSkip = 0;
        string expectedTeamID = "team_id";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMinOptimism, parameters.MinOptimism);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CharacterListParams
        {
            MinOptimism = 0,
            Role = CharacterRole.Coach,
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
        var parameters = new CharacterListParams
        {
            MinOptimism = 0,
            Role = CharacterRole.Coach,
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
        var parameters = new CharacterListParams { Limit = 10, Skip = 0 };

        Assert.Null(parameters.MinOptimism);
        Assert.False(parameters.RawQueryData.ContainsKey("min_optimism"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawQueryData.ContainsKey("role"));
        Assert.Null(parameters.TeamID);
        Assert.False(parameters.RawQueryData.ContainsKey("team_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CharacterListParams
        {
            Limit = 10,
            Skip = 0,

            MinOptimism = null,
            Role = null,
            TeamID = null,
        };

        Assert.Null(parameters.MinOptimism);
        Assert.True(parameters.RawQueryData.ContainsKey("min_optimism"));
        Assert.Null(parameters.Role);
        Assert.True(parameters.RawQueryData.ContainsKey("role"));
        Assert.Null(parameters.TeamID);
        Assert.True(parameters.RawQueryData.ContainsKey("team_id"));
    }

    [Fact]
    public void Url_Works()
    {
        CharacterListParams parameters = new()
        {
            Limit = 10,
            MinOptimism = 0,
            Role = CharacterRole.Coach,
            Skip = 0,
            TeamID = "team_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://believe.cjav.dev/characters?limit=10&min_optimism=0&role=coach&skip=0&team_id=team_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CharacterListParams
        {
            Limit = 10,
            MinOptimism = 0,
            Role = CharacterRole.Coach,
            Skip = 0,
            TeamID = "team_id",
        };

        CharacterListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

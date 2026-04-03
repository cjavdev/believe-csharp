using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class TeamUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new TeamUpdateParams
        {
            TeamID = "team_id",AnnualBudgetGbp = 0,AverageAttendance = 0,ContactEmail = "dev@stainless.com",CultureScore = 0,FoundedYear = 1800,IsActive = true,League = League.PremierLeague,Name = "x",Nickname = "nickname",PrimaryColor = "primary_color",RivalTeams =
            [
                "string"
            ],SecondaryColor = "secondary_color",Stadium = "stadium",StadiumLocation = new(

            )
            {
                Latitude = 51.4816,
                Longitude = -0.191,
            },Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues =
                [
                    "Family", "Resilience", "Joy"
                ],
                TeamMotto = "Football is life!",
            },Website = "https://example.com",WinPercentage = 0,
        };

        string expectedTeamID = "team_id";
        TeamUpdateParamsAnnualBudgetGbp expectedAnnualBudgetGbp = 0;
        double expectedAverageAttendance = 0;
        string expectedContactEmail = "dev@stainless.com";
        long expectedCultureScore = 0;
        long expectedFoundedYear = 1800;
        bool expectedIsActive = true;
        ApiEnum<string, League> expectedLeague = League.PremierLeague;
        string expectedName = "x";
        string expectedNickname = "nickname";
        string expectedPrimaryColor = "primary_color";
        List<string> expectedRivalTeams =
        [
            "string"
        ];
        string expectedSecondaryColor = "secondary_color";
        string expectedStadium = "stadium";
        GeoLocation expectedStadiumLocation = new()
        {
            Latitude = 51.4816,
            Longitude = -0.191,
        };
        TeamValues expectedValues = new()
        {
            PrimaryValue = "Believe",
            SecondaryValues =
            [
                "Family", "Resilience", "Joy"
            ],
            TeamMotto = "Football is life!",
        };
        string expectedWebsite = "https://example.com";
        double expectedWinPercentage = 0;

        Assert.Equal(expectedTeamID, parameters.TeamID);
        Assert.Equal(expectedAnnualBudgetGbp, parameters.AnnualBudgetGbp);
        Assert.Equal(expectedAverageAttendance, parameters.AverageAttendance);
        Assert.Equal(expectedContactEmail, parameters.ContactEmail);
        Assert.Equal(expectedCultureScore, parameters.CultureScore);
        Assert.Equal(expectedFoundedYear, parameters.FoundedYear);
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedLeague, parameters.League);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedNickname, parameters.Nickname);
        Assert.Equal(expectedPrimaryColor, parameters.PrimaryColor);
        Assert.NotNull(parameters.RivalTeams);
        Assert.Equal(expectedRivalTeams.Count, parameters.RivalTeams.Count);
        for (int i = 0; i < expectedRivalTeams.Count; i++)
        {
            Assert.Equal(expectedRivalTeams[i], parameters.RivalTeams[i]);
        }
        Assert.Equal(expectedSecondaryColor, parameters.SecondaryColor);
        Assert.Equal(expectedStadium, parameters.Stadium);
        Assert.Equal(expectedStadiumLocation, parameters.StadiumLocation);
        Assert.Equal(expectedValues, parameters.Values);
        Assert.Equal(expectedWebsite, parameters.Website);
        Assert.Equal(expectedWinPercentage, parameters.WinPercentage);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {


        var parameters = new TeamUpdateParams
        {
            TeamID = "team_id",
        };

        Assert.Null(parameters.AnnualBudgetGbp);
        Assert.False(parameters.RawBodyData.ContainsKey("annual_budget_gbp"));Assert.Null(parameters.AverageAttendance);
        Assert.False(parameters.RawBodyData.ContainsKey("average_attendance"));Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));Assert.Null(parameters.CultureScore);
        Assert.False(parameters.RawBodyData.ContainsKey("culture_score"));Assert.Null(parameters.FoundedYear);
        Assert.False(parameters.RawBodyData.ContainsKey("founded_year"));Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));Assert.Null(parameters.League);
        Assert.False(parameters.RawBodyData.ContainsKey("league"));Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));Assert.Null(parameters.Nickname);
        Assert.False(parameters.RawBodyData.ContainsKey("nickname"));Assert.Null(parameters.PrimaryColor);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_color"));Assert.Null(parameters.RivalTeams);
        Assert.False(parameters.RawBodyData.ContainsKey("rival_teams"));Assert.Null(parameters.SecondaryColor);
        Assert.False(parameters.RawBodyData.ContainsKey("secondary_color"));Assert.Null(parameters.Stadium);
        Assert.False(parameters.RawBodyData.ContainsKey("stadium"));Assert.Null(parameters.StadiumLocation);
        Assert.False(parameters.RawBodyData.ContainsKey("stadium_location"));Assert.Null(parameters.Values);
        Assert.False(parameters.RawBodyData.ContainsKey("values"));Assert.Null(parameters.Website);
        Assert.False(parameters.RawBodyData.ContainsKey("website"));Assert.Null(parameters.WinPercentage);
        Assert.False(parameters.RawBodyData.ContainsKey("win_percentage"));

    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {


        var parameters = new TeamUpdateParams
        {
            TeamID = "team_id",

            AnnualBudgetGbp = null,AverageAttendance = null,ContactEmail = null,CultureScore = null,FoundedYear = null,IsActive = null,League = null,Name = null,Nickname = null,PrimaryColor = null,RivalTeams = null,SecondaryColor = null,Stadium = null,StadiumLocation = null,Values = null,Website = null,WinPercentage = null,
        };

        Assert.Null(parameters.AnnualBudgetGbp);
        Assert.True(parameters.RawBodyData.ContainsKey("annual_budget_gbp"));Assert.Null(parameters.AverageAttendance);
        Assert.True(parameters.RawBodyData.ContainsKey("average_attendance"));Assert.Null(parameters.ContactEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("contact_email"));Assert.Null(parameters.CultureScore);
        Assert.True(parameters.RawBodyData.ContainsKey("culture_score"));Assert.Null(parameters.FoundedYear);
        Assert.True(parameters.RawBodyData.ContainsKey("founded_year"));Assert.Null(parameters.IsActive);
        Assert.True(parameters.RawBodyData.ContainsKey("is_active"));Assert.Null(parameters.League);
        Assert.True(parameters.RawBodyData.ContainsKey("league"));Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));Assert.Null(parameters.Nickname);
        Assert.True(parameters.RawBodyData.ContainsKey("nickname"));Assert.Null(parameters.PrimaryColor);
        Assert.True(parameters.RawBodyData.ContainsKey("primary_color"));Assert.Null(parameters.RivalTeams);
        Assert.True(parameters.RawBodyData.ContainsKey("rival_teams"));Assert.Null(parameters.SecondaryColor);
        Assert.True(parameters.RawBodyData.ContainsKey("secondary_color"));Assert.Null(parameters.Stadium);
        Assert.True(parameters.RawBodyData.ContainsKey("stadium"));Assert.Null(parameters.StadiumLocation);
        Assert.True(parameters.RawBodyData.ContainsKey("stadium_location"));Assert.Null(parameters.Values);
        Assert.True(parameters.RawBodyData.ContainsKey("values"));Assert.Null(parameters.Website);
        Assert.True(parameters.RawBodyData.ContainsKey("website"));Assert.Null(parameters.WinPercentage);
        Assert.True(parameters.RawBodyData.ContainsKey("win_percentage"));

    }

    [Fact]
    public void Url_Works()
    {
        TeamUpdateParams parameters = new() { TeamID = "team_id" };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/teams/team_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamUpdateParams
        {
            TeamID = "team_id",
            AnnualBudgetGbp = 0,
            AverageAttendance = 0,
            ContactEmail = "dev@stainless.com",
            CultureScore = 0,
            FoundedYear = 1800,
            IsActive = true,
            League = League.PremierLeague,
            Name = "x",
            Nickname = "nickname",
            PrimaryColor = "primary_color",
            RivalTeams =
            [
                "string"
            ],
            SecondaryColor = "secondary_color",
            Stadium = "stadium",
            StadiumLocation = new()
            {
                Latitude = 51.4816,
                Longitude = -0.191,
            },
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues =
                [
                    "Family", "Resilience", "Joy"
                ],
                TeamMotto = "Football is life!",
            },
            Website = "https://example.com",
            WinPercentage = 0,
        };

        TeamUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TeamUpdateParamsAnnualBudgetGbpTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TeamUpdateParamsAnnualBudgetGbp value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TeamUpdateParamsAnnualBudgetGbp value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TeamUpdateParamsAnnualBudgetGbp value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamUpdateParamsAnnualBudgetGbp>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TeamUpdateParamsAnnualBudgetGbp value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamUpdateParamsAnnualBudgetGbp>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
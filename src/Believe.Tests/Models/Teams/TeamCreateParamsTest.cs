using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class TeamCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamCreateParams
        {
            CultureScore = 70,
            FoundedYear = 1895,
            League = League.PremierLeague,
            Name = "West Ham United",
            Stadium = "London Stadium",
            Values = new()
            {
                PrimaryValue = "Pride",
                SecondaryValues = ["History", "Community", "Passion"],
                TeamMotto = "Forever Blowing Bubbles",
            },
            AnnualBudgetGbp = "150000000.00",
            AverageAttendance = 59988,
            ContactEmail = "info@westhamunited.co.uk",
            IsActive = true,
            Nickname = "The Hammers",
            PrimaryColor = "#7A263A",
            RivalTeams = ["afc-richmond", "tottenham"],
            SecondaryColor = "#1BB1E7",
            StadiumLocation = new() { Latitude = 51.5387, Longitude = -0.0166 },
            Website = "https://www.whufc.com",
            WinPercentage = 52.3,
        };

        long expectedCultureScore = 70;
        long expectedFoundedYear = 1895;
        ApiEnum<string, League> expectedLeague = League.PremierLeague;
        string expectedName = "West Ham United";
        string expectedStadium = "London Stadium";
        TeamValues expectedValues = new()
        {
            PrimaryValue = "Pride",
            SecondaryValues = ["History", "Community", "Passion"],
            TeamMotto = "Forever Blowing Bubbles",
        };
        AnnualBudgetGbp expectedAnnualBudgetGbp = "150000000.00";
        double expectedAverageAttendance = 59988;
        string expectedContactEmail = "info@westhamunited.co.uk";
        bool expectedIsActive = true;
        string expectedNickname = "The Hammers";
        string expectedPrimaryColor = "#7A263A";
        List<string> expectedRivalTeams = ["afc-richmond", "tottenham"];
        string expectedSecondaryColor = "#1BB1E7";
        GeoLocation expectedStadiumLocation = new() { Latitude = 51.5387, Longitude = -0.0166 };
        string expectedWebsite = "https://www.whufc.com";
        double expectedWinPercentage = 52.3;

        Assert.Equal(expectedCultureScore, parameters.CultureScore);
        Assert.Equal(expectedFoundedYear, parameters.FoundedYear);
        Assert.Equal(expectedLeague, parameters.League);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedStadium, parameters.Stadium);
        Assert.Equal(expectedValues, parameters.Values);
        Assert.Equal(expectedAnnualBudgetGbp, parameters.AnnualBudgetGbp);
        Assert.Equal(expectedAverageAttendance, parameters.AverageAttendance);
        Assert.Equal(expectedContactEmail, parameters.ContactEmail);
        Assert.Equal(expectedIsActive, parameters.IsActive);
        Assert.Equal(expectedNickname, parameters.Nickname);
        Assert.Equal(expectedPrimaryColor, parameters.PrimaryColor);
        Assert.NotNull(parameters.RivalTeams);
        Assert.Equal(expectedRivalTeams.Count, parameters.RivalTeams.Count);
        for (int i = 0; i < expectedRivalTeams.Count; i++)
        {
            Assert.Equal(expectedRivalTeams[i], parameters.RivalTeams[i]);
        }
        Assert.Equal(expectedSecondaryColor, parameters.SecondaryColor);
        Assert.Equal(expectedStadiumLocation, parameters.StadiumLocation);
        Assert.Equal(expectedWebsite, parameters.Website);
        Assert.Equal(expectedWinPercentage, parameters.WinPercentage);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TeamCreateParams
        {
            CultureScore = 70,
            FoundedYear = 1895,
            League = League.PremierLeague,
            Name = "West Ham United",
            Stadium = "London Stadium",
            Values = new()
            {
                PrimaryValue = "Pride",
                SecondaryValues = ["History", "Community", "Passion"],
                TeamMotto = "Forever Blowing Bubbles",
            },
            AnnualBudgetGbp = "150000000.00",
            AverageAttendance = 59988,
            ContactEmail = "info@westhamunited.co.uk",
            Nickname = "The Hammers",
            PrimaryColor = "#7A263A",
            SecondaryColor = "#1BB1E7",
            StadiumLocation = new() { Latitude = 51.5387, Longitude = -0.0166 },
            Website = "https://www.whufc.com",
            WinPercentage = 52.3,
        };

        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.RivalTeams);
        Assert.False(parameters.RawBodyData.ContainsKey("rival_teams"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TeamCreateParams
        {
            CultureScore = 70,
            FoundedYear = 1895,
            League = League.PremierLeague,
            Name = "West Ham United",
            Stadium = "London Stadium",
            Values = new()
            {
                PrimaryValue = "Pride",
                SecondaryValues = ["History", "Community", "Passion"],
                TeamMotto = "Forever Blowing Bubbles",
            },
            AnnualBudgetGbp = "150000000.00",
            AverageAttendance = 59988,
            ContactEmail = "info@westhamunited.co.uk",
            Nickname = "The Hammers",
            PrimaryColor = "#7A263A",
            SecondaryColor = "#1BB1E7",
            StadiumLocation = new() { Latitude = 51.5387, Longitude = -0.0166 },
            Website = "https://www.whufc.com",
            WinPercentage = 52.3,

            // Null should be interpreted as omitted for these properties
            IsActive = null,
            RivalTeams = null,
        };

        Assert.Null(parameters.IsActive);
        Assert.False(parameters.RawBodyData.ContainsKey("is_active"));
        Assert.Null(parameters.RivalTeams);
        Assert.False(parameters.RawBodyData.ContainsKey("rival_teams"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TeamCreateParams
        {
            CultureScore = 70,
            FoundedYear = 1895,
            League = League.PremierLeague,
            Name = "West Ham United",
            Stadium = "London Stadium",
            Values = new()
            {
                PrimaryValue = "Pride",
                SecondaryValues = ["History", "Community", "Passion"],
                TeamMotto = "Forever Blowing Bubbles",
            },
            IsActive = true,
            RivalTeams = ["afc-richmond", "tottenham"],
        };

        Assert.Null(parameters.AnnualBudgetGbp);
        Assert.False(parameters.RawBodyData.ContainsKey("annual_budget_gbp"));
        Assert.Null(parameters.AverageAttendance);
        Assert.False(parameters.RawBodyData.ContainsKey("average_attendance"));
        Assert.Null(parameters.ContactEmail);
        Assert.False(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.Nickname);
        Assert.False(parameters.RawBodyData.ContainsKey("nickname"));
        Assert.Null(parameters.PrimaryColor);
        Assert.False(parameters.RawBodyData.ContainsKey("primary_color"));
        Assert.Null(parameters.SecondaryColor);
        Assert.False(parameters.RawBodyData.ContainsKey("secondary_color"));
        Assert.Null(parameters.StadiumLocation);
        Assert.False(parameters.RawBodyData.ContainsKey("stadium_location"));
        Assert.Null(parameters.Website);
        Assert.False(parameters.RawBodyData.ContainsKey("website"));
        Assert.Null(parameters.WinPercentage);
        Assert.False(parameters.RawBodyData.ContainsKey("win_percentage"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TeamCreateParams
        {
            CultureScore = 70,
            FoundedYear = 1895,
            League = League.PremierLeague,
            Name = "West Ham United",
            Stadium = "London Stadium",
            Values = new()
            {
                PrimaryValue = "Pride",
                SecondaryValues = ["History", "Community", "Passion"],
                TeamMotto = "Forever Blowing Bubbles",
            },
            IsActive = true,
            RivalTeams = ["afc-richmond", "tottenham"],

            AnnualBudgetGbp = null,
            AverageAttendance = null,
            ContactEmail = null,
            Nickname = null,
            PrimaryColor = null,
            SecondaryColor = null,
            StadiumLocation = null,
            Website = null,
            WinPercentage = null,
        };

        Assert.Null(parameters.AnnualBudgetGbp);
        Assert.True(parameters.RawBodyData.ContainsKey("annual_budget_gbp"));
        Assert.Null(parameters.AverageAttendance);
        Assert.True(parameters.RawBodyData.ContainsKey("average_attendance"));
        Assert.Null(parameters.ContactEmail);
        Assert.True(parameters.RawBodyData.ContainsKey("contact_email"));
        Assert.Null(parameters.Nickname);
        Assert.True(parameters.RawBodyData.ContainsKey("nickname"));
        Assert.Null(parameters.PrimaryColor);
        Assert.True(parameters.RawBodyData.ContainsKey("primary_color"));
        Assert.Null(parameters.SecondaryColor);
        Assert.True(parameters.RawBodyData.ContainsKey("secondary_color"));
        Assert.Null(parameters.StadiumLocation);
        Assert.True(parameters.RawBodyData.ContainsKey("stadium_location"));
        Assert.Null(parameters.Website);
        Assert.True(parameters.RawBodyData.ContainsKey("website"));
        Assert.Null(parameters.WinPercentage);
        Assert.True(parameters.RawBodyData.ContainsKey("win_percentage"));
    }

    [Fact]
    public void Url_Works()
    {
        TeamCreateParams parameters = new()
        {
            CultureScore = 70,
            FoundedYear = 1895,
            League = League.PremierLeague,
            Name = "West Ham United",
            Stadium = "London Stadium",
            Values = new()
            {
                PrimaryValue = "Pride",
                SecondaryValues = ["History", "Community", "Passion"],
                TeamMotto = "Forever Blowing Bubbles",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/teams"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamCreateParams
        {
            CultureScore = 70,
            FoundedYear = 1895,
            League = League.PremierLeague,
            Name = "West Ham United",
            Stadium = "London Stadium",
            Values = new()
            {
                PrimaryValue = "Pride",
                SecondaryValues = ["History", "Community", "Passion"],
                TeamMotto = "Forever Blowing Bubbles",
            },
            AnnualBudgetGbp = "150000000.00",
            AverageAttendance = 59988,
            ContactEmail = "info@westhamunited.co.uk",
            IsActive = true,
            Nickname = "The Hammers",
            PrimaryColor = "#7A263A",
            RivalTeams = ["afc-richmond", "tottenham"],
            SecondaryColor = "#1BB1E7",
            StadiumLocation = new() { Latitude = 51.5387, Longitude = -0.0166 },
            Website = "https://www.whufc.com",
            WinPercentage = 52.3,
        };

        TeamCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AnnualBudgetGbpTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        AnnualBudgetGbp value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        AnnualBudgetGbp value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        AnnualBudgetGbp value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnnualBudgetGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        AnnualBudgetGbp value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AnnualBudgetGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

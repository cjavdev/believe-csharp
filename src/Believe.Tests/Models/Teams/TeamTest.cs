using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Teams;

namespace Believe.Tests.Models.Teams;

public class TeamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            IsActive = true,
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            RivalTeams = ["west-ham", "rupert-fc"],
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,
        };

        string expectedID = "afc-richmond";
        long expectedCultureScore = 85;
        long expectedFoundedYear = 1897;
        ApiEnum<string, League> expectedLeague = League.PremierLeague;
        string expectedName = "AFC Richmond";
        string expectedStadium = "Nelson Road";
        TeamValues expectedValues = new()
        {
            PrimaryValue = "Believe",
            SecondaryValues = ["Family", "Resilience", "Joy"],
            TeamMotto = "Football is life!",
        };
        string expectedAnnualBudgetGbp = "50000000.00";
        double expectedAverageAttendance = 24500.5;
        string expectedContactEmail = "info@afcrichmond.com";
        bool expectedIsActive = true;
        string expectedNickname = "The Greyhounds";
        string expectedPrimaryColor = "#0033A0";
        List<string> expectedRivalTeams = ["west-ham", "rupert-fc"];
        string expectedSecondaryColor = "#FFFFFF";
        GeoLocation expectedStadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 };
        string expectedWebsite = "https://www.afcrichmond.com";
        double expectedWinPercentage = 45.5;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCultureScore, model.CultureScore);
        Assert.Equal(expectedFoundedYear, model.FoundedYear);
        Assert.Equal(expectedLeague, model.League);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedStadium, model.Stadium);
        Assert.Equal(expectedValues, model.Values);
        Assert.Equal(expectedAnnualBudgetGbp, model.AnnualBudgetGbp);
        Assert.Equal(expectedAverageAttendance, model.AverageAttendance);
        Assert.Equal(expectedContactEmail, model.ContactEmail);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedNickname, model.Nickname);
        Assert.Equal(expectedPrimaryColor, model.PrimaryColor);
        Assert.NotNull(model.RivalTeams);
        Assert.Equal(expectedRivalTeams.Count, model.RivalTeams.Count);
        for (int i = 0; i < expectedRivalTeams.Count; i++)
        {
            Assert.Equal(expectedRivalTeams[i], model.RivalTeams[i]);
        }
        Assert.Equal(expectedSecondaryColor, model.SecondaryColor);
        Assert.Equal(expectedStadiumLocation, model.StadiumLocation);
        Assert.Equal(expectedWebsite, model.Website);
        Assert.Equal(expectedWinPercentage, model.WinPercentage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            IsActive = true,
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            RivalTeams = ["west-ham", "rupert-fc"],
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Team>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            IsActive = true,
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            RivalTeams = ["west-ham", "rupert-fc"],
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Team>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "afc-richmond";
        long expectedCultureScore = 85;
        long expectedFoundedYear = 1897;
        ApiEnum<string, League> expectedLeague = League.PremierLeague;
        string expectedName = "AFC Richmond";
        string expectedStadium = "Nelson Road";
        TeamValues expectedValues = new()
        {
            PrimaryValue = "Believe",
            SecondaryValues = ["Family", "Resilience", "Joy"],
            TeamMotto = "Football is life!",
        };
        string expectedAnnualBudgetGbp = "50000000.00";
        double expectedAverageAttendance = 24500.5;
        string expectedContactEmail = "info@afcrichmond.com";
        bool expectedIsActive = true;
        string expectedNickname = "The Greyhounds";
        string expectedPrimaryColor = "#0033A0";
        List<string> expectedRivalTeams = ["west-ham", "rupert-fc"];
        string expectedSecondaryColor = "#FFFFFF";
        GeoLocation expectedStadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 };
        string expectedWebsite = "https://www.afcrichmond.com";
        double expectedWinPercentage = 45.5;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCultureScore, deserialized.CultureScore);
        Assert.Equal(expectedFoundedYear, deserialized.FoundedYear);
        Assert.Equal(expectedLeague, deserialized.League);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedStadium, deserialized.Stadium);
        Assert.Equal(expectedValues, deserialized.Values);
        Assert.Equal(expectedAnnualBudgetGbp, deserialized.AnnualBudgetGbp);
        Assert.Equal(expectedAverageAttendance, deserialized.AverageAttendance);
        Assert.Equal(expectedContactEmail, deserialized.ContactEmail);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedNickname, deserialized.Nickname);
        Assert.Equal(expectedPrimaryColor, deserialized.PrimaryColor);
        Assert.NotNull(deserialized.RivalTeams);
        Assert.Equal(expectedRivalTeams.Count, deserialized.RivalTeams.Count);
        for (int i = 0; i < expectedRivalTeams.Count; i++)
        {
            Assert.Equal(expectedRivalTeams[i], deserialized.RivalTeams[i]);
        }
        Assert.Equal(expectedSecondaryColor, deserialized.SecondaryColor);
        Assert.Equal(expectedStadiumLocation, deserialized.StadiumLocation);
        Assert.Equal(expectedWebsite, deserialized.Website);
        Assert.Equal(expectedWinPercentage, deserialized.WinPercentage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            IsActive = true,
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            RivalTeams = ["west-ham", "rupert-fc"],
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,
        };

        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.RivalTeams);
        Assert.False(model.RawData.ContainsKey("rival_teams"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,

            // Null should be interpreted as omitted for these properties
            IsActive = null,
            RivalTeams = null,
        };

        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.RivalTeams);
        Assert.False(model.RawData.ContainsKey("rival_teams"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,

            // Null should be interpreted as omitted for these properties
            IsActive = null,
            RivalTeams = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            IsActive = true,
            RivalTeams = ["west-ham", "rupert-fc"],
        };

        Assert.Null(model.AnnualBudgetGbp);
        Assert.False(model.RawData.ContainsKey("annual_budget_gbp"));
        Assert.Null(model.AverageAttendance);
        Assert.False(model.RawData.ContainsKey("average_attendance"));
        Assert.Null(model.ContactEmail);
        Assert.False(model.RawData.ContainsKey("contact_email"));
        Assert.Null(model.Nickname);
        Assert.False(model.RawData.ContainsKey("nickname"));
        Assert.Null(model.PrimaryColor);
        Assert.False(model.RawData.ContainsKey("primary_color"));
        Assert.Null(model.SecondaryColor);
        Assert.False(model.RawData.ContainsKey("secondary_color"));
        Assert.Null(model.StadiumLocation);
        Assert.False(model.RawData.ContainsKey("stadium_location"));
        Assert.Null(model.Website);
        Assert.False(model.RawData.ContainsKey("website"));
        Assert.Null(model.WinPercentage);
        Assert.False(model.RawData.ContainsKey("win_percentage"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            IsActive = true,
            RivalTeams = ["west-ham", "rupert-fc"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            IsActive = true,
            RivalTeams = ["west-ham", "rupert-fc"],

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

        Assert.Null(model.AnnualBudgetGbp);
        Assert.True(model.RawData.ContainsKey("annual_budget_gbp"));
        Assert.Null(model.AverageAttendance);
        Assert.True(model.RawData.ContainsKey("average_attendance"));
        Assert.Null(model.ContactEmail);
        Assert.True(model.RawData.ContainsKey("contact_email"));
        Assert.Null(model.Nickname);
        Assert.True(model.RawData.ContainsKey("nickname"));
        Assert.Null(model.PrimaryColor);
        Assert.True(model.RawData.ContainsKey("primary_color"));
        Assert.Null(model.SecondaryColor);
        Assert.True(model.RawData.ContainsKey("secondary_color"));
        Assert.Null(model.StadiumLocation);
        Assert.True(model.RawData.ContainsKey("stadium_location"));
        Assert.Null(model.Website);
        Assert.True(model.RawData.ContainsKey("website"));
        Assert.Null(model.WinPercentage);
        Assert.True(model.RawData.ContainsKey("win_percentage"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            IsActive = true,
            RivalTeams = ["west-ham", "rupert-fc"],

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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Team
        {
            ID = "afc-richmond",
            CultureScore = 85,
            FoundedYear = 1897,
            League = League.PremierLeague,
            Name = "AFC Richmond",
            Stadium = "Nelson Road",
            Values = new()
            {
                PrimaryValue = "Believe",
                SecondaryValues = ["Family", "Resilience", "Joy"],
                TeamMotto = "Football is life!",
            },
            AnnualBudgetGbp = "50000000.00",
            AverageAttendance = 24500.5,
            ContactEmail = "info@afcrichmond.com",
            IsActive = true,
            Nickname = "The Greyhounds",
            PrimaryColor = "#0033A0",
            RivalTeams = ["west-ham", "rupert-fc"],
            SecondaryColor = "#FFFFFF",
            StadiumLocation = new() { Latitude = 51.4816, Longitude = -0.191 },
            Website = "https://www.afcrichmond.com",
            WinPercentage = 45.5,
        };

        Team copied = new(model);

        Assert.Equal(model, copied);
    }
}

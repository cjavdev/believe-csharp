using System.Collections.Generic;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Teams;

namespace Believe.Client.Tests.Models.Teams;

public class TeamListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        List<Team> expectedData =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPages, model.Pages);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Team> expectedData =
        [
            new()
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
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPages, deserialized.Pages);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        TeamListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

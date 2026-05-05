using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Matches;

namespace Believe.Client.Tests.Models.Matches;

public class MatchListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatchListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "match-001",
                    AwayTeamID = "manchester-city",
                    Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
                    HomeTeamID = "afc-richmond",
                    MatchType = MatchType.League,
                    Attendance = 24500,
                    AwayScore = 2,
                    EpisodeID = "s01e10",
                    HomeScore = 2,
                    LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
                    PossessionPercentage = 52.3,
                    Result = MatchResult.Draw,
                    TedHalftimeSpeech =
                        "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
                    TicketRevenueGbp = "735000.00",
                    TurningPoints =
                    [
                        new()
                        {
                            Description = "Jamie Tartt passes to Sam instead of shooting",
                            EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                            Minute = 89,
                            CharacterInvolved = "jamie-tartt",
                        },
                    ],
                    WeatherTempCelsius = 14.5,
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        List<Match> expectedData =
        [
            new()
            {
                ID = "match-001",
                AwayTeamID = "manchester-city",
                Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
                HomeTeamID = "afc-richmond",
                MatchType = MatchType.League,
                Attendance = 24500,
                AwayScore = 2,
                EpisodeID = "s01e10",
                HomeScore = 2,
                LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
                PossessionPercentage = 52.3,
                Result = MatchResult.Draw,
                TedHalftimeSpeech =
                    "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
                TicketRevenueGbp = "735000.00",
                TurningPoints =
                [
                    new()
                    {
                        Description = "Jamie Tartt passes to Sam instead of shooting",
                        EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                        Minute = 89,
                        CharacterInvolved = "jamie-tartt",
                    },
                ],
                WeatherTempCelsius = 14.5,
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
        var model = new MatchListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "match-001",
                    AwayTeamID = "manchester-city",
                    Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
                    HomeTeamID = "afc-richmond",
                    MatchType = MatchType.League,
                    Attendance = 24500,
                    AwayScore = 2,
                    EpisodeID = "s01e10",
                    HomeScore = 2,
                    LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
                    PossessionPercentage = 52.3,
                    Result = MatchResult.Draw,
                    TedHalftimeSpeech =
                        "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
                    TicketRevenueGbp = "735000.00",
                    TurningPoints =
                    [
                        new()
                        {
                            Description = "Jamie Tartt passes to Sam instead of shooting",
                            EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                            Minute = 89,
                            CharacterInvolved = "jamie-tartt",
                        },
                    ],
                    WeatherTempCelsius = 14.5,
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
        var deserialized = JsonSerializer.Deserialize<MatchListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatchListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "match-001",
                    AwayTeamID = "manchester-city",
                    Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
                    HomeTeamID = "afc-richmond",
                    MatchType = MatchType.League,
                    Attendance = 24500,
                    AwayScore = 2,
                    EpisodeID = "s01e10",
                    HomeScore = 2,
                    LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
                    PossessionPercentage = 52.3,
                    Result = MatchResult.Draw,
                    TedHalftimeSpeech =
                        "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
                    TicketRevenueGbp = "735000.00",
                    TurningPoints =
                    [
                        new()
                        {
                            Description = "Jamie Tartt passes to Sam instead of shooting",
                            EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                            Minute = 89,
                            CharacterInvolved = "jamie-tartt",
                        },
                    ],
                    WeatherTempCelsius = 14.5,
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
        var deserialized = JsonSerializer.Deserialize<MatchListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Match> expectedData =
        [
            new()
            {
                ID = "match-001",
                AwayTeamID = "manchester-city",
                Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
                HomeTeamID = "afc-richmond",
                MatchType = MatchType.League,
                Attendance = 24500,
                AwayScore = 2,
                EpisodeID = "s01e10",
                HomeScore = 2,
                LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
                PossessionPercentage = 52.3,
                Result = MatchResult.Draw,
                TedHalftimeSpeech =
                    "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
                TicketRevenueGbp = "735000.00",
                TurningPoints =
                [
                    new()
                    {
                        Description = "Jamie Tartt passes to Sam instead of shooting",
                        EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                        Minute = 89,
                        CharacterInvolved = "jamie-tartt",
                    },
                ],
                WeatherTempCelsius = 14.5,
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
        var model = new MatchListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "match-001",
                    AwayTeamID = "manchester-city",
                    Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
                    HomeTeamID = "afc-richmond",
                    MatchType = MatchType.League,
                    Attendance = 24500,
                    AwayScore = 2,
                    EpisodeID = "s01e10",
                    HomeScore = 2,
                    LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
                    PossessionPercentage = 52.3,
                    Result = MatchResult.Draw,
                    TedHalftimeSpeech =
                        "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
                    TicketRevenueGbp = "735000.00",
                    TurningPoints =
                    [
                        new()
                        {
                            Description = "Jamie Tartt passes to Sam instead of shooting",
                            EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                            Minute = 89,
                            CharacterInvolved = "jamie-tartt",
                        },
                    ],
                    WeatherTempCelsius = 14.5,
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
        var model = new MatchListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "match-001",
                    AwayTeamID = "manchester-city",
                    Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
                    HomeTeamID = "afc-richmond",
                    MatchType = MatchType.League,
                    Attendance = 24500,
                    AwayScore = 2,
                    EpisodeID = "s01e10",
                    HomeScore = 2,
                    LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
                    PossessionPercentage = 52.3,
                    Result = MatchResult.Draw,
                    TedHalftimeSpeech =
                        "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
                    TicketRevenueGbp = "735000.00",
                    TurningPoints =
                    [
                        new()
                        {
                            Description = "Jamie Tartt passes to Sam instead of shooting",
                            EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                            Minute = 89,
                            CharacterInvolved = "jamie-tartt",
                        },
                    ],
                    WeatherTempCelsius = 14.5,
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        MatchListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

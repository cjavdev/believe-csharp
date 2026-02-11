using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Match
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
        };

        string expectedID = "match-001";
        string expectedAwayTeamID = "manchester-city";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2024-01-15T15:00:00Z");
        string expectedHomeTeamID = "afc-richmond";
        ApiEnum<string, MatchType> expectedMatchType = MatchType.League;
        long expectedAttendance = 24500;
        long expectedAwayScore = 2;
        string expectedEpisodeID = "s01e10";
        long expectedHomeScore = 2;
        string expectedLessonLearned =
            "Sometimes a tie feels like a win when you've grown as people.";
        double expectedPossessionPercentage = 52.3;
        ApiEnum<string, MatchResult> expectedResult = MatchResult.Draw;
        string expectedTedHalftimeSpeech =
            "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.";
        string expectedTicketRevenueGbp = "735000.00";
        List<TurningPoint> expectedTurningPoints =
        [
            new()
            {
                Description = "Jamie Tartt passes to Sam instead of shooting",
                EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                Minute = 89,
                CharacterInvolved = "jamie-tartt",
            },
        ];
        double expectedWeatherTempCelsius = 14.5;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAwayTeamID, model.AwayTeamID);
        Assert.Equal(expectedDate, model.Date);
        Assert.Equal(expectedHomeTeamID, model.HomeTeamID);
        Assert.Equal(expectedMatchType, model.MatchType);
        Assert.Equal(expectedAttendance, model.Attendance);
        Assert.Equal(expectedAwayScore, model.AwayScore);
        Assert.Equal(expectedEpisodeID, model.EpisodeID);
        Assert.Equal(expectedHomeScore, model.HomeScore);
        Assert.Equal(expectedLessonLearned, model.LessonLearned);
        Assert.Equal(expectedPossessionPercentage, model.PossessionPercentage);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedTedHalftimeSpeech, model.TedHalftimeSpeech);
        Assert.Equal(expectedTicketRevenueGbp, model.TicketRevenueGbp);
        Assert.NotNull(model.TurningPoints);
        Assert.Equal(expectedTurningPoints.Count, model.TurningPoints.Count);
        for (int i = 0; i < expectedTurningPoints.Count; i++)
        {
            Assert.Equal(expectedTurningPoints[i], model.TurningPoints[i]);
        }
        Assert.Equal(expectedWeatherTempCelsius, model.WeatherTempCelsius);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Match
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Match>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Match
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Match>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "match-001";
        string expectedAwayTeamID = "manchester-city";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2024-01-15T15:00:00Z");
        string expectedHomeTeamID = "afc-richmond";
        ApiEnum<string, MatchType> expectedMatchType = MatchType.League;
        long expectedAttendance = 24500;
        long expectedAwayScore = 2;
        string expectedEpisodeID = "s01e10";
        long expectedHomeScore = 2;
        string expectedLessonLearned =
            "Sometimes a tie feels like a win when you've grown as people.";
        double expectedPossessionPercentage = 52.3;
        ApiEnum<string, MatchResult> expectedResult = MatchResult.Draw;
        string expectedTedHalftimeSpeech =
            "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.";
        string expectedTicketRevenueGbp = "735000.00";
        List<TurningPoint> expectedTurningPoints =
        [
            new()
            {
                Description = "Jamie Tartt passes to Sam instead of shooting",
                EmotionalImpact = "Showed Jamie's growth from selfish to team player",
                Minute = 89,
                CharacterInvolved = "jamie-tartt",
            },
        ];
        double expectedWeatherTempCelsius = 14.5;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAwayTeamID, deserialized.AwayTeamID);
        Assert.Equal(expectedDate, deserialized.Date);
        Assert.Equal(expectedHomeTeamID, deserialized.HomeTeamID);
        Assert.Equal(expectedMatchType, deserialized.MatchType);
        Assert.Equal(expectedAttendance, deserialized.Attendance);
        Assert.Equal(expectedAwayScore, deserialized.AwayScore);
        Assert.Equal(expectedEpisodeID, deserialized.EpisodeID);
        Assert.Equal(expectedHomeScore, deserialized.HomeScore);
        Assert.Equal(expectedLessonLearned, deserialized.LessonLearned);
        Assert.Equal(expectedPossessionPercentage, deserialized.PossessionPercentage);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedTedHalftimeSpeech, deserialized.TedHalftimeSpeech);
        Assert.Equal(expectedTicketRevenueGbp, deserialized.TicketRevenueGbp);
        Assert.NotNull(deserialized.TurningPoints);
        Assert.Equal(expectedTurningPoints.Count, deserialized.TurningPoints.Count);
        for (int i = 0; i < expectedTurningPoints.Count; i++)
        {
            Assert.Equal(expectedTurningPoints[i], deserialized.TurningPoints[i]);
        }
        Assert.Equal(expectedWeatherTempCelsius, deserialized.WeatherTempCelsius);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Match
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            Attendance = 24500,
            EpisodeID = "s01e10",
            LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
            PossessionPercentage = 52.3,
            TedHalftimeSpeech =
                "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
            TicketRevenueGbp = "735000.00",
            WeatherTempCelsius = 14.5,
        };

        Assert.Null(model.AwayScore);
        Assert.False(model.RawData.ContainsKey("away_score"));
        Assert.Null(model.HomeScore);
        Assert.False(model.RawData.ContainsKey("home_score"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.TurningPoints);
        Assert.False(model.RawData.ContainsKey("turning_points"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            Attendance = 24500,
            EpisodeID = "s01e10",
            LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
            PossessionPercentage = 52.3,
            TedHalftimeSpeech =
                "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
            TicketRevenueGbp = "735000.00",
            WeatherTempCelsius = 14.5,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            Attendance = 24500,
            EpisodeID = "s01e10",
            LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
            PossessionPercentage = 52.3,
            TedHalftimeSpeech =
                "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
            TicketRevenueGbp = "735000.00",
            WeatherTempCelsius = 14.5,

            // Null should be interpreted as omitted for these properties
            AwayScore = null,
            HomeScore = null,
            Result = null,
            TurningPoints = null,
        };

        Assert.Null(model.AwayScore);
        Assert.False(model.RawData.ContainsKey("away_score"));
        Assert.Null(model.HomeScore);
        Assert.False(model.RawData.ContainsKey("home_score"));
        Assert.Null(model.Result);
        Assert.False(model.RawData.ContainsKey("result"));
        Assert.Null(model.TurningPoints);
        Assert.False(model.RawData.ContainsKey("turning_points"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            Attendance = 24500,
            EpisodeID = "s01e10",
            LessonLearned = "Sometimes a tie feels like a win when you've grown as people.",
            PossessionPercentage = 52.3,
            TedHalftimeSpeech =
                "Guys, I want you to know, I don't care if we win or lose today. I just want you to go out there and play the best football of your lives.",
            TicketRevenueGbp = "735000.00",
            WeatherTempCelsius = 14.5,

            // Null should be interpreted as omitted for these properties
            AwayScore = null,
            HomeScore = null,
            Result = null,
            TurningPoints = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            AwayScore = 2,
            HomeScore = 2,
            Result = MatchResult.Draw,
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
        };

        Assert.Null(model.Attendance);
        Assert.False(model.RawData.ContainsKey("attendance"));
        Assert.Null(model.EpisodeID);
        Assert.False(model.RawData.ContainsKey("episode_id"));
        Assert.Null(model.LessonLearned);
        Assert.False(model.RawData.ContainsKey("lesson_learned"));
        Assert.Null(model.PossessionPercentage);
        Assert.False(model.RawData.ContainsKey("possession_percentage"));
        Assert.Null(model.TedHalftimeSpeech);
        Assert.False(model.RawData.ContainsKey("ted_halftime_speech"));
        Assert.Null(model.TicketRevenueGbp);
        Assert.False(model.RawData.ContainsKey("ticket_revenue_gbp"));
        Assert.Null(model.WeatherTempCelsius);
        Assert.False(model.RawData.ContainsKey("weather_temp_celsius"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            AwayScore = 2,
            HomeScore = 2,
            Result = MatchResult.Draw,
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            AwayScore = 2,
            HomeScore = 2,
            Result = MatchResult.Draw,
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

            Attendance = null,
            EpisodeID = null,
            LessonLearned = null,
            PossessionPercentage = null,
            TedHalftimeSpeech = null,
            TicketRevenueGbp = null,
            WeatherTempCelsius = null,
        };

        Assert.Null(model.Attendance);
        Assert.True(model.RawData.ContainsKey("attendance"));
        Assert.Null(model.EpisodeID);
        Assert.True(model.RawData.ContainsKey("episode_id"));
        Assert.Null(model.LessonLearned);
        Assert.True(model.RawData.ContainsKey("lesson_learned"));
        Assert.Null(model.PossessionPercentage);
        Assert.True(model.RawData.ContainsKey("possession_percentage"));
        Assert.Null(model.TedHalftimeSpeech);
        Assert.True(model.RawData.ContainsKey("ted_halftime_speech"));
        Assert.Null(model.TicketRevenueGbp);
        Assert.True(model.RawData.ContainsKey("ticket_revenue_gbp"));
        Assert.Null(model.WeatherTempCelsius);
        Assert.True(model.RawData.ContainsKey("weather_temp_celsius"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Match
        {
            ID = "match-001",
            AwayTeamID = "manchester-city",
            Date = DateTimeOffset.Parse("2024-01-15T15:00:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.League,
            AwayScore = 2,
            HomeScore = 2,
            Result = MatchResult.Draw,
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

            Attendance = null,
            EpisodeID = null,
            LessonLearned = null,
            PossessionPercentage = null,
            TedHalftimeSpeech = null,
            TicketRevenueGbp = null,
            WeatherTempCelsius = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Match
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
        };

        Match copied = new(model);

        Assert.Equal(model, copied);
    }
}

using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MatchUpdateParams
        {
            MatchID = "match_id",
            Attendance = 0,
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            Date = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EpisodeID = "episode_id",
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            LessonLearned = "lesson_learned",
            MatchType = MatchType.League,
            PossessionPercentage = 0,
            Result = MatchResult.Win,
            TedHalftimeSpeech = "ted_halftime_speech",
            TicketRevenueGbp = 0,
            TurningPoints =
            [
                new()
                {
                    Description = "description",
                    EmotionalImpact = "Galvanized the team's fighting spirit",
                    Minute = 0,
                    CharacterInvolved = "jamie-tartt",
                },
            ],
            WeatherTempCelsius = -30,
        };

        string expectedMatchID = "match_id";
        long expectedAttendance = 0;
        long expectedAwayScore = 0;
        string expectedAwayTeamID = "away_team_id";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEpisodeID = "episode_id";
        long expectedHomeScore = 0;
        string expectedHomeTeamID = "home_team_id";
        string expectedLessonLearned = "lesson_learned";
        ApiEnum<string, MatchType> expectedMatchType = MatchType.League;
        double expectedPossessionPercentage = 0;
        ApiEnum<string, MatchResult> expectedResult = MatchResult.Win;
        string expectedTedHalftimeSpeech = "ted_halftime_speech";
        MatchUpdateParamsTicketRevenueGbp expectedTicketRevenueGbp = 0;
        List<TurningPoint> expectedTurningPoints =
        [
            new()
            {
                Description = "description",
                EmotionalImpact = "Galvanized the team's fighting spirit",
                Minute = 0,
                CharacterInvolved = "jamie-tartt",
            },
        ];
        double expectedWeatherTempCelsius = -30;

        Assert.Equal(expectedMatchID, parameters.MatchID);
        Assert.Equal(expectedAttendance, parameters.Attendance);
        Assert.Equal(expectedAwayScore, parameters.AwayScore);
        Assert.Equal(expectedAwayTeamID, parameters.AwayTeamID);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedEpisodeID, parameters.EpisodeID);
        Assert.Equal(expectedHomeScore, parameters.HomeScore);
        Assert.Equal(expectedHomeTeamID, parameters.HomeTeamID);
        Assert.Equal(expectedLessonLearned, parameters.LessonLearned);
        Assert.Equal(expectedMatchType, parameters.MatchType);
        Assert.Equal(expectedPossessionPercentage, parameters.PossessionPercentage);
        Assert.Equal(expectedResult, parameters.Result);
        Assert.Equal(expectedTedHalftimeSpeech, parameters.TedHalftimeSpeech);
        Assert.Equal(expectedTicketRevenueGbp, parameters.TicketRevenueGbp);
        Assert.NotNull(parameters.TurningPoints);
        Assert.Equal(expectedTurningPoints.Count, parameters.TurningPoints.Count);
        for (int i = 0; i < expectedTurningPoints.Count; i++)
        {
            Assert.Equal(expectedTurningPoints[i], parameters.TurningPoints[i]);
        }
        Assert.Equal(expectedWeatherTempCelsius, parameters.WeatherTempCelsius);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MatchUpdateParams { MatchID = "match_id" };

        Assert.Null(parameters.Attendance);
        Assert.False(parameters.RawBodyData.ContainsKey("attendance"));
        Assert.Null(parameters.AwayScore);
        Assert.False(parameters.RawBodyData.ContainsKey("away_score"));
        Assert.Null(parameters.AwayTeamID);
        Assert.False(parameters.RawBodyData.ContainsKey("away_team_id"));
        Assert.Null(parameters.Date);
        Assert.False(parameters.RawBodyData.ContainsKey("date"));
        Assert.Null(parameters.EpisodeID);
        Assert.False(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.HomeScore);
        Assert.False(parameters.RawBodyData.ContainsKey("home_score"));
        Assert.Null(parameters.HomeTeamID);
        Assert.False(parameters.RawBodyData.ContainsKey("home_team_id"));
        Assert.Null(parameters.LessonLearned);
        Assert.False(parameters.RawBodyData.ContainsKey("lesson_learned"));
        Assert.Null(parameters.MatchType);
        Assert.False(parameters.RawBodyData.ContainsKey("match_type"));
        Assert.Null(parameters.PossessionPercentage);
        Assert.False(parameters.RawBodyData.ContainsKey("possession_percentage"));
        Assert.Null(parameters.Result);
        Assert.False(parameters.RawBodyData.ContainsKey("result"));
        Assert.Null(parameters.TedHalftimeSpeech);
        Assert.False(parameters.RawBodyData.ContainsKey("ted_halftime_speech"));
        Assert.Null(parameters.TicketRevenueGbp);
        Assert.False(parameters.RawBodyData.ContainsKey("ticket_revenue_gbp"));
        Assert.Null(parameters.TurningPoints);
        Assert.False(parameters.RawBodyData.ContainsKey("turning_points"));
        Assert.Null(parameters.WeatherTempCelsius);
        Assert.False(parameters.RawBodyData.ContainsKey("weather_temp_celsius"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MatchUpdateParams
        {
            MatchID = "match_id",

            Attendance = null,
            AwayScore = null,
            AwayTeamID = null,
            Date = null,
            EpisodeID = null,
            HomeScore = null,
            HomeTeamID = null,
            LessonLearned = null,
            MatchType = null,
            PossessionPercentage = null,
            Result = null,
            TedHalftimeSpeech = null,
            TicketRevenueGbp = null,
            TurningPoints = null,
            WeatherTempCelsius = null,
        };

        Assert.Null(parameters.Attendance);
        Assert.True(parameters.RawBodyData.ContainsKey("attendance"));
        Assert.Null(parameters.AwayScore);
        Assert.True(parameters.RawBodyData.ContainsKey("away_score"));
        Assert.Null(parameters.AwayTeamID);
        Assert.True(parameters.RawBodyData.ContainsKey("away_team_id"));
        Assert.Null(parameters.Date);
        Assert.True(parameters.RawBodyData.ContainsKey("date"));
        Assert.Null(parameters.EpisodeID);
        Assert.True(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.HomeScore);
        Assert.True(parameters.RawBodyData.ContainsKey("home_score"));
        Assert.Null(parameters.HomeTeamID);
        Assert.True(parameters.RawBodyData.ContainsKey("home_team_id"));
        Assert.Null(parameters.LessonLearned);
        Assert.True(parameters.RawBodyData.ContainsKey("lesson_learned"));
        Assert.Null(parameters.MatchType);
        Assert.True(parameters.RawBodyData.ContainsKey("match_type"));
        Assert.Null(parameters.PossessionPercentage);
        Assert.True(parameters.RawBodyData.ContainsKey("possession_percentage"));
        Assert.Null(parameters.Result);
        Assert.True(parameters.RawBodyData.ContainsKey("result"));
        Assert.Null(parameters.TedHalftimeSpeech);
        Assert.True(parameters.RawBodyData.ContainsKey("ted_halftime_speech"));
        Assert.Null(parameters.TicketRevenueGbp);
        Assert.True(parameters.RawBodyData.ContainsKey("ticket_revenue_gbp"));
        Assert.Null(parameters.TurningPoints);
        Assert.True(parameters.RawBodyData.ContainsKey("turning_points"));
        Assert.Null(parameters.WeatherTempCelsius);
        Assert.True(parameters.RawBodyData.ContainsKey("weather_temp_celsius"));
    }

    [Fact]
    public void Url_Works()
    {
        MatchUpdateParams parameters = new() { MatchID = "match_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/matches/match_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MatchUpdateParams
        {
            MatchID = "match_id",
            Attendance = 0,
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            Date = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EpisodeID = "episode_id",
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            LessonLearned = "lesson_learned",
            MatchType = MatchType.League,
            PossessionPercentage = 0,
            Result = MatchResult.Win,
            TedHalftimeSpeech = "ted_halftime_speech",
            TicketRevenueGbp = 0,
            TurningPoints =
            [
                new()
                {
                    Description = "description",
                    EmotionalImpact = "Galvanized the team's fighting spirit",
                    Minute = 0,
                    CharacterInvolved = "jamie-tartt",
                },
            ],
            WeatherTempCelsius = -30,
        };

        MatchUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MatchUpdateParamsTicketRevenueGbpTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        MatchUpdateParamsTicketRevenueGbp value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        MatchUpdateParamsTicketRevenueGbp value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        MatchUpdateParamsTicketRevenueGbp value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchUpdateParamsTicketRevenueGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MatchUpdateParamsTicketRevenueGbp value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchUpdateParamsTicketRevenueGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

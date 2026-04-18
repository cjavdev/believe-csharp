using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MatchCreateParams
        {
            AwayTeamID = "tottenham",
            Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.Cup,
            Attendance = 24500,
            AwayScore = 0,
            EpisodeID = "s02e05",
            HomeScore = 0,
            LessonLearned =
                "It's not about the wins and losses, it's about helping these young fellas be the best versions of themselves.",
            PossessionPercentage = 50,
            Result = MatchResult.Pending,
            TedHalftimeSpeech =
                "You know what the happiest animal on Earth is? It's a goldfish. You know why? It's got a 10-second memory.",
            TicketRevenueGbp = "735000.00",
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
            WeatherTempCelsius = 8.5,
        };

        string expectedAwayTeamID = "tottenham";
        DateTimeOffset expectedDate = DateTimeOffset.Parse("2024-02-20T19:45:00Z");
        string expectedHomeTeamID = "afc-richmond";
        ApiEnum<string, MatchType> expectedMatchType = MatchType.Cup;
        long expectedAttendance = 24500;
        long expectedAwayScore = 0;
        string expectedEpisodeID = "s02e05";
        long expectedHomeScore = 0;
        string expectedLessonLearned =
            "It's not about the wins and losses, it's about helping these young fellas be the best versions of themselves.";
        double expectedPossessionPercentage = 50;
        ApiEnum<string, MatchResult> expectedResult = MatchResult.Pending;
        string expectedTedHalftimeSpeech =
            "You know what the happiest animal on Earth is? It's a goldfish. You know why? It's got a 10-second memory.";
        TicketRevenueGbp expectedTicketRevenueGbp = "735000.00";
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
        double expectedWeatherTempCelsius = 8.5;

        Assert.Equal(expectedAwayTeamID, parameters.AwayTeamID);
        Assert.Equal(expectedDate, parameters.Date);
        Assert.Equal(expectedHomeTeamID, parameters.HomeTeamID);
        Assert.Equal(expectedMatchType, parameters.MatchType);
        Assert.Equal(expectedAttendance, parameters.Attendance);
        Assert.Equal(expectedAwayScore, parameters.AwayScore);
        Assert.Equal(expectedEpisodeID, parameters.EpisodeID);
        Assert.Equal(expectedHomeScore, parameters.HomeScore);
        Assert.Equal(expectedLessonLearned, parameters.LessonLearned);
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
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MatchCreateParams
        {
            AwayTeamID = "tottenham",
            Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.Cup,
            Attendance = 24500,
            EpisodeID = "s02e05",
            LessonLearned =
                "It's not about the wins and losses, it's about helping these young fellas be the best versions of themselves.",
            PossessionPercentage = 50,
            TedHalftimeSpeech =
                "You know what the happiest animal on Earth is? It's a goldfish. You know why? It's got a 10-second memory.",
            TicketRevenueGbp = "735000.00",
            WeatherTempCelsius = 8.5,
        };

        Assert.Null(parameters.AwayScore);
        Assert.False(parameters.RawBodyData.ContainsKey("away_score"));
        Assert.Null(parameters.HomeScore);
        Assert.False(parameters.RawBodyData.ContainsKey("home_score"));
        Assert.Null(parameters.Result);
        Assert.False(parameters.RawBodyData.ContainsKey("result"));
        Assert.Null(parameters.TurningPoints);
        Assert.False(parameters.RawBodyData.ContainsKey("turning_points"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MatchCreateParams
        {
            AwayTeamID = "tottenham",
            Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.Cup,
            Attendance = 24500,
            EpisodeID = "s02e05",
            LessonLearned =
                "It's not about the wins and losses, it's about helping these young fellas be the best versions of themselves.",
            PossessionPercentage = 50,
            TedHalftimeSpeech =
                "You know what the happiest animal on Earth is? It's a goldfish. You know why? It's got a 10-second memory.",
            TicketRevenueGbp = "735000.00",
            WeatherTempCelsius = 8.5,

            // Null should be interpreted as omitted for these properties
            AwayScore = null,
            HomeScore = null,
            Result = null,
            TurningPoints = null,
        };

        Assert.Null(parameters.AwayScore);
        Assert.False(parameters.RawBodyData.ContainsKey("away_score"));
        Assert.Null(parameters.HomeScore);
        Assert.False(parameters.RawBodyData.ContainsKey("home_score"));
        Assert.Null(parameters.Result);
        Assert.False(parameters.RawBodyData.ContainsKey("result"));
        Assert.Null(parameters.TurningPoints);
        Assert.False(parameters.RawBodyData.ContainsKey("turning_points"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MatchCreateParams
        {
            AwayTeamID = "tottenham",
            Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.Cup,
            AwayScore = 0,
            HomeScore = 0,
            Result = MatchResult.Pending,
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
        };

        Assert.Null(parameters.Attendance);
        Assert.False(parameters.RawBodyData.ContainsKey("attendance"));
        Assert.Null(parameters.EpisodeID);
        Assert.False(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.LessonLearned);
        Assert.False(parameters.RawBodyData.ContainsKey("lesson_learned"));
        Assert.Null(parameters.PossessionPercentage);
        Assert.False(parameters.RawBodyData.ContainsKey("possession_percentage"));
        Assert.Null(parameters.TedHalftimeSpeech);
        Assert.False(parameters.RawBodyData.ContainsKey("ted_halftime_speech"));
        Assert.Null(parameters.TicketRevenueGbp);
        Assert.False(parameters.RawBodyData.ContainsKey("ticket_revenue_gbp"));
        Assert.Null(parameters.WeatherTempCelsius);
        Assert.False(parameters.RawBodyData.ContainsKey("weather_temp_celsius"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new MatchCreateParams
        {
            AwayTeamID = "tottenham",
            Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.Cup,
            AwayScore = 0,
            HomeScore = 0,
            Result = MatchResult.Pending,
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

            Attendance = null,
            EpisodeID = null,
            LessonLearned = null,
            PossessionPercentage = null,
            TedHalftimeSpeech = null,
            TicketRevenueGbp = null,
            WeatherTempCelsius = null,
        };

        Assert.Null(parameters.Attendance);
        Assert.True(parameters.RawBodyData.ContainsKey("attendance"));
        Assert.Null(parameters.EpisodeID);
        Assert.True(parameters.RawBodyData.ContainsKey("episode_id"));
        Assert.Null(parameters.LessonLearned);
        Assert.True(parameters.RawBodyData.ContainsKey("lesson_learned"));
        Assert.Null(parameters.PossessionPercentage);
        Assert.True(parameters.RawBodyData.ContainsKey("possession_percentage"));
        Assert.Null(parameters.TedHalftimeSpeech);
        Assert.True(parameters.RawBodyData.ContainsKey("ted_halftime_speech"));
        Assert.Null(parameters.TicketRevenueGbp);
        Assert.True(parameters.RawBodyData.ContainsKey("ticket_revenue_gbp"));
        Assert.Null(parameters.WeatherTempCelsius);
        Assert.True(parameters.RawBodyData.ContainsKey("weather_temp_celsius"));
    }

    [Fact]
    public void Url_Works()
    {
        MatchCreateParams parameters = new()
        {
            AwayTeamID = "tottenham",
            Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.Cup,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/matches"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MatchCreateParams
        {
            AwayTeamID = "tottenham",
            Date = DateTimeOffset.Parse("2024-02-20T19:45:00Z"),
            HomeTeamID = "afc-richmond",
            MatchType = MatchType.Cup,
            Attendance = 24500,
            AwayScore = 0,
            EpisodeID = "s02e05",
            HomeScore = 0,
            LessonLearned =
                "It's not about the wins and losses, it's about helping these young fellas be the best versions of themselves.",
            PossessionPercentage = 50,
            Result = MatchResult.Pending,
            TedHalftimeSpeech =
                "You know what the happiest animal on Earth is? It's a goldfish. You know why? It's got a 10-second memory.",
            TicketRevenueGbp = "735000.00",
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
            WeatherTempCelsius = 8.5,
        };

        MatchCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TicketRevenueGbpTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        TicketRevenueGbp value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        TicketRevenueGbp value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        TicketRevenueGbp value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketRevenueGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        TicketRevenueGbp value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TicketRevenueGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

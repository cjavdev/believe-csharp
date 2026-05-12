using System;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Models.Webhooks;

namespace Believe.Client.Tests.Models.Webhooks;

public class MatchCompletedWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatchCompletedWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchCompletedWebhookEventDataMatchType.League,
                Result = MatchCompletedWebhookEventDataResult.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = MatchCompletedWebhookEventEventType.MatchCompleted,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        MatchCompletedWebhookEventData expectedData = new()
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };
        string expectedEventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MatchCompletedWebhookEventEventType> expectedEventType =
            MatchCompletedWebhookEventEventType.MatchCompleted;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventType, model.EventType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MatchCompletedWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchCompletedWebhookEventDataMatchType.League,
                Result = MatchCompletedWebhookEventDataResult.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = MatchCompletedWebhookEventEventType.MatchCompleted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchCompletedWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatchCompletedWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchCompletedWebhookEventDataMatchType.League,
                Result = MatchCompletedWebhookEventDataResult.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = MatchCompletedWebhookEventEventType.MatchCompleted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchCompletedWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        MatchCompletedWebhookEventData expectedData = new()
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };
        string expectedEventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, MatchCompletedWebhookEventEventType> expectedEventType =
            MatchCompletedWebhookEventEventType.MatchCompleted;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventType, deserialized.EventType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MatchCompletedWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchCompletedWebhookEventDataMatchType.League,
                Result = MatchCompletedWebhookEventDataResult.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = MatchCompletedWebhookEventEventType.MatchCompleted,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MatchCompletedWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchCompletedWebhookEventDataMatchType.League,
                Result = MatchCompletedWebhookEventDataResult.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = MatchCompletedWebhookEventEventType.MatchCompleted,
        };

        MatchCompletedWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MatchCompletedWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };

        long expectedAwayScore = 0;
        string expectedAwayTeamID = "away_team_id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedHomeScore = 0;
        string expectedHomeTeamID = "home_team_id";
        string expectedMatchID = "match_id";
        ApiEnum<string, MatchCompletedWebhookEventDataMatchType> expectedMatchType =
            MatchCompletedWebhookEventDataMatchType.League;
        ApiEnum<string, MatchCompletedWebhookEventDataResult> expectedResult =
            MatchCompletedWebhookEventDataResult.HomeWin;
        string expectedTedPostMatchQuote = "ted_post_match_quote";
        string expectedLessonLearned = "lesson_learned";
        string expectedManOfTheMatch = "man_of_the_match";

        Assert.Equal(expectedAwayScore, model.AwayScore);
        Assert.Equal(expectedAwayTeamID, model.AwayTeamID);
        Assert.Equal(expectedCompletedAt, model.CompletedAt);
        Assert.Equal(expectedHomeScore, model.HomeScore);
        Assert.Equal(expectedHomeTeamID, model.HomeTeamID);
        Assert.Equal(expectedMatchID, model.MatchID);
        Assert.Equal(expectedMatchType, model.MatchType);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedTedPostMatchQuote, model.TedPostMatchQuote);
        Assert.Equal(expectedLessonLearned, model.LessonLearned);
        Assert.Equal(expectedManOfTheMatch, model.ManOfTheMatch);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchCompletedWebhookEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchCompletedWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAwayScore = 0;
        string expectedAwayTeamID = "away_team_id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedHomeScore = 0;
        string expectedHomeTeamID = "home_team_id";
        string expectedMatchID = "match_id";
        ApiEnum<string, MatchCompletedWebhookEventDataMatchType> expectedMatchType =
            MatchCompletedWebhookEventDataMatchType.League;
        ApiEnum<string, MatchCompletedWebhookEventDataResult> expectedResult =
            MatchCompletedWebhookEventDataResult.HomeWin;
        string expectedTedPostMatchQuote = "ted_post_match_quote";
        string expectedLessonLearned = "lesson_learned";
        string expectedManOfTheMatch = "man_of_the_match";

        Assert.Equal(expectedAwayScore, deserialized.AwayScore);
        Assert.Equal(expectedAwayTeamID, deserialized.AwayTeamID);
        Assert.Equal(expectedCompletedAt, deserialized.CompletedAt);
        Assert.Equal(expectedHomeScore, deserialized.HomeScore);
        Assert.Equal(expectedHomeTeamID, deserialized.HomeTeamID);
        Assert.Equal(expectedMatchID, deserialized.MatchID);
        Assert.Equal(expectedMatchType, deserialized.MatchType);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedTedPostMatchQuote, deserialized.TedPostMatchQuote);
        Assert.Equal(expectedLessonLearned, deserialized.LessonLearned);
        Assert.Equal(expectedManOfTheMatch, deserialized.ManOfTheMatch);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
        };

        Assert.Null(model.LessonLearned);
        Assert.False(model.RawData.ContainsKey("lesson_learned"));
        Assert.Null(model.ManOfTheMatch);
        Assert.False(model.RawData.ContainsKey("man_of_the_match"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",

            LessonLearned = null,
            ManOfTheMatch = null,
        };

        Assert.Null(model.LessonLearned);
        Assert.True(model.RawData.ContainsKey("lesson_learned"));
        Assert.Null(model.ManOfTheMatch);
        Assert.True(model.RawData.ContainsKey("man_of_the_match"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",

            LessonLearned = null,
            ManOfTheMatch = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MatchCompletedWebhookEventData
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchCompletedWebhookEventDataMatchType.League,
            Result = MatchCompletedWebhookEventDataResult.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };

        MatchCompletedWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MatchCompletedWebhookEventDataMatchTypeTest : TestBase
{
    [Theory]
    [InlineData(MatchCompletedWebhookEventDataMatchType.League)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Cup)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Friendly)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Playoff)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Final)]
    public void Validation_Works(MatchCompletedWebhookEventDataMatchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedWebhookEventDataMatchType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataMatchType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MatchCompletedWebhookEventDataMatchType.League)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Cup)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Friendly)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Playoff)]
    [InlineData(MatchCompletedWebhookEventDataMatchType.Final)]
    public void SerializationRoundtrip_Works(MatchCompletedWebhookEventDataMatchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedWebhookEventDataMatchType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataMatchType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataMatchType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataMatchType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MatchCompletedWebhookEventDataResultTest : TestBase
{
    [Theory]
    [InlineData(MatchCompletedWebhookEventDataResult.HomeWin)]
    [InlineData(MatchCompletedWebhookEventDataResult.AwayWin)]
    [InlineData(MatchCompletedWebhookEventDataResult.Draw)]
    public void Validation_Works(MatchCompletedWebhookEventDataResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedWebhookEventDataResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MatchCompletedWebhookEventDataResult.HomeWin)]
    [InlineData(MatchCompletedWebhookEventDataResult.AwayWin)]
    [InlineData(MatchCompletedWebhookEventDataResult.Draw)]
    public void SerializationRoundtrip_Works(MatchCompletedWebhookEventDataResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedWebhookEventDataResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventDataResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MatchCompletedWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(MatchCompletedWebhookEventEventType.MatchCompleted)]
    public void Validation_Works(MatchCompletedWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MatchCompletedWebhookEventEventType.MatchCompleted)]
    public void SerializationRoundtrip_Works(MatchCompletedWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MatchCompletedWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

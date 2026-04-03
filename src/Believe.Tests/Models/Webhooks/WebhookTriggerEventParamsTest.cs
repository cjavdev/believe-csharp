using System;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Webhooks;

namespace Believe.Tests.Models.Webhooks;

public class WebhookTriggerEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new WebhookTriggerEventParams
        {
            EventType = WebhookTriggerEventParamsEventType.MatchCompleted,Payload = new MatchCompleted(

            )
            {
                Data = new()
                {
                    AwayScore = 0,
                    AwayTeamID = "away_team_id",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HomeScore = 0,
                    HomeTeamID = "home_team_id",
                    MatchID = "match_id",
                    MatchType = MatchType.League,
                    Result = Result.HomeWin,
                    TedPostMatchQuote = "ted_post_match_quote",
                    LessonLearned = "lesson_learned",
                    ManOfTheMatch = "man_of_the_match",
                },
                EventType = MatchCompletedEventType.MatchCompleted,
            },
        };

        ApiEnum<string, WebhookTriggerEventParamsEventType> expectedEventType = WebhookTriggerEventParamsEventType.MatchCompleted;
        Payload expectedPayload = new MatchCompleted()
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventType = MatchCompletedEventType.MatchCompleted,
        };

        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedPayload, parameters.Payload);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {


        var parameters = new WebhookTriggerEventParams
        {
            EventType = WebhookTriggerEventParamsEventType.MatchCompleted,
        };

        Assert.Null(parameters.Payload);
        Assert.False(parameters.RawBodyData.ContainsKey("payload"));

    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {


        var parameters = new WebhookTriggerEventParams
        {
            EventType = WebhookTriggerEventParamsEventType.MatchCompleted,

            Payload = null,
        };

        Assert.Null(parameters.Payload);
        Assert.True(parameters.RawBodyData.ContainsKey("payload"));

    }

    [Fact]
    public void Url_Works()
    {
        WebhookTriggerEventParams parameters = new()
        {
            EventType = WebhookTriggerEventParamsEventType.MatchCompleted
        };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/webhooks/trigger"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new WebhookTriggerEventParams
        {
            EventType = WebhookTriggerEventParamsEventType.MatchCompleted,
            Payload = new MatchCompleted()
            {
                Data = new()
                {
                    AwayScore = 0,
                    AwayTeamID = "away_team_id",
                    CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    HomeScore = 0,
                    HomeTeamID = "home_team_id",
                    MatchID = "match_id",
                    MatchType = MatchType.League,
                    Result = Result.HomeWin,
                    TedPostMatchQuote = "ted_post_match_quote",
                    LessonLearned = "lesson_learned",
                    ManOfTheMatch = "man_of_the_match",
                },
                EventType = MatchCompletedEventType.MatchCompleted,
            },
        };

        WebhookTriggerEventParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class WebhookTriggerEventParamsEventTypeTest : TestBase
{
    [Theory][InlineData(WebhookTriggerEventParamsEventType.MatchCompleted)][InlineData(WebhookTriggerEventParamsEventType.TeamMemberTransferred)]
    public void Validation_Works(WebhookTriggerEventParamsEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookTriggerEventParamsEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookTriggerEventParamsEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(WebhookTriggerEventParamsEventType.MatchCompleted)][InlineData(WebhookTriggerEventParamsEventType.TeamMemberTransferred)]
    public void SerializationRoundtrip_Works(
        WebhookTriggerEventParamsEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookTriggerEventParamsEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookTriggerEventParamsEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookTriggerEventParamsEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookTriggerEventParamsEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PayloadTest : TestBase
{
    [Fact]
    public void MatchCompletedValidationWorks()
    {
        Payload value = new MatchCompleted()
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventType = MatchCompletedEventType.MatchCompleted,
        };
        value.Validate();
    }

    [Fact]
    public void TeamMemberTransferredValidationWorks()
    {
        Payload value = new TeamMemberTransferred()
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
            EventType = TeamMemberTransferredEventType.TeamMemberTransferred,
        };
        value.Validate();
    }

    [Fact]
    public void MatchCompletedSerializationRoundtripWorks()
    {
        Payload value = new MatchCompleted()
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventType = MatchCompletedEventType.MatchCompleted,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payload>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TeamMemberTransferredSerializationRoundtripWorks()
    {
        Payload value = new TeamMemberTransferred()
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
            EventType = TeamMemberTransferredEventType.TeamMemberTransferred,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payload>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MatchCompletedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },EventType = MatchCompletedEventType.MatchCompleted,
        };

        Data expectedData = new()
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchType.League,
            Result = Result.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };
        ApiEnum<string, MatchCompletedEventType> expectedEventType = MatchCompletedEventType.MatchCompleted;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedEventType, model.EventType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },EventType = MatchCompletedEventType.MatchCompleted,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchCompleted>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },EventType = MatchCompletedEventType.MatchCompleted,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MatchCompleted>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            AwayScore = 0,
            AwayTeamID = "away_team_id",
            CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HomeScore = 0,
            HomeTeamID = "home_team_id",
            MatchID = "match_id",
            MatchType = MatchType.League,
            Result = Result.HomeWin,
            TedPostMatchQuote = "ted_post_match_quote",
            LessonLearned = "lesson_learned",
            ManOfTheMatch = "man_of_the_match",
        };
        ApiEnum<string, MatchCompletedEventType> expectedEventType = MatchCompletedEventType.MatchCompleted;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedEventType, deserialized.EventType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },EventType = MatchCompletedEventType.MatchCompleted,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
        };

        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("event_type"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },

            // Null should be interpreted as omitted for these properties
            EventType = null,
        };

        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("event_type"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },

            // Null should be interpreted as omitted for these properties
            EventType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MatchCompleted
        {
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchType.League,
                Result = Result.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },EventType = MatchCompletedEventType.MatchCompleted,
        };

        MatchCompleted copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",LessonLearned = "lesson_learned",ManOfTheMatch = "man_of_the_match",
        };

        long expectedAwayScore = 0;
        string expectedAwayTeamID = "away_team_id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedHomeScore = 0;
        string expectedHomeTeamID = "home_team_id";
        string expectedMatchID = "match_id";
        ApiEnum<string, MatchType> expectedMatchType = MatchType.League;
        ApiEnum<string, Result> expectedResult = Result.HomeWin;
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
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",LessonLearned = "lesson_learned",ManOfTheMatch = "man_of_the_match",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",LessonLearned = "lesson_learned",ManOfTheMatch = "man_of_the_match",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedAwayScore = 0;
        string expectedAwayTeamID = "away_team_id";
        DateTimeOffset expectedCompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedHomeScore = 0;
        string expectedHomeTeamID = "home_team_id";
        string expectedMatchID = "match_id";
        ApiEnum<string, MatchType> expectedMatchType = MatchType.League;
        ApiEnum<string, Result> expectedResult = Result.HomeWin;
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
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",LessonLearned = "lesson_learned",ManOfTheMatch = "man_of_the_match",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",
        };

        Assert.Null(model.LessonLearned);
        Assert.False(model.RawData.ContainsKey("lesson_learned"));Assert.Null(model.ManOfTheMatch);
        Assert.False(model.RawData.ContainsKey("man_of_the_match"));

    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",

            LessonLearned = null,ManOfTheMatch = null,
        };

        Assert.Null(model.LessonLearned);
        Assert.True(model.RawData.ContainsKey("lesson_learned"));Assert.Null(model.ManOfTheMatch);
        Assert.True(model.RawData.ContainsKey("man_of_the_match"));

    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",

            LessonLearned = null,ManOfTheMatch = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            AwayScore = 0,AwayTeamID = "away_team_id",CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),HomeScore = 0,HomeTeamID = "home_team_id",MatchID = "match_id",MatchType = MatchType.League,Result = Result.HomeWin,TedPostMatchQuote = "ted_post_match_quote",LessonLearned = "lesson_learned",ManOfTheMatch = "man_of_the_match",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MatchTypeTest : TestBase
{
    [Theory][InlineData(MatchType.League)][InlineData(MatchType.Cup)][InlineData(MatchType.Friendly)][InlineData(MatchType.Playoff)][InlineData(MatchType.Final)]
    public void Validation_Works(MatchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(MatchType.League)][InlineData(MatchType.Cup)][InlineData(MatchType.Friendly)][InlineData(MatchType.Playoff)][InlineData(MatchType.Final)]
    public void SerializationRoundtrip_Works(MatchType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ResultTest : TestBase
{
    [Theory][InlineData(Result.HomeWin)][InlineData(Result.AwayWin)][InlineData(Result.Draw)]
    public void Validation_Works(Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Result>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(Result.HomeWin)][InlineData(Result.AwayWin)][InlineData(Result.Draw)]
    public void SerializationRoundtrip_Works(Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Result>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Result>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Result>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MatchCompletedEventTypeTest : TestBase
{
    [Theory][InlineData(MatchCompletedEventType.MatchCompleted)]
    public void Validation_Works(MatchCompletedEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchCompletedEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(MatchCompletedEventType.MatchCompleted)]
    public void SerializationRoundtrip_Works(MatchCompletedEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MatchCompletedEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchCompletedEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MatchCompletedEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MatchCompletedEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TeamMemberTransferredTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },EventType = TeamMemberTransferredEventType.TeamMemberTransferred,
        };

        TeamMemberTransferredData expectedData = new()
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = MemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };
        ApiEnum<string, TeamMemberTransferredEventType> expectedEventType = TeamMemberTransferredEventType.TeamMemberTransferred;

        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedEventType, model.EventType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },EventType = TeamMemberTransferredEventType.TeamMemberTransferred,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferred>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },EventType = TeamMemberTransferredEventType.TeamMemberTransferred,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferred>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        TeamMemberTransferredData expectedData = new()
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = MemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };
        ApiEnum<string, TeamMemberTransferredEventType> expectedEventType = TeamMemberTransferredEventType.TeamMemberTransferred;

        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedEventType, deserialized.EventType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },EventType = TeamMemberTransferredEventType.TeamMemberTransferred,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
        };

        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("event_type"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },

            // Null should be interpreted as omitted for these properties
            EventType = null,
        };

        Assert.Null(model.EventType);
        Assert.False(model.RawData.ContainsKey("event_type"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },

            // Null should be interpreted as omitted for these properties
            EventType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberTransferred
        {
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = MemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },EventType = TeamMemberTransferredEventType.TeamMemberTransferred,
        };

        TeamMemberTransferred copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamMemberTransferredDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,PreviousTeamID = "previous_team_id",PreviousTeamName = "previous_team_name",TransferFeeGbp = "transfer_fee_gbp",YearsWithPreviousTeam = 0,
        };

        string expectedCharacterID = "character_id";
        string expectedCharacterName = "character_name";
        ApiEnum<string, MemberType> expectedMemberType = MemberType.Player;
        string expectedTeamID = "team_id";
        string expectedTeamMemberID = "team_member_id";
        string expectedTeamName = "team_name";
        string expectedTedReaction = "ted_reaction";
        ApiEnum<string, TransferType> expectedTransferType = TransferType.Joined;
        string expectedPreviousTeamID = "previous_team_id";
        string expectedPreviousTeamName = "previous_team_name";
        string expectedTransferFeeGbp = "transfer_fee_gbp";
        long expectedYearsWithPreviousTeam = 0;

        Assert.Equal(expectedCharacterID, model.CharacterID);
        Assert.Equal(expectedCharacterName, model.CharacterName);
        Assert.Equal(expectedMemberType, model.MemberType);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedTeamMemberID, model.TeamMemberID);
        Assert.Equal(expectedTeamName, model.TeamName);
        Assert.Equal(expectedTedReaction, model.TedReaction);
        Assert.Equal(expectedTransferType, model.TransferType);
        Assert.Equal(expectedPreviousTeamID, model.PreviousTeamID);
        Assert.Equal(expectedPreviousTeamName, model.PreviousTeamName);
        Assert.Equal(expectedTransferFeeGbp, model.TransferFeeGbp);
        Assert.Equal(expectedYearsWithPreviousTeam, model.YearsWithPreviousTeam);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,PreviousTeamID = "previous_team_id",PreviousTeamName = "previous_team_name",TransferFeeGbp = "transfer_fee_gbp",YearsWithPreviousTeam = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferredData>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,PreviousTeamID = "previous_team_id",PreviousTeamName = "previous_team_name",TransferFeeGbp = "transfer_fee_gbp",YearsWithPreviousTeam = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferredData>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCharacterID = "character_id";
        string expectedCharacterName = "character_name";
        ApiEnum<string, MemberType> expectedMemberType = MemberType.Player;
        string expectedTeamID = "team_id";
        string expectedTeamMemberID = "team_member_id";
        string expectedTeamName = "team_name";
        string expectedTedReaction = "ted_reaction";
        ApiEnum<string, TransferType> expectedTransferType = TransferType.Joined;
        string expectedPreviousTeamID = "previous_team_id";
        string expectedPreviousTeamName = "previous_team_name";
        string expectedTransferFeeGbp = "transfer_fee_gbp";
        long expectedYearsWithPreviousTeam = 0;

        Assert.Equal(expectedCharacterID, deserialized.CharacterID);
        Assert.Equal(expectedCharacterName, deserialized.CharacterName);
        Assert.Equal(expectedMemberType, deserialized.MemberType);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedTeamMemberID, deserialized.TeamMemberID);
        Assert.Equal(expectedTeamName, deserialized.TeamName);
        Assert.Equal(expectedTedReaction, deserialized.TedReaction);
        Assert.Equal(expectedTransferType, deserialized.TransferType);
        Assert.Equal(expectedPreviousTeamID, deserialized.PreviousTeamID);
        Assert.Equal(expectedPreviousTeamName, deserialized.PreviousTeamName);
        Assert.Equal(expectedTransferFeeGbp, deserialized.TransferFeeGbp);
        Assert.Equal(expectedYearsWithPreviousTeam, deserialized.YearsWithPreviousTeam);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,PreviousTeamID = "previous_team_id",PreviousTeamName = "previous_team_name",TransferFeeGbp = "transfer_fee_gbp",YearsWithPreviousTeam = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,
        };

        Assert.Null(model.PreviousTeamID);
        Assert.False(model.RawData.ContainsKey("previous_team_id"));Assert.Null(model.PreviousTeamName);
        Assert.False(model.RawData.ContainsKey("previous_team_name"));Assert.Null(model.TransferFeeGbp);
        Assert.False(model.RawData.ContainsKey("transfer_fee_gbp"));Assert.Null(model.YearsWithPreviousTeam);
        Assert.False(model.RawData.ContainsKey("years_with_previous_team"));

    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,

            PreviousTeamID = null,PreviousTeamName = null,TransferFeeGbp = null,YearsWithPreviousTeam = null,
        };

        Assert.Null(model.PreviousTeamID);
        Assert.True(model.RawData.ContainsKey("previous_team_id"));Assert.Null(model.PreviousTeamName);
        Assert.True(model.RawData.ContainsKey("previous_team_name"));Assert.Null(model.TransferFeeGbp);
        Assert.True(model.RawData.ContainsKey("transfer_fee_gbp"));Assert.Null(model.YearsWithPreviousTeam);
        Assert.True(model.RawData.ContainsKey("years_with_previous_team"));

    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,

            PreviousTeamID = null,PreviousTeamName = null,TransferFeeGbp = null,YearsWithPreviousTeam = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberTransferredData
        {
            CharacterID = "character_id",CharacterName = "character_name",MemberType = MemberType.Player,TeamID = "team_id",TeamMemberID = "team_member_id",TeamName = "team_name",TedReaction = "ted_reaction",TransferType = TransferType.Joined,PreviousTeamID = "previous_team_id",PreviousTeamName = "previous_team_name",TransferFeeGbp = "transfer_fee_gbp",YearsWithPreviousTeam = 0,
        };

        TeamMemberTransferredData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MemberTypeTest : TestBase
{
    [Theory][InlineData(MemberType.Player)][InlineData(MemberType.Coach)][InlineData(MemberType.MedicalStaff)][InlineData(MemberType.EquipmentManager)]
    public void Validation_Works(MemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(MemberType.Player)][InlineData(MemberType.Coach)][InlineData(MemberType.MedicalStaff)][InlineData(MemberType.EquipmentManager)]
    public void SerializationRoundtrip_Works(MemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TransferTypeTest : TestBase
{
    [Theory][InlineData(TransferType.Joined)][InlineData(TransferType.Departed)]
    public void Validation_Works(TransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransferType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransferType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(TransferType.Joined)][InlineData(TransferType.Departed)]
    public void SerializationRoundtrip_Works(TransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TransferType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransferType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TransferType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TransferType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TeamMemberTransferredEventTypeTest : TestBase
{
    [Theory][InlineData(TeamMemberTransferredEventType.TeamMemberTransferred)]
    public void Validation_Works(TeamMemberTransferredEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberTransferredEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(TeamMemberTransferredEventType.TeamMemberTransferred)]
    public void SerializationRoundtrip_Works(
        TeamMemberTransferredEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberTransferredEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberTransferredEventType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberTransferredEventType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Press;

namespace Believe.Client.Tests.Models.Press;

public class PressSimulateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",
            DeflectionHumor =
                "Speaking of combinations, did y'all know that the average person forgets their password 37 times a year? Unrelated, but I just think that's fascinating.",
        };

        string expectedActualWisdom =
            "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.";
        string expectedFollowUpDodge =
            "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!";
        string expectedReporterReaction =
            "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.";
        string expectedResponse =
            "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.";
        string expectedDeflectionHumor =
            "Speaking of combinations, did y'all know that the average person forgets their password 37 times a year? Unrelated, but I just think that's fascinating.";

        Assert.Equal(expectedActualWisdom, model.ActualWisdom);
        Assert.Equal(expectedFollowUpDodge, model.FollowUpDodge);
        Assert.Equal(expectedReporterReaction, model.ReporterReaction);
        Assert.Equal(expectedResponse, model.Response);
        Assert.Equal(expectedDeflectionHumor, model.DeflectionHumor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",
            DeflectionHumor =
                "Speaking of combinations, did y'all know that the average person forgets their password 37 times a year? Unrelated, but I just think that's fascinating.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PressSimulateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",
            DeflectionHumor =
                "Speaking of combinations, did y'all know that the average person forgets their password 37 times a year? Unrelated, but I just think that's fascinating.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PressSimulateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActualWisdom =
            "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.";
        string expectedFollowUpDodge =
            "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!";
        string expectedReporterReaction =
            "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.";
        string expectedResponse =
            "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.";
        string expectedDeflectionHumor =
            "Speaking of combinations, did y'all know that the average person forgets their password 37 times a year? Unrelated, but I just think that's fascinating.";

        Assert.Equal(expectedActualWisdom, deserialized.ActualWisdom);
        Assert.Equal(expectedFollowUpDodge, deserialized.FollowUpDodge);
        Assert.Equal(expectedReporterReaction, deserialized.ReporterReaction);
        Assert.Equal(expectedResponse, deserialized.Response);
        Assert.Equal(expectedDeflectionHumor, deserialized.DeflectionHumor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",
            DeflectionHumor =
                "Speaking of combinations, did y'all know that the average person forgets their password 37 times a year? Unrelated, but I just think that's fascinating.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",
        };

        Assert.Null(model.DeflectionHumor);
        Assert.False(model.RawData.ContainsKey("deflection_humor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",

            DeflectionHumor = null,
        };

        Assert.Null(model.DeflectionHumor);
        Assert.True(model.RawData.ContainsKey("deflection_humor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",

            DeflectionHumor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PressSimulateResponse
        {
            ActualWisdom =
                "Every loss is a lesson. We didn't play our best today, but I saw something in those players' eyes at the final whistle - hunger. And you can't teach hunger.",
            FollowUpDodge =
                "I'd love to answer that, but I promised Coach Beard I'd help him find his lucky whistle. Y'all have a good one!",
            ReporterReaction =
                "Confused chuckles turn to thoughtful nods as they realize Ted has somehow made them feel better about a 5-0 loss.",
            Response =
                "Well, I'll tell you what, that score reminded me of my high school combination lock - 5-0 - except instead of opening my locker, it opened up a whole lot of learning opportunities for us today.",
            DeflectionHumor =
                "Speaking of combinations, did y'all know that the average person forgets their password 37 times a year? Unrelated, but I just think that's fascinating.",
        };

        PressSimulateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

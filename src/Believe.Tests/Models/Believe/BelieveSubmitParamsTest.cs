using System;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Believe;

namespace Believe.Tests.Models.Believe;

public class BelieveSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BelieveSubmitParams
        {
            Situation =
                "I just got passed over for a promotion I've been working toward for two years.",
            SituationType = SituationType.WorkChallenge,
            Context = "I've always tried to be a team player and support my colleagues.",
            Intensity = 7,
        };

        string expectedSituation =
            "I just got passed over for a promotion I've been working toward for two years.";
        ApiEnum<string, SituationType> expectedSituationType = SituationType.WorkChallenge;
        string expectedContext = "I've always tried to be a team player and support my colleagues.";
        long expectedIntensity = 7;

        Assert.Equal(expectedSituation, parameters.Situation);
        Assert.Equal(expectedSituationType, parameters.SituationType);
        Assert.Equal(expectedContext, parameters.Context);
        Assert.Equal(expectedIntensity, parameters.Intensity);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BelieveSubmitParams
        {
            Situation =
                "I just got passed over for a promotion I've been working toward for two years.",
            SituationType = SituationType.WorkChallenge,
            Context = "I've always tried to be a team player and support my colleagues.",
        };

        Assert.Null(parameters.Intensity);
        Assert.False(parameters.RawBodyData.ContainsKey("intensity"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BelieveSubmitParams
        {
            Situation =
                "I just got passed over for a promotion I've been working toward for two years.",
            SituationType = SituationType.WorkChallenge,
            Context = "I've always tried to be a team player and support my colleagues.",

            // Null should be interpreted as omitted for these properties
            Intensity = null,
        };

        Assert.Null(parameters.Intensity);
        Assert.False(parameters.RawBodyData.ContainsKey("intensity"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BelieveSubmitParams
        {
            Situation =
                "I just got passed over for a promotion I've been working toward for two years.",
            SituationType = SituationType.WorkChallenge,
            Intensity = 7,
        };

        Assert.Null(parameters.Context);
        Assert.False(parameters.RawBodyData.ContainsKey("context"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BelieveSubmitParams
        {
            Situation =
                "I just got passed over for a promotion I've been working toward for two years.",
            SituationType = SituationType.WorkChallenge,
            Intensity = 7,

            Context = null,
        };

        Assert.Null(parameters.Context);
        Assert.True(parameters.RawBodyData.ContainsKey("context"));
    }

    [Fact]
    public void Url_Works()
    {
        BelieveSubmitParams parameters = new()
        {
            Situation =
                "I just got passed over for a promotion I've been working toward for two years.",
            SituationType = SituationType.WorkChallenge,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/believe"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BelieveSubmitParams
        {
            Situation =
                "I just got passed over for a promotion I've been working toward for two years.",
            SituationType = SituationType.WorkChallenge,
            Context = "I've always tried to be a team player and support my colleagues.",
            Intensity = 7,
        };

        BelieveSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SituationTypeTest : TestBase
{
    [Theory]
    [InlineData(SituationType.WorkChallenge)]
    [InlineData(SituationType.PersonalSetback)]
    [InlineData(SituationType.TeamConflict)]
    [InlineData(SituationType.SelfDoubt)]
    [InlineData(SituationType.BigDecision)]
    [InlineData(SituationType.Failure)]
    [InlineData(SituationType.NewBeginning)]
    [InlineData(SituationType.Relationship)]
    public void Validation_Works(SituationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SituationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SituationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SituationType.WorkChallenge)]
    [InlineData(SituationType.PersonalSetback)]
    [InlineData(SituationType.TeamConflict)]
    [InlineData(SituationType.SelfDoubt)]
    [InlineData(SituationType.BigDecision)]
    [InlineData(SituationType.Failure)]
    [InlineData(SituationType.NewBeginning)]
    [InlineData(SituationType.Relationship)]
    public void SerializationRoundtrip_Works(SituationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SituationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SituationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SituationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SituationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

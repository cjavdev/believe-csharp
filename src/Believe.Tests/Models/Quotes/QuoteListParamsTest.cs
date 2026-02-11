using System;
using Believe.Core;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QuoteListParams
        {
            CharacterID = "character_id",
            Funny = true,
            Inspirational = true,
            Limit = 10,
            MomentType = QuoteMoment.HalftimeSpeech,
            Skip = 0,
            Theme = QuoteTheme.Belief,
        };

        string expectedCharacterID = "character_id";
        bool expectedFunny = true;
        bool expectedInspirational = true;
        long expectedLimit = 10;
        ApiEnum<string, QuoteMoment> expectedMomentType = QuoteMoment.HalftimeSpeech;
        long expectedSkip = 0;
        ApiEnum<string, QuoteTheme> expectedTheme = QuoteTheme.Belief;

        Assert.Equal(expectedCharacterID, parameters.CharacterID);
        Assert.Equal(expectedFunny, parameters.Funny);
        Assert.Equal(expectedInspirational, parameters.Inspirational);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMomentType, parameters.MomentType);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedTheme, parameters.Theme);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteListParams
        {
            CharacterID = "character_id",
            Funny = true,
            Inspirational = true,
            MomentType = QuoteMoment.HalftimeSpeech,
            Theme = QuoteTheme.Belief,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new QuoteListParams
        {
            CharacterID = "character_id",
            Funny = true,
            Inspirational = true,
            MomentType = QuoteMoment.HalftimeSpeech,
            Theme = QuoteTheme.Belief,

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Skip = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteListParams { Limit = 10, Skip = 0 };

        Assert.Null(parameters.CharacterID);
        Assert.False(parameters.RawQueryData.ContainsKey("character_id"));
        Assert.Null(parameters.Funny);
        Assert.False(parameters.RawQueryData.ContainsKey("funny"));
        Assert.Null(parameters.Inspirational);
        Assert.False(parameters.RawQueryData.ContainsKey("inspirational"));
        Assert.Null(parameters.MomentType);
        Assert.False(parameters.RawQueryData.ContainsKey("moment_type"));
        Assert.Null(parameters.Theme);
        Assert.False(parameters.RawQueryData.ContainsKey("theme"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new QuoteListParams
        {
            Limit = 10,
            Skip = 0,

            CharacterID = null,
            Funny = null,
            Inspirational = null,
            MomentType = null,
            Theme = null,
        };

        Assert.Null(parameters.CharacterID);
        Assert.True(parameters.RawQueryData.ContainsKey("character_id"));
        Assert.Null(parameters.Funny);
        Assert.True(parameters.RawQueryData.ContainsKey("funny"));
        Assert.Null(parameters.Inspirational);
        Assert.True(parameters.RawQueryData.ContainsKey("inspirational"));
        Assert.Null(parameters.MomentType);
        Assert.True(parameters.RawQueryData.ContainsKey("moment_type"));
        Assert.Null(parameters.Theme);
        Assert.True(parameters.RawQueryData.ContainsKey("theme"));
    }

    [Fact]
    public void Url_Works()
    {
        QuoteListParams parameters = new()
        {
            CharacterID = "character_id",
            Funny = true,
            Inspirational = true,
            Limit = 10,
            MomentType = QuoteMoment.HalftimeSpeech,
            Skip = 0,
            Theme = QuoteTheme.Belief,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://believe.cjav.dev/quotes?character_id=character_id&funny=true&inspirational=true&limit=10&moment_type=halftime_speech&skip=0&theme=belief"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteListParams
        {
            CharacterID = "character_id",
            Funny = true,
            Inspirational = true,
            Limit = 10,
            MomentType = QuoteMoment.HalftimeSpeech,
            Skip = 0,
            Theme = QuoteTheme.Belief,
        };

        QuoteListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

using System;
using Believe.Client.Core;
using Believe.Client.Models.Quotes;

namespace Believe.Client.Tests.Models.Quotes;

public class QuoteGetRandomParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QuoteGetRandomParams
        {
            CharacterID = "character_id",
            Inspirational = true,
            Theme = QuoteTheme.Belief,
        };

        string expectedCharacterID = "character_id";
        bool expectedInspirational = true;
        ApiEnum<string, QuoteTheme> expectedTheme = QuoteTheme.Belief;

        Assert.Equal(expectedCharacterID, parameters.CharacterID);
        Assert.Equal(expectedInspirational, parameters.Inspirational);
        Assert.Equal(expectedTheme, parameters.Theme);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteGetRandomParams { };

        Assert.Null(parameters.CharacterID);
        Assert.False(parameters.RawQueryData.ContainsKey("character_id"));
        Assert.Null(parameters.Inspirational);
        Assert.False(parameters.RawQueryData.ContainsKey("inspirational"));
        Assert.Null(parameters.Theme);
        Assert.False(parameters.RawQueryData.ContainsKey("theme"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new QuoteGetRandomParams
        {
            CharacterID = null,
            Inspirational = null,
            Theme = null,
        };

        Assert.Null(parameters.CharacterID);
        Assert.True(parameters.RawQueryData.ContainsKey("character_id"));
        Assert.Null(parameters.Inspirational);
        Assert.True(parameters.RawQueryData.ContainsKey("inspirational"));
        Assert.Null(parameters.Theme);
        Assert.True(parameters.RawQueryData.ContainsKey("theme"));
    }

    [Fact]
    public void Url_Works()
    {
        QuoteGetRandomParams parameters = new()
        {
            CharacterID = "character_id",
            Inspirational = true,
            Theme = QuoteTheme.Belief,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://believe.cjav.dev/quotes/random?character_id=character_id&inspirational=true&theme=belief"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteGetRandomParams
        {
            CharacterID = "character_id",
            Inspirational = true,
            Theme = QuoteTheme.Belief,
        };

        QuoteGetRandomParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

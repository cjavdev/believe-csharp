using System;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteListByCharacterParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QuoteListByCharacterParams
        {
            CharacterID = "character_id",
            Limit = 10,
            Skip = 0,
        };

        string expectedCharacterID = "character_id";
        long expectedLimit = 10;
        long expectedSkip = 0;

        Assert.Equal(expectedCharacterID, parameters.CharacterID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSkip, parameters.Skip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteListByCharacterParams { CharacterID = "character_id" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new QuoteListByCharacterParams
        {
            CharacterID = "character_id",

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
    public void Url_Works()
    {
        QuoteListByCharacterParams parameters = new()
        {
            CharacterID = "character_id",
            Limit = 10,
            Skip = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://believe.cjav.dev/quotes/characters/character_id?limit=10&skip=0"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteListByCharacterParams
        {
            CharacterID = "character_id",
            Limit = 10,
            Skip = 0,
        };

        QuoteListByCharacterParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

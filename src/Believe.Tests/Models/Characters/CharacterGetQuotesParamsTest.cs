using System;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class CharacterGetQuotesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new CharacterGetQuotesParams
        {
            CharacterID = "character_id",
        };

        string expectedCharacterID = "character_id";

        Assert.Equal(expectedCharacterID, parameters.CharacterID);
    }

    [Fact]
    public void Url_Works()
    {
        CharacterGetQuotesParams parameters = new()
        {
            CharacterID = "character_id"
        };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/characters/character_id/quotes"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CharacterGetQuotesParams
        {
            CharacterID = "character_id"
        };

        CharacterGetQuotesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
using System;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class CharacterDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new CharacterDeleteParams
        {
            CharacterID = "character_id",
        };

        string expectedCharacterID = "character_id";

        Assert.Equal(expectedCharacterID, parameters.CharacterID);
    }

    [Fact]
    public void Url_Works()
    {
        CharacterDeleteParams parameters = new()
        {
            CharacterID = "character_id"
        };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/characters/character_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CharacterDeleteParams
        {
            CharacterID = "character_id"
        };

        CharacterDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class CharacterUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CharacterUpdateParams
        {
            CharacterID = "character_id",
            Background = "background",
            DateOfBirth = "2019-12-27",
            Email = "dev@stainless.com",
            EmotionalStats = new()
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },
            GrowthArcs =
            [
                new()
                {
                    Breakthrough = "breakthrough",
                    Challenge = "challenge",
                    EndingPoint = "ending_point",
                    Season = 1,
                    StartingPoint = "starting_point",
                },
            ],
            HeightMeters = 1,
            Name = "x",
            PersonalityTraits = ["string"],
            ProfileImageUrl = "https://example.com",
            Role = CharacterRole.Coach,
            SalaryGbp = 0,
            SignatureQuotes = ["string"],
            TeamID = "team_id",
        };

        string expectedCharacterID = "character_id";
        string expectedBackground = "background";
        string expectedDateOfBirth = "2019-12-27";
        string expectedEmail = "dev@stainless.com";
        EmotionalStats expectedEmotionalStats = new()
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };
        List<GrowthArc> expectedGrowthArcs =
        [
            new()
            {
                Breakthrough = "breakthrough",
                Challenge = "challenge",
                EndingPoint = "ending_point",
                Season = 1,
                StartingPoint = "starting_point",
            },
        ];
        double expectedHeightMeters = 1;
        string expectedName = "x";
        List<string> expectedPersonalityTraits = ["string"];
        string expectedProfileImageUrl = "https://example.com";
        ApiEnum<string, CharacterRole> expectedRole = CharacterRole.Coach;
        CharacterUpdateParamsSalaryGbp expectedSalaryGbp = 0;
        List<string> expectedSignatureQuotes = ["string"];
        string expectedTeamID = "team_id";

        Assert.Equal(expectedCharacterID, parameters.CharacterID);
        Assert.Equal(expectedBackground, parameters.Background);
        Assert.Equal(expectedDateOfBirth, parameters.DateOfBirth);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedEmotionalStats, parameters.EmotionalStats);
        Assert.NotNull(parameters.GrowthArcs);
        Assert.Equal(expectedGrowthArcs.Count, parameters.GrowthArcs.Count);
        for (int i = 0; i < expectedGrowthArcs.Count; i++)
        {
            Assert.Equal(expectedGrowthArcs[i], parameters.GrowthArcs[i]);
        }
        Assert.Equal(expectedHeightMeters, parameters.HeightMeters);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.PersonalityTraits);
        Assert.Equal(expectedPersonalityTraits.Count, parameters.PersonalityTraits.Count);
        for (int i = 0; i < expectedPersonalityTraits.Count; i++)
        {
            Assert.Equal(expectedPersonalityTraits[i], parameters.PersonalityTraits[i]);
        }
        Assert.Equal(expectedProfileImageUrl, parameters.ProfileImageUrl);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedSalaryGbp, parameters.SalaryGbp);
        Assert.NotNull(parameters.SignatureQuotes);
        Assert.Equal(expectedSignatureQuotes.Count, parameters.SignatureQuotes.Count);
        for (int i = 0; i < expectedSignatureQuotes.Count; i++)
        {
            Assert.Equal(expectedSignatureQuotes[i], parameters.SignatureQuotes[i]);
        }
        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CharacterUpdateParams { CharacterID = "character_id" };

        Assert.Null(parameters.Background);
        Assert.False(parameters.RawBodyData.ContainsKey("background"));
        Assert.Null(parameters.DateOfBirth);
        Assert.False(parameters.RawBodyData.ContainsKey("date_of_birth"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.EmotionalStats);
        Assert.False(parameters.RawBodyData.ContainsKey("emotional_stats"));
        Assert.Null(parameters.GrowthArcs);
        Assert.False(parameters.RawBodyData.ContainsKey("growth_arcs"));
        Assert.Null(parameters.HeightMeters);
        Assert.False(parameters.RawBodyData.ContainsKey("height_meters"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PersonalityTraits);
        Assert.False(parameters.RawBodyData.ContainsKey("personality_traits"));
        Assert.Null(parameters.ProfileImageUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("profile_image_url"));
        Assert.Null(parameters.Role);
        Assert.False(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.SalaryGbp);
        Assert.False(parameters.RawBodyData.ContainsKey("salary_gbp"));
        Assert.Null(parameters.SignatureQuotes);
        Assert.False(parameters.RawBodyData.ContainsKey("signature_quotes"));
        Assert.Null(parameters.TeamID);
        Assert.False(parameters.RawBodyData.ContainsKey("team_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CharacterUpdateParams
        {
            CharacterID = "character_id",

            Background = null,
            DateOfBirth = null,
            Email = null,
            EmotionalStats = null,
            GrowthArcs = null,
            HeightMeters = null,
            Name = null,
            PersonalityTraits = null,
            ProfileImageUrl = null,
            Role = null,
            SalaryGbp = null,
            SignatureQuotes = null,
            TeamID = null,
        };

        Assert.Null(parameters.Background);
        Assert.True(parameters.RawBodyData.ContainsKey("background"));
        Assert.Null(parameters.DateOfBirth);
        Assert.True(parameters.RawBodyData.ContainsKey("date_of_birth"));
        Assert.Null(parameters.Email);
        Assert.True(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.EmotionalStats);
        Assert.True(parameters.RawBodyData.ContainsKey("emotional_stats"));
        Assert.Null(parameters.GrowthArcs);
        Assert.True(parameters.RawBodyData.ContainsKey("growth_arcs"));
        Assert.Null(parameters.HeightMeters);
        Assert.True(parameters.RawBodyData.ContainsKey("height_meters"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PersonalityTraits);
        Assert.True(parameters.RawBodyData.ContainsKey("personality_traits"));
        Assert.Null(parameters.ProfileImageUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("profile_image_url"));
        Assert.Null(parameters.Role);
        Assert.True(parameters.RawBodyData.ContainsKey("role"));
        Assert.Null(parameters.SalaryGbp);
        Assert.True(parameters.RawBodyData.ContainsKey("salary_gbp"));
        Assert.Null(parameters.SignatureQuotes);
        Assert.True(parameters.RawBodyData.ContainsKey("signature_quotes"));
        Assert.Null(parameters.TeamID);
        Assert.True(parameters.RawBodyData.ContainsKey("team_id"));
    }

    [Fact]
    public void Url_Works()
    {
        CharacterUpdateParams parameters = new() { CharacterID = "character_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/characters/character_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CharacterUpdateParams
        {
            CharacterID = "character_id",
            Background = "background",
            DateOfBirth = "2019-12-27",
            Email = "dev@stainless.com",
            EmotionalStats = new()
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },
            GrowthArcs =
            [
                new()
                {
                    Breakthrough = "breakthrough",
                    Challenge = "challenge",
                    EndingPoint = "ending_point",
                    Season = 1,
                    StartingPoint = "starting_point",
                },
            ],
            HeightMeters = 1,
            Name = "x",
            PersonalityTraits = ["string"],
            ProfileImageUrl = "https://example.com",
            Role = CharacterRole.Coach,
            SalaryGbp = 0,
            SignatureQuotes = ["string"],
            TeamID = "team_id",
        };

        CharacterUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CharacterUpdateParamsSalaryGbpTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        CharacterUpdateParamsSalaryGbp value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        CharacterUpdateParamsSalaryGbp value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        CharacterUpdateParamsSalaryGbp value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CharacterUpdateParamsSalaryGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        CharacterUpdateParamsSalaryGbp value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CharacterUpdateParamsSalaryGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

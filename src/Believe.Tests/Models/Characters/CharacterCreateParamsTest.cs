using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class CharacterCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CharacterCreateParams
        {
            Background =
                "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
            EmotionalStats = new()
            {
                Curiosity = 40,
                Empathy = 85,
                Optimism = 45,
                Resilience = 95,
                Vulnerability = 60,
            },
            Name = "Roy Kent",
            PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
            Role = CharacterRole.Coach,
            DateOfBirth = "1977-03-15",
            Email = "roy.kent@afcrichmond.com",
            GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Finding purpose beyond playing",
                    Challenge = "Accepting his body's limitations",
                    EndingPoint = "Retired but lost",
                    Season = 1,
                    StartingPoint = "Aging footballer facing retirement",
                },
            ],
            HeightMeters = 1.78,
            ProfileImageUrl = "https://afcrichmond.com/images/roy-kent.jpg",
            SalaryGbp = "175000.00",
            SignatureQuotes =
            [
                "He's here, he's there, he's every-f***ing-where, Roy Kent!",
                "Whistle!",
            ],
            TeamID = "afc-richmond",
        };

        string expectedBackground =
            "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.";
        EmotionalStats expectedEmotionalStats = new()
        {
            Curiosity = 40,
            Empathy = 85,
            Optimism = 45,
            Resilience = 95,
            Vulnerability = 60,
        };
        string expectedName = "Roy Kent";
        List<string> expectedPersonalityTraits = ["intense", "loyal", "secretly caring", "profane"];
        ApiEnum<string, CharacterRole> expectedRole = CharacterRole.Coach;
        string expectedDateOfBirth = "1977-03-15";
        string expectedEmail = "roy.kent@afcrichmond.com";
        List<GrowthArc> expectedGrowthArcs =
        [
            new()
            {
                Breakthrough = "Finding purpose beyond playing",
                Challenge = "Accepting his body's limitations",
                EndingPoint = "Retired but lost",
                Season = 1,
                StartingPoint = "Aging footballer facing retirement",
            },
        ];
        double expectedHeightMeters = 1.78;
        string expectedProfileImageUrl = "https://afcrichmond.com/images/roy-kent.jpg";
        SalaryGbp expectedSalaryGbp = "175000.00";
        List<string> expectedSignatureQuotes =
        [
            "He's here, he's there, he's every-f***ing-where, Roy Kent!",
            "Whistle!",
        ];
        string expectedTeamID = "afc-richmond";

        Assert.Equal(expectedBackground, parameters.Background);
        Assert.Equal(expectedEmotionalStats, parameters.EmotionalStats);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPersonalityTraits.Count, parameters.PersonalityTraits.Count);
        for (int i = 0; i < expectedPersonalityTraits.Count; i++)
        {
            Assert.Equal(expectedPersonalityTraits[i], parameters.PersonalityTraits[i]);
        }
        Assert.Equal(expectedRole, parameters.Role);
        Assert.Equal(expectedDateOfBirth, parameters.DateOfBirth);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.NotNull(parameters.GrowthArcs);
        Assert.Equal(expectedGrowthArcs.Count, parameters.GrowthArcs.Count);
        for (int i = 0; i < expectedGrowthArcs.Count; i++)
        {
            Assert.Equal(expectedGrowthArcs[i], parameters.GrowthArcs[i]);
        }
        Assert.Equal(expectedHeightMeters, parameters.HeightMeters);
        Assert.Equal(expectedProfileImageUrl, parameters.ProfileImageUrl);
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
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CharacterCreateParams
        {
            Background =
                "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
            EmotionalStats = new()
            {
                Curiosity = 40,
                Empathy = 85,
                Optimism = 45,
                Resilience = 95,
                Vulnerability = 60,
            },
            Name = "Roy Kent",
            PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
            Role = CharacterRole.Coach,
            DateOfBirth = "1977-03-15",
            Email = "roy.kent@afcrichmond.com",
            HeightMeters = 1.78,
            ProfileImageUrl = "https://afcrichmond.com/images/roy-kent.jpg",
            SalaryGbp = "175000.00",
            TeamID = "afc-richmond",
        };

        Assert.Null(parameters.GrowthArcs);
        Assert.False(parameters.RawBodyData.ContainsKey("growth_arcs"));
        Assert.Null(parameters.SignatureQuotes);
        Assert.False(parameters.RawBodyData.ContainsKey("signature_quotes"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CharacterCreateParams
        {
            Background =
                "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
            EmotionalStats = new()
            {
                Curiosity = 40,
                Empathy = 85,
                Optimism = 45,
                Resilience = 95,
                Vulnerability = 60,
            },
            Name = "Roy Kent",
            PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
            Role = CharacterRole.Coach,
            DateOfBirth = "1977-03-15",
            Email = "roy.kent@afcrichmond.com",
            HeightMeters = 1.78,
            ProfileImageUrl = "https://afcrichmond.com/images/roy-kent.jpg",
            SalaryGbp = "175000.00",
            TeamID = "afc-richmond",

            // Null should be interpreted as omitted for these properties
            GrowthArcs = null,
            SignatureQuotes = null,
        };

        Assert.Null(parameters.GrowthArcs);
        Assert.False(parameters.RawBodyData.ContainsKey("growth_arcs"));
        Assert.Null(parameters.SignatureQuotes);
        Assert.False(parameters.RawBodyData.ContainsKey("signature_quotes"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CharacterCreateParams
        {
            Background =
                "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
            EmotionalStats = new()
            {
                Curiosity = 40,
                Empathy = 85,
                Optimism = 45,
                Resilience = 95,
                Vulnerability = 60,
            },
            Name = "Roy Kent",
            PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
            Role = CharacterRole.Coach,
            GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Finding purpose beyond playing",
                    Challenge = "Accepting his body's limitations",
                    EndingPoint = "Retired but lost",
                    Season = 1,
                    StartingPoint = "Aging footballer facing retirement",
                },
            ],
            SignatureQuotes =
            [
                "He's here, he's there, he's every-f***ing-where, Roy Kent!",
                "Whistle!",
            ],
        };

        Assert.Null(parameters.DateOfBirth);
        Assert.False(parameters.RawBodyData.ContainsKey("date_of_birth"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.HeightMeters);
        Assert.False(parameters.RawBodyData.ContainsKey("height_meters"));
        Assert.Null(parameters.ProfileImageUrl);
        Assert.False(parameters.RawBodyData.ContainsKey("profile_image_url"));
        Assert.Null(parameters.SalaryGbp);
        Assert.False(parameters.RawBodyData.ContainsKey("salary_gbp"));
        Assert.Null(parameters.TeamID);
        Assert.False(parameters.RawBodyData.ContainsKey("team_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CharacterCreateParams
        {
            Background =
                "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
            EmotionalStats = new()
            {
                Curiosity = 40,
                Empathy = 85,
                Optimism = 45,
                Resilience = 95,
                Vulnerability = 60,
            },
            Name = "Roy Kent",
            PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
            Role = CharacterRole.Coach,
            GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Finding purpose beyond playing",
                    Challenge = "Accepting his body's limitations",
                    EndingPoint = "Retired but lost",
                    Season = 1,
                    StartingPoint = "Aging footballer facing retirement",
                },
            ],
            SignatureQuotes =
            [
                "He's here, he's there, he's every-f***ing-where, Roy Kent!",
                "Whistle!",
            ],

            DateOfBirth = null,
            Email = null,
            HeightMeters = null,
            ProfileImageUrl = null,
            SalaryGbp = null,
            TeamID = null,
        };

        Assert.Null(parameters.DateOfBirth);
        Assert.True(parameters.RawBodyData.ContainsKey("date_of_birth"));
        Assert.Null(parameters.Email);
        Assert.True(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.HeightMeters);
        Assert.True(parameters.RawBodyData.ContainsKey("height_meters"));
        Assert.Null(parameters.ProfileImageUrl);
        Assert.True(parameters.RawBodyData.ContainsKey("profile_image_url"));
        Assert.Null(parameters.SalaryGbp);
        Assert.True(parameters.RawBodyData.ContainsKey("salary_gbp"));
        Assert.Null(parameters.TeamID);
        Assert.True(parameters.RawBodyData.ContainsKey("team_id"));
    }

    [Fact]
    public void Url_Works()
    {
        CharacterCreateParams parameters = new()
        {
            Background =
                "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
            EmotionalStats = new()
            {
                Curiosity = 40,
                Empathy = 85,
                Optimism = 45,
                Resilience = 95,
                Vulnerability = 60,
            },
            Name = "Roy Kent",
            PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
            Role = CharacterRole.Coach,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/characters"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CharacterCreateParams
        {
            Background =
                "Legendary midfielder for Chelsea and AFC Richmond, now assistant coach. Known for his gruff exterior hiding a heart of gold.",
            EmotionalStats = new()
            {
                Curiosity = 40,
                Empathy = 85,
                Optimism = 45,
                Resilience = 95,
                Vulnerability = 60,
            },
            Name = "Roy Kent",
            PersonalityTraits = ["intense", "loyal", "secretly caring", "profane"],
            Role = CharacterRole.Coach,
            DateOfBirth = "1977-03-15",
            Email = "roy.kent@afcrichmond.com",
            GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Finding purpose beyond playing",
                    Challenge = "Accepting his body's limitations",
                    EndingPoint = "Retired but lost",
                    Season = 1,
                    StartingPoint = "Aging footballer facing retirement",
                },
            ],
            HeightMeters = 1.78,
            ProfileImageUrl = "https://afcrichmond.com/images/roy-kent.jpg",
            SalaryGbp = "175000.00",
            SignatureQuotes =
            [
                "He's here, he's there, he's every-f***ing-where, Roy Kent!",
                "Whistle!",
            ],
            TeamID = "afc-richmond",
        };

        CharacterCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SalaryGbpTest : TestBase
{
    [Fact]
    public void DoubleValidationWorks()
    {
        SalaryGbp value = 0;
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        SalaryGbp value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        SalaryGbp value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SalaryGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        SalaryGbp value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SalaryGbp>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

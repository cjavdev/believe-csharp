using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class CharacterTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],TeamID = "afc-richmond",
        };

        string expectedID = "ted-lasso";
        string expectedBackground = "Former American football coach from Kansas who moved to London to coach AFC Richmond";
        EmotionalStats expectedEmotionalStats = new()
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };
        string expectedName = "Ted Lasso";
        List<string> expectedPersonalityTraits =
        [
            "optimistic", "kind", "folksy", "persistent"
        ];
        ApiEnum<string, CharacterRole> expectedRole = CharacterRole.Coach;
        string expectedDateOfBirth = "1970-09-22";
        string expectedEmail = "ted.lasso@afcrichmond.com";
        List<GrowthArc> expectedGrowthArcs =
        [
            new()
            {
                Breakthrough = "Showing vulnerability about his marriage",
                Challenge = "Earning respect despite inexperience",
                EndingPoint = "Accepted by the team despite relegation",
                Season = 1,
                StartingPoint = "Fish out of water, hiding pain with humor",
            },
        ];
        double expectedHeightMeters = 1.83;
        string expectedProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg";
        string expectedSalaryGbp = "150000.00";
        List<string> expectedSignatureQuotes =
        [
            "I believe in believe.", "Be curious, not judgmental."
        ];
        string expectedTeamID = "afc-richmond";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBackground, model.Background);
        Assert.Equal(expectedEmotionalStats, model.EmotionalStats);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPersonalityTraits.Count, model.PersonalityTraits.Count);
        for (int i = 0; i < expectedPersonalityTraits.Count; i++)
        {
            Assert.Equal(expectedPersonalityTraits[i], model.PersonalityTraits[i]);
        }
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedDateOfBirth, model.DateOfBirth);
        Assert.Equal(expectedEmail, model.Email);
        Assert.NotNull(model.GrowthArcs);
        Assert.Equal(expectedGrowthArcs.Count, model.GrowthArcs.Count);
        for (int i = 0; i < expectedGrowthArcs.Count; i++)
        {
            Assert.Equal(expectedGrowthArcs[i], model.GrowthArcs[i]);
        }
        Assert.Equal(expectedHeightMeters, model.HeightMeters);
        Assert.Equal(expectedProfileImageUrl, model.ProfileImageUrl);
        Assert.Equal(expectedSalaryGbp, model.SalaryGbp);
        Assert.NotNull(model.SignatureQuotes);
        Assert.Equal(expectedSignatureQuotes.Count, model.SignatureQuotes.Count);
        for (int i = 0; i < expectedSignatureQuotes.Count; i++)
        {
            Assert.Equal(expectedSignatureQuotes[i], model.SignatureQuotes[i]);
        }
        Assert.Equal(expectedTeamID, model.TeamID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],TeamID = "afc-richmond",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Character>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],TeamID = "afc-richmond",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Character>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "ted-lasso";
        string expectedBackground = "Former American football coach from Kansas who moved to London to coach AFC Richmond";
        EmotionalStats expectedEmotionalStats = new()
        {
            Curiosity = 99,
            Empathy = 100,
            Optimism = 95,
            Resilience = 90,
            Vulnerability = 80,
        };
        string expectedName = "Ted Lasso";
        List<string> expectedPersonalityTraits =
        [
            "optimistic", "kind", "folksy", "persistent"
        ];
        ApiEnum<string, CharacterRole> expectedRole = CharacterRole.Coach;
        string expectedDateOfBirth = "1970-09-22";
        string expectedEmail = "ted.lasso@afcrichmond.com";
        List<GrowthArc> expectedGrowthArcs =
        [
            new()
            {
                Breakthrough = "Showing vulnerability about his marriage",
                Challenge = "Earning respect despite inexperience",
                EndingPoint = "Accepted by the team despite relegation",
                Season = 1,
                StartingPoint = "Fish out of water, hiding pain with humor",
            },
        ];
        double expectedHeightMeters = 1.83;
        string expectedProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg";
        string expectedSalaryGbp = "150000.00";
        List<string> expectedSignatureQuotes =
        [
            "I believe in believe.", "Be curious, not judgmental."
        ];
        string expectedTeamID = "afc-richmond";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBackground, deserialized.Background);
        Assert.Equal(expectedEmotionalStats, deserialized.EmotionalStats);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPersonalityTraits.Count, deserialized.PersonalityTraits.Count);
        for (int i = 0; i < expectedPersonalityTraits.Count; i++)
        {
            Assert.Equal(expectedPersonalityTraits[i], deserialized.PersonalityTraits[i]);
        }
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedDateOfBirth, deserialized.DateOfBirth);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.NotNull(deserialized.GrowthArcs);
        Assert.Equal(expectedGrowthArcs.Count, deserialized.GrowthArcs.Count);
        for (int i = 0; i < expectedGrowthArcs.Count; i++)
        {
            Assert.Equal(expectedGrowthArcs[i], deserialized.GrowthArcs[i]);
        }
        Assert.Equal(expectedHeightMeters, deserialized.HeightMeters);
        Assert.Equal(expectedProfileImageUrl, deserialized.ProfileImageUrl);
        Assert.Equal(expectedSalaryGbp, deserialized.SalaryGbp);
        Assert.NotNull(deserialized.SignatureQuotes);
        Assert.Equal(expectedSignatureQuotes.Count, deserialized.SignatureQuotes.Count);
        for (int i = 0; i < expectedSignatureQuotes.Count; i++)
        {
            Assert.Equal(expectedSignatureQuotes[i], deserialized.SignatureQuotes[i]);
        }
        Assert.Equal(expectedTeamID, deserialized.TeamID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],TeamID = "afc-richmond",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",TeamID = "afc-richmond",
        };

        Assert.Null(model.GrowthArcs);
        Assert.False(model.RawData.ContainsKey("growth_arcs"));Assert.Null(model.SignatureQuotes);
        Assert.False(model.RawData.ContainsKey("signature_quotes"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",TeamID = "afc-richmond",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",TeamID = "afc-richmond",

            // Null should be interpreted as omitted for these properties
            GrowthArcs = null,SignatureQuotes = null,
        };

        Assert.Null(model.GrowthArcs);
        Assert.False(model.RawData.ContainsKey("growth_arcs"));Assert.Null(model.SignatureQuotes);
        Assert.False(model.RawData.ContainsKey("signature_quotes"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",TeamID = "afc-richmond",

            // Null should be interpreted as omitted for these properties
            GrowthArcs = null,SignatureQuotes = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],
        };

        Assert.Null(model.DateOfBirth);
        Assert.False(model.RawData.ContainsKey("date_of_birth"));Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));Assert.Null(model.HeightMeters);
        Assert.False(model.RawData.ContainsKey("height_meters"));Assert.Null(model.ProfileImageUrl);
        Assert.False(model.RawData.ContainsKey("profile_image_url"));Assert.Null(model.SalaryGbp);
        Assert.False(model.RawData.ContainsKey("salary_gbp"));Assert.Null(model.TeamID);
        Assert.False(model.RawData.ContainsKey("team_id"));

    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],

            DateOfBirth = null,Email = null,HeightMeters = null,ProfileImageUrl = null,SalaryGbp = null,TeamID = null,
        };

        Assert.Null(model.DateOfBirth);
        Assert.True(model.RawData.ContainsKey("date_of_birth"));Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));Assert.Null(model.HeightMeters);
        Assert.True(model.RawData.ContainsKey("height_meters"));Assert.Null(model.ProfileImageUrl);
        Assert.True(model.RawData.ContainsKey("profile_image_url"));Assert.Null(model.SalaryGbp);
        Assert.True(model.RawData.ContainsKey("salary_gbp"));Assert.Null(model.TeamID);
        Assert.True(model.RawData.ContainsKey("team_id"));

    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],

            DateOfBirth = null,Email = null,HeightMeters = null,ProfileImageUrl = null,SalaryGbp = null,TeamID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Character
        {
            ID = "ted-lasso",Background = "Former American football coach from Kansas who moved to London to coach AFC Richmond",EmotionalStats = new(

            )
            {
                Curiosity = 99,
                Empathy = 100,
                Optimism = 95,
                Resilience = 90,
                Vulnerability = 80,
            },Name = "Ted Lasso",PersonalityTraits =
            [
                "optimistic", "kind", "folksy", "persistent"
            ],Role = CharacterRole.Coach,DateOfBirth = "1970-09-22",Email = "ted.lasso@afcrichmond.com",GrowthArcs =
            [
                new()
                {
                    Breakthrough = "Showing vulnerability about his marriage",
                    Challenge = "Earning respect despite inexperience",
                    EndingPoint = "Accepted by the team despite relegation",
                    Season = 1,
                    StartingPoint = "Fish out of water, hiding pain with humor",
                },
            ],HeightMeters = 1.83,ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",SalaryGbp = "150000.00",SignatureQuotes =
            [
                "I believe in believe.", "Be curious, not judgmental."
            ],TeamID = "afc-richmond",
        };

        Character copied = new(model);

        Assert.Equal(model, copied);
    }
}
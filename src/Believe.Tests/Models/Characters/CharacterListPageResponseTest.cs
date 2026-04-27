using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class CharacterListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CharacterListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ted-lasso",
                    Background =
                        "Former American football coach from Kansas who moved to London to coach AFC Richmond",
                    EmotionalStats = new()
                    {
                        Curiosity = 99,
                        Empathy = 100,
                        Optimism = 95,
                        Resilience = 90,
                        Vulnerability = 80,
                    },
                    Name = "Ted Lasso",
                    PersonalityTraits = ["optimistic", "kind", "folksy", "persistent"],
                    Role = CharacterRole.Coach,
                    DateOfBirth = "1970-09-22",
                    Email = "ted.lasso@afcrichmond.com",
                    GrowthArcs =
                    [
                        new()
                        {
                            Breakthrough = "Showing vulnerability about his marriage",
                            Challenge = "Earning respect despite inexperience",
                            EndingPoint = "Accepted by the team despite relegation",
                            Season = 1,
                            StartingPoint = "Fish out of water, hiding pain with humor",
                        },
                    ],
                    HeightMeters = 1.83,
                    ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",
                    SalaryGbp = "150000.00",
                    SignatureQuotes = ["I believe in believe.", "Be curious, not judgmental."],
                    TeamID = "afc-richmond",
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        List<Characterz> expectedData =
        [
            new()
            {
                ID = "ted-lasso",
                Background =
                    "Former American football coach from Kansas who moved to London to coach AFC Richmond",
                EmotionalStats = new()
                {
                    Curiosity = 99,
                    Empathy = 100,
                    Optimism = 95,
                    Resilience = 90,
                    Vulnerability = 80,
                },
                Name = "Ted Lasso",
                PersonalityTraits = ["optimistic", "kind", "folksy", "persistent"],
                Role = CharacterRole.Coach,
                DateOfBirth = "1970-09-22",
                Email = "ted.lasso@afcrichmond.com",
                GrowthArcs =
                [
                    new()
                    {
                        Breakthrough = "Showing vulnerability about his marriage",
                        Challenge = "Earning respect despite inexperience",
                        EndingPoint = "Accepted by the team despite relegation",
                        Season = 1,
                        StartingPoint = "Fish out of water, hiding pain with humor",
                    },
                ],
                HeightMeters = 1.83,
                ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",
                SalaryGbp = "150000.00",
                SignatureQuotes = ["I believe in believe.", "Be curious, not judgmental."],
                TeamID = "afc-richmond",
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPages, model.Pages);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CharacterListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ted-lasso",
                    Background =
                        "Former American football coach from Kansas who moved to London to coach AFC Richmond",
                    EmotionalStats = new()
                    {
                        Curiosity = 99,
                        Empathy = 100,
                        Optimism = 95,
                        Resilience = 90,
                        Vulnerability = 80,
                    },
                    Name = "Ted Lasso",
                    PersonalityTraits = ["optimistic", "kind", "folksy", "persistent"],
                    Role = CharacterRole.Coach,
                    DateOfBirth = "1970-09-22",
                    Email = "ted.lasso@afcrichmond.com",
                    GrowthArcs =
                    [
                        new()
                        {
                            Breakthrough = "Showing vulnerability about his marriage",
                            Challenge = "Earning respect despite inexperience",
                            EndingPoint = "Accepted by the team despite relegation",
                            Season = 1,
                            StartingPoint = "Fish out of water, hiding pain with humor",
                        },
                    ],
                    HeightMeters = 1.83,
                    ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",
                    SalaryGbp = "150000.00",
                    SignatureQuotes = ["I believe in believe.", "Be curious, not judgmental."],
                    TeamID = "afc-richmond",
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CharacterListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CharacterListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ted-lasso",
                    Background =
                        "Former American football coach from Kansas who moved to London to coach AFC Richmond",
                    EmotionalStats = new()
                    {
                        Curiosity = 99,
                        Empathy = 100,
                        Optimism = 95,
                        Resilience = 90,
                        Vulnerability = 80,
                    },
                    Name = "Ted Lasso",
                    PersonalityTraits = ["optimistic", "kind", "folksy", "persistent"],
                    Role = CharacterRole.Coach,
                    DateOfBirth = "1970-09-22",
                    Email = "ted.lasso@afcrichmond.com",
                    GrowthArcs =
                    [
                        new()
                        {
                            Breakthrough = "Showing vulnerability about his marriage",
                            Challenge = "Earning respect despite inexperience",
                            EndingPoint = "Accepted by the team despite relegation",
                            Season = 1,
                            StartingPoint = "Fish out of water, hiding pain with humor",
                        },
                    ],
                    HeightMeters = 1.83,
                    ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",
                    SalaryGbp = "150000.00",
                    SignatureQuotes = ["I believe in believe.", "Be curious, not judgmental."],
                    TeamID = "afc-richmond",
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CharacterListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Characterz> expectedData =
        [
            new()
            {
                ID = "ted-lasso",
                Background =
                    "Former American football coach from Kansas who moved to London to coach AFC Richmond",
                EmotionalStats = new()
                {
                    Curiosity = 99,
                    Empathy = 100,
                    Optimism = 95,
                    Resilience = 90,
                    Vulnerability = 80,
                },
                Name = "Ted Lasso",
                PersonalityTraits = ["optimistic", "kind", "folksy", "persistent"],
                Role = CharacterRole.Coach,
                DateOfBirth = "1970-09-22",
                Email = "ted.lasso@afcrichmond.com",
                GrowthArcs =
                [
                    new()
                    {
                        Breakthrough = "Showing vulnerability about his marriage",
                        Challenge = "Earning respect despite inexperience",
                        EndingPoint = "Accepted by the team despite relegation",
                        Season = 1,
                        StartingPoint = "Fish out of water, hiding pain with humor",
                    },
                ],
                HeightMeters = 1.83,
                ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",
                SalaryGbp = "150000.00",
                SignatureQuotes = ["I believe in believe.", "Be curious, not judgmental."],
                TeamID = "afc-richmond",
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPages, deserialized.Pages);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CharacterListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ted-lasso",
                    Background =
                        "Former American football coach from Kansas who moved to London to coach AFC Richmond",
                    EmotionalStats = new()
                    {
                        Curiosity = 99,
                        Empathy = 100,
                        Optimism = 95,
                        Resilience = 90,
                        Vulnerability = 80,
                    },
                    Name = "Ted Lasso",
                    PersonalityTraits = ["optimistic", "kind", "folksy", "persistent"],
                    Role = CharacterRole.Coach,
                    DateOfBirth = "1970-09-22",
                    Email = "ted.lasso@afcrichmond.com",
                    GrowthArcs =
                    [
                        new()
                        {
                            Breakthrough = "Showing vulnerability about his marriage",
                            Challenge = "Earning respect despite inexperience",
                            EndingPoint = "Accepted by the team despite relegation",
                            Season = 1,
                            StartingPoint = "Fish out of water, hiding pain with humor",
                        },
                    ],
                    HeightMeters = 1.83,
                    ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",
                    SalaryGbp = "150000.00",
                    SignatureQuotes = ["I believe in believe.", "Be curious, not judgmental."],
                    TeamID = "afc-richmond",
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CharacterListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "ted-lasso",
                    Background =
                        "Former American football coach from Kansas who moved to London to coach AFC Richmond",
                    EmotionalStats = new()
                    {
                        Curiosity = 99,
                        Empathy = 100,
                        Optimism = 95,
                        Resilience = 90,
                        Vulnerability = 80,
                    },
                    Name = "Ted Lasso",
                    PersonalityTraits = ["optimistic", "kind", "folksy", "persistent"],
                    Role = CharacterRole.Coach,
                    DateOfBirth = "1970-09-22",
                    Email = "ted.lasso@afcrichmond.com",
                    GrowthArcs =
                    [
                        new()
                        {
                            Breakthrough = "Showing vulnerability about his marriage",
                            Challenge = "Earning respect despite inexperience",
                            EndingPoint = "Accepted by the team despite relegation",
                            Season = 1,
                            StartingPoint = "Fish out of water, hiding pain with humor",
                        },
                    ],
                    HeightMeters = 1.83,
                    ProfileImageUrl = "https://afcrichmond.com/images/ted-lasso.jpg",
                    SalaryGbp = "150000.00",
                    SignatureQuotes = ["I believe in believe.", "Be curious, not judgmental."],
                    TeamID = "afc-richmond",
                },
            ],
            HasMore = true,
            Limit = 0,
            Page = 0,
            Pages = 0,
            Skip = 0,
            Total = 0,
        };

        CharacterListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

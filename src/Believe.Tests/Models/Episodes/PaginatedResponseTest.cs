using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Episodes;

namespace Believe.Tests.Models.Episodes;

public class PaginatedResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PaginatedResponse
        {
            Data =
            [
                new()
                {
                    ID = "s01e01",
                    AirDate = "2020-08-14",
                    CharacterFocus =
                    [
                        "ted-lasso", "rebecca-welton", "coach-beard"
                    ],
                    Director = "Tom Marshall",
                    EpisodeNumber = 1,
                    MainTheme = "Taking chances and believing in yourself",
                    RuntimeMinutes = 32,
                    Season = 1,
                    Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",
                    TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",
                    Title = "Pilot",
                    Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",
                    BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",
                    MemorableMoments =
                    [
                        "Ted's first press conference",
                        "The BELIEVE sign goes up",
                        "Ted tastes his first 'garbage water' (English tea)",
                    ],
                    UsViewersMillions = 1.25,
                    ViewerRating = 8.7,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        List<Episode> expectedData =
        [
            new()
            {
                ID = "s01e01",
                AirDate = "2020-08-14",
                CharacterFocus =
                [
                    "ted-lasso", "rebecca-welton", "coach-beard"
                ],
                Director = "Tom Marshall",
                EpisodeNumber = 1,
                MainTheme = "Taking chances and believing in yourself",
                RuntimeMinutes = 32,
                Season = 1,
                Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",
                TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",
                Title = "Pilot",
                Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",
                BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",
                MemorableMoments =
                [
                    "Ted's first press conference",
                    "The BELIEVE sign goes up",
                    "Ted tastes his first 'garbage water' (English tea)",
                ],
                UsViewersMillions = 1.25,
                ViewerRating = 8.7,
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
        var model = new PaginatedResponse
        {
            Data =
            [
                new()
                {
                    ID = "s01e01",
                    AirDate = "2020-08-14",
                    CharacterFocus =
                    [
                        "ted-lasso", "rebecca-welton", "coach-beard"
                    ],
                    Director = "Tom Marshall",
                    EpisodeNumber = 1,
                    MainTheme = "Taking chances and believing in yourself",
                    RuntimeMinutes = 32,
                    Season = 1,
                    Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",
                    TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",
                    Title = "Pilot",
                    Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",
                    BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",
                    MemorableMoments =
                    [
                        "Ted's first press conference",
                        "The BELIEVE sign goes up",
                        "Ted tastes his first 'garbage water' (English tea)",
                    ],
                    UsViewersMillions = 1.25,
                    ViewerRating = 8.7,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedResponse>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PaginatedResponse
        {
            Data =
            [
                new()
                {
                    ID = "s01e01",
                    AirDate = "2020-08-14",
                    CharacterFocus =
                    [
                        "ted-lasso", "rebecca-welton", "coach-beard"
                    ],
                    Director = "Tom Marshall",
                    EpisodeNumber = 1,
                    MainTheme = "Taking chances and believing in yourself",
                    RuntimeMinutes = 32,
                    Season = 1,
                    Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",
                    TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",
                    Title = "Pilot",
                    Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",
                    BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",
                    MemorableMoments =
                    [
                        "Ted's first press conference",
                        "The BELIEVE sign goes up",
                        "Ted tastes his first 'garbage water' (English tea)",
                    ],
                    UsViewersMillions = 1.25,
                    ViewerRating = 8.7,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PaginatedResponse>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Episode> expectedData =
        [
            new()
            {
                ID = "s01e01",
                AirDate = "2020-08-14",
                CharacterFocus =
                [
                    "ted-lasso", "rebecca-welton", "coach-beard"
                ],
                Director = "Tom Marshall",
                EpisodeNumber = 1,
                MainTheme = "Taking chances and believing in yourself",
                RuntimeMinutes = 32,
                Season = 1,
                Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",
                TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",
                Title = "Pilot",
                Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",
                BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",
                MemorableMoments =
                [
                    "Ted's first press conference",
                    "The BELIEVE sign goes up",
                    "Ted tastes his first 'garbage water' (English tea)",
                ],
                UsViewersMillions = 1.25,
                ViewerRating = 8.7,
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
        var model = new PaginatedResponse
        {
            Data =
            [
                new()
                {
                    ID = "s01e01",
                    AirDate = "2020-08-14",
                    CharacterFocus =
                    [
                        "ted-lasso", "rebecca-welton", "coach-beard"
                    ],
                    Director = "Tom Marshall",
                    EpisodeNumber = 1,
                    MainTheme = "Taking chances and believing in yourself",
                    RuntimeMinutes = 32,
                    Season = 1,
                    Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",
                    TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",
                    Title = "Pilot",
                    Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",
                    BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",
                    MemorableMoments =
                    [
                        "Ted's first press conference",
                        "The BELIEVE sign goes up",
                        "Ted tastes his first 'garbage water' (English tea)",
                    ],
                    UsViewersMillions = 1.25,
                    ViewerRating = 8.7,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PaginatedResponse
        {
            Data =
            [
                new()
                {
                    ID = "s01e01",
                    AirDate = "2020-08-14",
                    CharacterFocus =
                    [
                        "ted-lasso", "rebecca-welton", "coach-beard"
                    ],
                    Director = "Tom Marshall",
                    EpisodeNumber = 1,
                    MainTheme = "Taking chances and believing in yourself",
                    RuntimeMinutes = 32,
                    Season = 1,
                    Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",
                    TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",
                    Title = "Pilot",
                    Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",
                    BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",
                    MemorableMoments =
                    [
                        "Ted's first press conference",
                        "The BELIEVE sign goes up",
                        "Ted tastes his first 'garbage water' (English tea)",
                    ],
                    UsViewersMillions = 1.25,
                    ViewerRating = 8.7,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        PaginatedResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
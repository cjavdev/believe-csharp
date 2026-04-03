using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Episodes;

namespace Believe.Tests.Models.Episodes;

public class EpisodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],UsViewersMillions = 1.25,ViewerRating = 8.7,
        };

        string expectedID = "s01e01";
        string expectedAirDate = "2020-08-14";
        List<string> expectedCharacterFocus =
        [
            "ted-lasso", "rebecca-welton", "coach-beard"
        ];
        string expectedDirector = "Tom Marshall";
        long expectedEpisodeNumber = 1;
        string expectedMainTheme = "Taking chances and believing in yourself";
        long expectedRuntimeMinutes = 32;
        long expectedSeason = 1;
        string expectedSynopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.";
        string expectedTedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.";
        string expectedTitle = "Pilot";
        string expectedWriter = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly";
        string expectedBiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.";
        List<string> expectedMemorableMoments =
        [
            "Ted's first press conference",
            "The BELIEVE sign goes up",
            "Ted tastes his first 'garbage water' (English tea)",
        ];
        double expectedUsViewersMillions = 1.25;
        double expectedViewerRating = 8.7;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAirDate, model.AirDate);
        Assert.Equal(expectedCharacterFocus.Count, model.CharacterFocus.Count);
        for (int i = 0; i < expectedCharacterFocus.Count; i++)
        {
            Assert.Equal(expectedCharacterFocus[i], model.CharacterFocus[i]);
        }
        Assert.Equal(expectedDirector, model.Director);
        Assert.Equal(expectedEpisodeNumber, model.EpisodeNumber);
        Assert.Equal(expectedMainTheme, model.MainTheme);
        Assert.Equal(expectedRuntimeMinutes, model.RuntimeMinutes);
        Assert.Equal(expectedSeason, model.Season);
        Assert.Equal(expectedSynopsis, model.Synopsis);
        Assert.Equal(expectedTedWisdom, model.TedWisdom);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedWriter, model.Writer);
        Assert.Equal(expectedBiscuitsWithBossMoment, model.BiscuitsWithBossMoment);
        Assert.NotNull(model.MemorableMoments);
        Assert.Equal(expectedMemorableMoments.Count, model.MemorableMoments.Count);
        for (int i = 0; i < expectedMemorableMoments.Count; i++)
        {
            Assert.Equal(expectedMemorableMoments[i], model.MemorableMoments[i]);
        }
        Assert.Equal(expectedUsViewersMillions, model.UsViewersMillions);
        Assert.Equal(expectedViewerRating, model.ViewerRating);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],UsViewersMillions = 1.25,ViewerRating = 8.7,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Episode>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],UsViewersMillions = 1.25,ViewerRating = 8.7,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Episode>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "s01e01";
        string expectedAirDate = "2020-08-14";
        List<string> expectedCharacterFocus =
        [
            "ted-lasso", "rebecca-welton", "coach-beard"
        ];
        string expectedDirector = "Tom Marshall";
        long expectedEpisodeNumber = 1;
        string expectedMainTheme = "Taking chances and believing in yourself";
        long expectedRuntimeMinutes = 32;
        long expectedSeason = 1;
        string expectedSynopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.";
        string expectedTedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.";
        string expectedTitle = "Pilot";
        string expectedWriter = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly";
        string expectedBiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.";
        List<string> expectedMemorableMoments =
        [
            "Ted's first press conference",
            "The BELIEVE sign goes up",
            "Ted tastes his first 'garbage water' (English tea)",
        ];
        double expectedUsViewersMillions = 1.25;
        double expectedViewerRating = 8.7;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAirDate, deserialized.AirDate);
        Assert.Equal(expectedCharacterFocus.Count, deserialized.CharacterFocus.Count);
        for (int i = 0; i < expectedCharacterFocus.Count; i++)
        {
            Assert.Equal(expectedCharacterFocus[i], deserialized.CharacterFocus[i]);
        }
        Assert.Equal(expectedDirector, deserialized.Director);
        Assert.Equal(expectedEpisodeNumber, deserialized.EpisodeNumber);
        Assert.Equal(expectedMainTheme, deserialized.MainTheme);
        Assert.Equal(expectedRuntimeMinutes, deserialized.RuntimeMinutes);
        Assert.Equal(expectedSeason, deserialized.Season);
        Assert.Equal(expectedSynopsis, deserialized.Synopsis);
        Assert.Equal(expectedTedWisdom, deserialized.TedWisdom);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedWriter, deserialized.Writer);
        Assert.Equal(expectedBiscuitsWithBossMoment, deserialized.BiscuitsWithBossMoment);
        Assert.NotNull(deserialized.MemorableMoments);
        Assert.Equal(expectedMemorableMoments.Count, deserialized.MemorableMoments.Count);
        for (int i = 0; i < expectedMemorableMoments.Count; i++)
        {
            Assert.Equal(expectedMemorableMoments[i], deserialized.MemorableMoments[i]);
        }
        Assert.Equal(expectedUsViewersMillions, deserialized.UsViewersMillions);
        Assert.Equal(expectedViewerRating, deserialized.ViewerRating);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],UsViewersMillions = 1.25,ViewerRating = 8.7,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",UsViewersMillions = 1.25,ViewerRating = 8.7,
        };

        Assert.Null(model.MemorableMoments);
        Assert.False(model.RawData.ContainsKey("memorable_moments"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",UsViewersMillions = 1.25,ViewerRating = 8.7,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",UsViewersMillions = 1.25,ViewerRating = 8.7,

            // Null should be interpreted as omitted for these properties
            MemorableMoments = null,
        };

        Assert.Null(model.MemorableMoments);
        Assert.False(model.RawData.ContainsKey("memorable_moments"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",UsViewersMillions = 1.25,ViewerRating = 8.7,

            // Null should be interpreted as omitted for these properties
            MemorableMoments = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],
        };

        Assert.Null(model.BiscuitsWithBossMoment);
        Assert.False(model.RawData.ContainsKey("biscuits_with_boss_moment"));Assert.Null(model.UsViewersMillions);
        Assert.False(model.RawData.ContainsKey("us_viewers_millions"));Assert.Null(model.ViewerRating);
        Assert.False(model.RawData.ContainsKey("viewer_rating"));

    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],

            BiscuitsWithBossMoment = null,UsViewersMillions = null,ViewerRating = null,
        };

        Assert.Null(model.BiscuitsWithBossMoment);
        Assert.True(model.RawData.ContainsKey("biscuits_with_boss_moment"));Assert.Null(model.UsViewersMillions);
        Assert.True(model.RawData.ContainsKey("us_viewers_millions"));Assert.Null(model.ViewerRating);
        Assert.True(model.RawData.ContainsKey("viewer_rating"));

    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],

            BiscuitsWithBossMoment = null,UsViewersMillions = null,ViewerRating = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Episode
        {
            ID = "s01e01",AirDate = "2020-08-14",CharacterFocus =
            [
                "ted-lasso", "rebecca-welton", "coach-beard"
            ],Director = "Tom Marshall",EpisodeNumber = 1,MainTheme = "Taking chances and believing in yourself",RuntimeMinutes = 32,Season = 1,Synopsis = "American football coach Ted Lasso is hired to manage AFC Richmond, a struggling English Premier League team.",TedWisdom = "Taking on a challenge is a lot like riding a horse. If you're comfortable while you're doing it, you're probably doing it wrong.",Title = "Pilot",Writer = "Jason Sudeikis, Bill Lawrence, Brendan Hunt, Joe Kelly",BiscuitsWithBossMoment = "Ted brings Rebecca homemade biscuits for the first time.",MemorableMoments =
            [
                "Ted's first press conference",
                "The BELIEVE sign goes up",
                "Ted tastes his first 'garbage water' (English tea)",
            ],UsViewersMillions = 1.25,ViewerRating = 8.7,
        };

        Episode copied = new(model);

        Assert.Equal(model, copied);
    }
}
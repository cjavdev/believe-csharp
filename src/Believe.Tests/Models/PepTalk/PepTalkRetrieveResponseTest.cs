using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.PepTalk;

namespace Believe.Tests.Models.PepTalk;

public class PepTalkRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PepTalkRetrieveResponse
        {
            Chunks =
            [
                new()
                {
                    ChunkID = 1,
                    IsFinal = false,
                    Text = "Hey there, friend. ",
                    EmotionalBeat = "connection",
                },
                new()
                {
                    ChunkID = 2,
                    IsFinal = false,
                    Text = "I know things feel tough right now. ",
                    EmotionalBeat = "acknowledgment",
                },
                new()
                {
                    ChunkID = 3,
                    IsFinal = false,
                    Text = "And that's the thing about hard times - they're like a good barbecue rub. ",
                    EmotionalBeat = "building_metaphor",
                },
                new()
                {
                    ChunkID = 4,
                    IsFinal = false,
                    Text = "They might sting at first, but they're what give you flavor. ",
                    EmotionalBeat = "wisdom",
                },
                new()
                {
                    ChunkID = 5,
                    IsFinal = true,
                    Text = "You got this.",
                    EmotionalBeat = "encouragement",
                },
            ],Text = "Hey there, friend. I know things feel tough right now. And that's the thing about hard times - they're like a good barbecue rub. They might sting at first, but they're what give you flavor. You got this.",
        };

        List<Chunk> expectedChunks =
        [
            new()
            {
                ChunkID = 1,
                IsFinal = false,
                Text = "Hey there, friend. ",
                EmotionalBeat = "connection",
            },
            new()
            {
                ChunkID = 2,
                IsFinal = false,
                Text = "I know things feel tough right now. ",
                EmotionalBeat = "acknowledgment",
            },
            new()
            {
                ChunkID = 3,
                IsFinal = false,
                Text = "And that's the thing about hard times - they're like a good barbecue rub. ",
                EmotionalBeat = "building_metaphor",
            },
            new()
            {
                ChunkID = 4,
                IsFinal = false,
                Text = "They might sting at first, but they're what give you flavor. ",
                EmotionalBeat = "wisdom",
            },
            new()
            {
                ChunkID = 5,
                IsFinal = true,
                Text = "You got this.",
                EmotionalBeat = "encouragement",
            },
        ];
        string expectedText = "Hey there, friend. I know things feel tough right now. And that's the thing about hard times - they're like a good barbecue rub. They might sting at first, but they're what give you flavor. You got this.";

        Assert.Equal(expectedChunks.Count, model.Chunks.Count);
        for (int i = 0; i < expectedChunks.Count; i++)
        {
            Assert.Equal(expectedChunks[i], model.Chunks[i]);
        }
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PepTalkRetrieveResponse
        {
            Chunks =
            [
                new()
                {
                    ChunkID = 1,
                    IsFinal = false,
                    Text = "Hey there, friend. ",
                    EmotionalBeat = "connection",
                },
                new()
                {
                    ChunkID = 2,
                    IsFinal = false,
                    Text = "I know things feel tough right now. ",
                    EmotionalBeat = "acknowledgment",
                },
                new()
                {
                    ChunkID = 3,
                    IsFinal = false,
                    Text = "And that's the thing about hard times - they're like a good barbecue rub. ",
                    EmotionalBeat = "building_metaphor",
                },
                new()
                {
                    ChunkID = 4,
                    IsFinal = false,
                    Text = "They might sting at first, but they're what give you flavor. ",
                    EmotionalBeat = "wisdom",
                },
                new()
                {
                    ChunkID = 5,
                    IsFinal = true,
                    Text = "You got this.",
                    EmotionalBeat = "encouragement",
                },
            ],Text = "Hey there, friend. I know things feel tough right now. And that's the thing about hard times - they're like a good barbecue rub. They might sting at first, but they're what give you flavor. You got this.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PepTalkRetrieveResponse>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PepTalkRetrieveResponse
        {
            Chunks =
            [
                new()
                {
                    ChunkID = 1,
                    IsFinal = false,
                    Text = "Hey there, friend. ",
                    EmotionalBeat = "connection",
                },
                new()
                {
                    ChunkID = 2,
                    IsFinal = false,
                    Text = "I know things feel tough right now. ",
                    EmotionalBeat = "acknowledgment",
                },
                new()
                {
                    ChunkID = 3,
                    IsFinal = false,
                    Text = "And that's the thing about hard times - they're like a good barbecue rub. ",
                    EmotionalBeat = "building_metaphor",
                },
                new()
                {
                    ChunkID = 4,
                    IsFinal = false,
                    Text = "They might sting at first, but they're what give you flavor. ",
                    EmotionalBeat = "wisdom",
                },
                new()
                {
                    ChunkID = 5,
                    IsFinal = true,
                    Text = "You got this.",
                    EmotionalBeat = "encouragement",
                },
            ],Text = "Hey there, friend. I know things feel tough right now. And that's the thing about hard times - they're like a good barbecue rub. They might sting at first, but they're what give you flavor. You got this.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PepTalkRetrieveResponse>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Chunk> expectedChunks =
        [
            new()
            {
                ChunkID = 1,
                IsFinal = false,
                Text = "Hey there, friend. ",
                EmotionalBeat = "connection",
            },
            new()
            {
                ChunkID = 2,
                IsFinal = false,
                Text = "I know things feel tough right now. ",
                EmotionalBeat = "acknowledgment",
            },
            new()
            {
                ChunkID = 3,
                IsFinal = false,
                Text = "And that's the thing about hard times - they're like a good barbecue rub. ",
                EmotionalBeat = "building_metaphor",
            },
            new()
            {
                ChunkID = 4,
                IsFinal = false,
                Text = "They might sting at first, but they're what give you flavor. ",
                EmotionalBeat = "wisdom",
            },
            new()
            {
                ChunkID = 5,
                IsFinal = true,
                Text = "You got this.",
                EmotionalBeat = "encouragement",
            },
        ];
        string expectedText = "Hey there, friend. I know things feel tough right now. And that's the thing about hard times - they're like a good barbecue rub. They might sting at first, but they're what give you flavor. You got this.";

        Assert.Equal(expectedChunks.Count, deserialized.Chunks.Count);
        for (int i = 0; i < expectedChunks.Count; i++)
        {
            Assert.Equal(expectedChunks[i], deserialized.Chunks[i]);
        }
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PepTalkRetrieveResponse
        {
            Chunks =
            [
                new()
                {
                    ChunkID = 1,
                    IsFinal = false,
                    Text = "Hey there, friend. ",
                    EmotionalBeat = "connection",
                },
                new()
                {
                    ChunkID = 2,
                    IsFinal = false,
                    Text = "I know things feel tough right now. ",
                    EmotionalBeat = "acknowledgment",
                },
                new()
                {
                    ChunkID = 3,
                    IsFinal = false,
                    Text = "And that's the thing about hard times - they're like a good barbecue rub. ",
                    EmotionalBeat = "building_metaphor",
                },
                new()
                {
                    ChunkID = 4,
                    IsFinal = false,
                    Text = "They might sting at first, but they're what give you flavor. ",
                    EmotionalBeat = "wisdom",
                },
                new()
                {
                    ChunkID = 5,
                    IsFinal = true,
                    Text = "You got this.",
                    EmotionalBeat = "encouragement",
                },
            ],Text = "Hey there, friend. I know things feel tough right now. And that's the thing about hard times - they're like a good barbecue rub. They might sting at first, but they're what give you flavor. You got this.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PepTalkRetrieveResponse
        {
            Chunks =
            [
                new()
                {
                    ChunkID = 1,
                    IsFinal = false,
                    Text = "Hey there, friend. ",
                    EmotionalBeat = "connection",
                },
                new()
                {
                    ChunkID = 2,
                    IsFinal = false,
                    Text = "I know things feel tough right now. ",
                    EmotionalBeat = "acknowledgment",
                },
                new()
                {
                    ChunkID = 3,
                    IsFinal = false,
                    Text = "And that's the thing about hard times - they're like a good barbecue rub. ",
                    EmotionalBeat = "building_metaphor",
                },
                new()
                {
                    ChunkID = 4,
                    IsFinal = false,
                    Text = "They might sting at first, but they're what give you flavor. ",
                    EmotionalBeat = "wisdom",
                },
                new()
                {
                    ChunkID = 5,
                    IsFinal = true,
                    Text = "You got this.",
                    EmotionalBeat = "encouragement",
                },
            ],Text = "Hey there, friend. I know things feel tough right now. And that's the thing about hard times - they're like a good barbecue rub. They might sting at first, but they're what give you flavor. You got this.",
        };

        PepTalkRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChunkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",EmotionalBeat = "emotional_beat",
        };

        long expectedChunkID = 0;
        bool expectedIsFinal = true;
        string expectedText = "text";
        string expectedEmotionalBeat = "emotional_beat";

        Assert.Equal(expectedChunkID, model.ChunkID);
        Assert.Equal(expectedIsFinal, model.IsFinal);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedEmotionalBeat, model.EmotionalBeat);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",EmotionalBeat = "emotional_beat",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chunk>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",EmotionalBeat = "emotional_beat",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Chunk>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedChunkID = 0;
        bool expectedIsFinal = true;
        string expectedText = "text";
        string expectedEmotionalBeat = "emotional_beat";

        Assert.Equal(expectedChunkID, deserialized.ChunkID);
        Assert.Equal(expectedIsFinal, deserialized.IsFinal);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedEmotionalBeat, deserialized.EmotionalBeat);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",EmotionalBeat = "emotional_beat",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",
        };

        Assert.Null(model.EmotionalBeat);
        Assert.False(model.RawData.ContainsKey("emotional_beat"));

    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",

            EmotionalBeat = null,
        };

        Assert.Null(model.EmotionalBeat);
        Assert.True(model.RawData.ContainsKey("emotional_beat"));

    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",

            EmotionalBeat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Chunk
        {
            ChunkID = 0,IsFinal = true,Text = "text",EmotionalBeat = "emotional_beat",
        };

        Chunk copied = new(model);

        Assert.Equal(model, copied);
    }
}
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Biscuits;

namespace Believe.Tests.Models.Biscuits;

public class BiscuitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Biscuit
        {
            ID = "biscuit-001",
            Message = "Sometimes the best thing you can do is just show up with something warm.",
            PairsWellWith = "A hot cup of tea and an honest conversation",
            TedNote =
                "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
            Type = Type.Shortbread,
            WarmthLevel = 9,
        };

        string expectedID = "biscuit-001";
        string expectedMessage =
            "Sometimes the best thing you can do is just show up with something warm.";
        string expectedPairsWellWith = "A hot cup of tea and an honest conversation";
        string expectedTedNote =
            "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted";
        ApiEnum<string, Type> expectedType = Type.Shortbread;
        long expectedWarmthLevel = 9;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedPairsWellWith, model.PairsWellWith);
        Assert.Equal(expectedTedNote, model.TedNote);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWarmthLevel, model.WarmthLevel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Biscuit
        {
            ID = "biscuit-001",
            Message = "Sometimes the best thing you can do is just show up with something warm.",
            PairsWellWith = "A hot cup of tea and an honest conversation",
            TedNote =
                "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
            Type = Type.Shortbread,
            WarmthLevel = 9,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Biscuit>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Biscuit
        {
            ID = "biscuit-001",
            Message = "Sometimes the best thing you can do is just show up with something warm.",
            PairsWellWith = "A hot cup of tea and an honest conversation",
            TedNote =
                "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
            Type = Type.Shortbread,
            WarmthLevel = 9,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Biscuit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "biscuit-001";
        string expectedMessage =
            "Sometimes the best thing you can do is just show up with something warm.";
        string expectedPairsWellWith = "A hot cup of tea and an honest conversation";
        string expectedTedNote =
            "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted";
        ApiEnum<string, Type> expectedType = Type.Shortbread;
        long expectedWarmthLevel = 9;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedPairsWellWith, deserialized.PairsWellWith);
        Assert.Equal(expectedTedNote, deserialized.TedNote);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWarmthLevel, deserialized.WarmthLevel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Biscuit
        {
            ID = "biscuit-001",
            Message = "Sometimes the best thing you can do is just show up with something warm.",
            PairsWellWith = "A hot cup of tea and an honest conversation",
            TedNote =
                "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
            Type = Type.Shortbread,
            WarmthLevel = 9,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Biscuit
        {
            ID = "biscuit-001",
            Message = "Sometimes the best thing you can do is just show up with something warm.",
            PairsWellWith = "A hot cup of tea and an honest conversation",
            TedNote =
                "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
            Type = Type.Shortbread,
            WarmthLevel = 9,
        };

        Biscuit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.Classic)]
    [InlineData(Type.Shortbread)]
    [InlineData(Type.ChocolateChip)]
    [InlineData(Type.OatmealRaisin)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.Classic)]
    [InlineData(Type.Shortbread)]
    [InlineData(Type.ChocolateChip)]
    [InlineData(Type.OatmealRaisin)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

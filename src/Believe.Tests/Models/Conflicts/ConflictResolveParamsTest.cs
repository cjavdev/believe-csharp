using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Conflicts;

namespace Believe.Tests.Models.Conflicts;

public class ConflictResolveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConflictResolveParams
        {
            ConflictType = ConflictType.Interpersonal,
            Description =
                "Alex keeps taking credit for my ideas in meetings and I'm getting resentful.",
            PartiesInvolved = ["Me", "My teammate Alex"],
            AttemptsMade = ["Mentioned it casually", "Avoided them"],
        };

        ApiEnum<string, ConflictType> expectedConflictType = ConflictType.Interpersonal;
        string expectedDescription =
            "Alex keeps taking credit for my ideas in meetings and I'm getting resentful.";
        List<string> expectedPartiesInvolved = ["Me", "My teammate Alex"];
        List<string> expectedAttemptsMade = ["Mentioned it casually", "Avoided them"];

        Assert.Equal(expectedConflictType, parameters.ConflictType);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedPartiesInvolved.Count, parameters.PartiesInvolved.Count);
        for (int i = 0; i < expectedPartiesInvolved.Count; i++)
        {
            Assert.Equal(expectedPartiesInvolved[i], parameters.PartiesInvolved[i]);
        }
        Assert.NotNull(parameters.AttemptsMade);
        Assert.Equal(expectedAttemptsMade.Count, parameters.AttemptsMade.Count);
        for (int i = 0; i < expectedAttemptsMade.Count; i++)
        {
            Assert.Equal(expectedAttemptsMade[i], parameters.AttemptsMade[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConflictResolveParams
        {
            ConflictType = ConflictType.Interpersonal,
            Description =
                "Alex keeps taking credit for my ideas in meetings and I'm getting resentful.",
            PartiesInvolved = ["Me", "My teammate Alex"],
        };

        Assert.Null(parameters.AttemptsMade);
        Assert.False(parameters.RawBodyData.ContainsKey("attempts_made"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ConflictResolveParams
        {
            ConflictType = ConflictType.Interpersonal,
            Description =
                "Alex keeps taking credit for my ideas in meetings and I'm getting resentful.",
            PartiesInvolved = ["Me", "My teammate Alex"],

            AttemptsMade = null,
        };

        Assert.Null(parameters.AttemptsMade);
        Assert.True(parameters.RawBodyData.ContainsKey("attempts_made"));
    }

    [Fact]
    public void Url_Works()
    {
        ConflictResolveParams parameters = new()
        {
            ConflictType = ConflictType.Interpersonal,
            Description =
                "Alex keeps taking credit for my ideas in meetings and I'm getting resentful.",
            PartiesInvolved = ["Me", "My teammate Alex"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/conflicts/resolve"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConflictResolveParams
        {
            ConflictType = ConflictType.Interpersonal,
            Description =
                "Alex keeps taking credit for my ideas in meetings and I'm getting resentful.",
            PartiesInvolved = ["Me", "My teammate Alex"],
            AttemptsMade = ["Mentioned it casually", "Avoided them"],
        };

        ConflictResolveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConflictTypeTest : TestBase
{
    [Theory]
    [InlineData(ConflictType.Interpersonal)]
    [InlineData(ConflictType.TeamDynamics)]
    [InlineData(ConflictType.Leadership)]
    [InlineData(ConflictType.Ego)]
    [InlineData(ConflictType.Miscommunication)]
    [InlineData(ConflictType.Competition)]
    public void Validation_Works(ConflictType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConflictType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConflictType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ConflictType.Interpersonal)]
    [InlineData(ConflictType.TeamDynamics)]
    [InlineData(ConflictType.Leadership)]
    [InlineData(ConflictType.Ego)]
    [InlineData(ConflictType.Miscommunication)]
    [InlineData(ConflictType.Competition)]
    public void SerializationRoundtrip_Works(ConflictType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ConflictType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConflictType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ConflictType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ConflictType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

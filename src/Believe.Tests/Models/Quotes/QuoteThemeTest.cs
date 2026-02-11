using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteThemeTest : TestBase
{
    [Theory]
    [InlineData(QuoteTheme.Belief)]
    [InlineData(QuoteTheme.Teamwork)]
    [InlineData(QuoteTheme.Curiosity)]
    [InlineData(QuoteTheme.Kindness)]
    [InlineData(QuoteTheme.Resilience)]
    [InlineData(QuoteTheme.Vulnerability)]
    [InlineData(QuoteTheme.Growth)]
    [InlineData(QuoteTheme.Humor)]
    [InlineData(QuoteTheme.Wisdom)]
    [InlineData(QuoteTheme.Leadership)]
    [InlineData(QuoteTheme.Love)]
    [InlineData(QuoteTheme.Forgiveness)]
    [InlineData(QuoteTheme.Philosophy)]
    [InlineData(QuoteTheme.Romance)]
    [InlineData(QuoteTheme.CulturalPride)]
    [InlineData(QuoteTheme.CulturalDifferences)]
    [InlineData(QuoteTheme.Antagonism)]
    [InlineData(QuoteTheme.Celebration)]
    [InlineData(QuoteTheme.Identity)]
    [InlineData(QuoteTheme.Isolation)]
    [InlineData(QuoteTheme.Power)]
    [InlineData(QuoteTheme.Sacrifice)]
    [InlineData(QuoteTheme.Standards)]
    [InlineData(QuoteTheme.Confidence)]
    [InlineData(QuoteTheme.Conflict)]
    [InlineData(QuoteTheme.Honesty)]
    [InlineData(QuoteTheme.Integrity)]
    public void Validation_Works(QuoteTheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, QuoteTheme> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, QuoteTheme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(QuoteTheme.Belief)]
    [InlineData(QuoteTheme.Teamwork)]
    [InlineData(QuoteTheme.Curiosity)]
    [InlineData(QuoteTheme.Kindness)]
    [InlineData(QuoteTheme.Resilience)]
    [InlineData(QuoteTheme.Vulnerability)]
    [InlineData(QuoteTheme.Growth)]
    [InlineData(QuoteTheme.Humor)]
    [InlineData(QuoteTheme.Wisdom)]
    [InlineData(QuoteTheme.Leadership)]
    [InlineData(QuoteTheme.Love)]
    [InlineData(QuoteTheme.Forgiveness)]
    [InlineData(QuoteTheme.Philosophy)]
    [InlineData(QuoteTheme.Romance)]
    [InlineData(QuoteTheme.CulturalPride)]
    [InlineData(QuoteTheme.CulturalDifferences)]
    [InlineData(QuoteTheme.Antagonism)]
    [InlineData(QuoteTheme.Celebration)]
    [InlineData(QuoteTheme.Identity)]
    [InlineData(QuoteTheme.Isolation)]
    [InlineData(QuoteTheme.Power)]
    [InlineData(QuoteTheme.Sacrifice)]
    [InlineData(QuoteTheme.Standards)]
    [InlineData(QuoteTheme.Confidence)]
    [InlineData(QuoteTheme.Conflict)]
    [InlineData(QuoteTheme.Honesty)]
    [InlineData(QuoteTheme.Integrity)]
    public void SerializationRoundtrip_Works(QuoteTheme rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, QuoteTheme> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, QuoteTheme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, QuoteTheme>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, QuoteTheme>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Characters;

namespace Believe.Tests.Models.Characters;

public class CharacterRoleTest : TestBase
{
    [Theory]
    [InlineData(CharacterRole.Coach)]
    [InlineData(CharacterRole.Player)]
    [InlineData(CharacterRole.Owner)]
    [InlineData(CharacterRole.Manager)]
    [InlineData(CharacterRole.Staff)]
    [InlineData(CharacterRole.Journalist)]
    [InlineData(CharacterRole.Family)]
    [InlineData(CharacterRole.Friend)]
    [InlineData(CharacterRole.Fan)]
    [InlineData(CharacterRole.Other)]
    public void Validation_Works(CharacterRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CharacterRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CharacterRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CharacterRole.Coach)]
    [InlineData(CharacterRole.Player)]
    [InlineData(CharacterRole.Owner)]
    [InlineData(CharacterRole.Manager)]
    [InlineData(CharacterRole.Staff)]
    [InlineData(CharacterRole.Journalist)]
    [InlineData(CharacterRole.Family)]
    [InlineData(CharacterRole.Friend)]
    [InlineData(CharacterRole.Fan)]
    [InlineData(CharacterRole.Other)]
    public void SerializationRoundtrip_Works(CharacterRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CharacterRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CharacterRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CharacterRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CharacterRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

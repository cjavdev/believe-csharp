using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.Characters;

/// <summary>
/// Roles characters can have.
/// </summary>
[JsonConverter(typeof(CharacterRoleConverter))]
public enum CharacterRole
{
    Coach, Player, Owner, Manager, Staff, Journalist, Family, Friend, Fan, Other
}

sealed class CharacterRoleConverter : JsonConverter<CharacterRole>
{
    public override CharacterRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "coach"=>CharacterRole.Coach,
            "player"=>CharacterRole.Player,
            "owner"=>CharacterRole.Owner,
            "manager"=>CharacterRole.Manager,
            "staff"=>CharacterRole.Staff,
            "journalist"=>CharacterRole.Journalist,
            "family"=>CharacterRole.Family,
            "friend"=>CharacterRole.Friend,
            "fan"=>CharacterRole.Fan,
            "other"=>CharacterRole.Other,
            _ =>(CharacterRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CharacterRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CharacterRole.Coach=>"coach",
            CharacterRole.Player=>"player",
            CharacterRole.Owner=>"owner",
            CharacterRole.Manager=>"manager",
            CharacterRole.Staff=>"staff",
            CharacterRole.Journalist=>"journalist",
            CharacterRole.Family=>"family",
            CharacterRole.Friend=>"friend",
            CharacterRole.Fan=>"fan",
            CharacterRole.Other=>"other",
            _ => throw new BelieveInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}
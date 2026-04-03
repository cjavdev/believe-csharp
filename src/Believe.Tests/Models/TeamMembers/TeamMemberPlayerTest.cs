using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class TeamMemberPlayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,Assists = 23,GoalsScored = 47,IsCaptain = false,MemberType = TeamMemberPlayerMemberType.Player,
        };

        string expectedID = "jamie-tartt-richmond";
        string expectedCharacterID = "jamie-tartt";
        long expectedJerseyNumber = 9;
        ApiEnum<string, Position> expectedPosition = Position.Forward;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        long expectedAssists = 23;
        long expectedGoalsScored = 47;
        bool expectedIsCaptain = false;
        ApiEnum<string, TeamMemberPlayerMemberType> expectedMemberType = TeamMemberPlayerMemberType.Player;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCharacterID, model.CharacterID);
        Assert.Equal(expectedJerseyNumber, model.JerseyNumber);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
        Assert.Equal(expectedAssists, model.Assists);
        Assert.Equal(expectedGoalsScored, model.GoalsScored);
        Assert.Equal(expectedIsCaptain, model.IsCaptain);
        Assert.Equal(expectedMemberType, model.MemberType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,Assists = 23,GoalsScored = 47,IsCaptain = false,MemberType = TeamMemberPlayerMemberType.Player,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberPlayer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,Assists = 23,GoalsScored = 47,IsCaptain = false,MemberType = TeamMemberPlayerMemberType.Player,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberPlayer>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "jamie-tartt-richmond";
        string expectedCharacterID = "jamie-tartt";
        long expectedJerseyNumber = 9;
        ApiEnum<string, Position> expectedPosition = Position.Forward;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        long expectedAssists = 23;
        long expectedGoalsScored = 47;
        bool expectedIsCaptain = false;
        ApiEnum<string, TeamMemberPlayerMemberType> expectedMemberType = TeamMemberPlayerMemberType.Player;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCharacterID, deserialized.CharacterID);
        Assert.Equal(expectedJerseyNumber, deserialized.JerseyNumber);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
        Assert.Equal(expectedAssists, deserialized.Assists);
        Assert.Equal(expectedGoalsScored, deserialized.GoalsScored);
        Assert.Equal(expectedIsCaptain, deserialized.IsCaptain);
        Assert.Equal(expectedMemberType, deserialized.MemberType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,Assists = 23,GoalsScored = 47,IsCaptain = false,MemberType = TeamMemberPlayerMemberType.Player,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,
        };

        Assert.Null(model.Assists);
        Assert.False(model.RawData.ContainsKey("assists"));Assert.Null(model.GoalsScored);
        Assert.False(model.RawData.ContainsKey("goals_scored"));Assert.Null(model.IsCaptain);
        Assert.False(model.RawData.ContainsKey("is_captain"));Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,

            // Null should be interpreted as omitted for these properties
            Assists = null,GoalsScored = null,IsCaptain = null,MemberType = null,
        };

        Assert.Null(model.Assists);
        Assert.False(model.RawData.ContainsKey("assists"));Assert.Null(model.GoalsScored);
        Assert.False(model.RawData.ContainsKey("goals_scored"));Assert.Null(model.IsCaptain);
        Assert.False(model.RawData.ContainsKey("is_captain"));Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,

            // Null should be interpreted as omitted for these properties
            Assists = null,GoalsScored = null,IsCaptain = null,MemberType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberPlayer
        {
            ID = "jamie-tartt-richmond",CharacterID = "jamie-tartt",JerseyNumber = 9,Position = Position.Forward,TeamID = "afc-richmond",YearsWithTeam = 3,Assists = 23,GoalsScored = 47,IsCaptain = false,MemberType = TeamMemberPlayerMemberType.Player,
        };

        TeamMemberPlayer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamMemberPlayerMemberTypeTest : TestBase
{
    [Theory][InlineData(TeamMemberPlayerMemberType.Player)]
    public void Validation_Works(TeamMemberPlayerMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberPlayerMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberPlayerMemberType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(TeamMemberPlayerMemberType.Player)]
    public void SerializationRoundtrip_Works(
        TeamMemberPlayerMemberType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberPlayerMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberPlayerMemberType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberPlayerMemberType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberPlayerMemberType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
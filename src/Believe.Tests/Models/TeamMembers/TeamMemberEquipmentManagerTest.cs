using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class TeamMemberEquipmentManagerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,IsHeadKitman = true,MemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager,Responsibilities =
            [
                "Kit preparation", "Equipment maintenance"
            ],
        };

        string expectedID = "nate-kitman-richmond";
        string expectedCharacterID = "nathan-shelley";
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 5;
        bool expectedIsHeadKitman = true;
        ApiEnum<string, TeamMemberEquipmentManagerMemberType> expectedMemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager;
        List<string> expectedResponsibilities =
        [
            "Kit preparation", "Equipment maintenance"
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCharacterID, model.CharacterID);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
        Assert.Equal(expectedIsHeadKitman, model.IsHeadKitman);
        Assert.Equal(expectedMemberType, model.MemberType);
        Assert.NotNull(model.Responsibilities);
        Assert.Equal(expectedResponsibilities.Count, model.Responsibilities.Count);
        for (int i = 0; i < expectedResponsibilities.Count; i++)
        {
            Assert.Equal(expectedResponsibilities[i], model.Responsibilities[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,IsHeadKitman = true,MemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager,Responsibilities =
            [
                "Kit preparation", "Equipment maintenance"
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberEquipmentManager>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,IsHeadKitman = true,MemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager,Responsibilities =
            [
                "Kit preparation", "Equipment maintenance"
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberEquipmentManager>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "nate-kitman-richmond";
        string expectedCharacterID = "nathan-shelley";
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 5;
        bool expectedIsHeadKitman = true;
        ApiEnum<string, TeamMemberEquipmentManagerMemberType> expectedMemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager;
        List<string> expectedResponsibilities =
        [
            "Kit preparation", "Equipment maintenance"
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCharacterID, deserialized.CharacterID);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
        Assert.Equal(expectedIsHeadKitman, deserialized.IsHeadKitman);
        Assert.Equal(expectedMemberType, deserialized.MemberType);
        Assert.NotNull(deserialized.Responsibilities);
        Assert.Equal(expectedResponsibilities.Count, deserialized.Responsibilities.Count);
        for (int i = 0; i < expectedResponsibilities.Count; i++)
        {
            Assert.Equal(expectedResponsibilities[i], deserialized.Responsibilities[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,IsHeadKitman = true,MemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager,Responsibilities =
            [
                "Kit preparation", "Equipment maintenance"
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,
        };

        Assert.Null(model.IsHeadKitman);
        Assert.False(model.RawData.ContainsKey("is_head_kitman"));Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));Assert.Null(model.Responsibilities);
        Assert.False(model.RawData.ContainsKey("responsibilities"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,

            // Null should be interpreted as omitted for these properties
            IsHeadKitman = null,MemberType = null,Responsibilities = null,
        };

        Assert.Null(model.IsHeadKitman);
        Assert.False(model.RawData.ContainsKey("is_head_kitman"));Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));Assert.Null(model.Responsibilities);
        Assert.False(model.RawData.ContainsKey("responsibilities"));

    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,

            // Null should be interpreted as omitted for these properties
            IsHeadKitman = null,MemberType = null,Responsibilities = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberEquipmentManager
        {
            ID = "nate-kitman-richmond",CharacterID = "nathan-shelley",TeamID = "afc-richmond",YearsWithTeam = 5,IsHeadKitman = true,MemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager,Responsibilities =
            [
                "Kit preparation", "Equipment maintenance"
            ],
        };

        TeamMemberEquipmentManager copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamMemberEquipmentManagerMemberTypeTest : TestBase
{
    [Theory][InlineData(TeamMemberEquipmentManagerMemberType.EquipmentManager)]
    public void Validation_Works(TeamMemberEquipmentManagerMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberEquipmentManagerMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberEquipmentManagerMemberType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory][InlineData(TeamMemberEquipmentManagerMemberType.EquipmentManager)]
    public void SerializationRoundtrip_Works(
        TeamMemberEquipmentManagerMemberType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberEquipmentManagerMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberEquipmentManagerMemberType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberEquipmentManagerMemberType>>(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberEquipmentManagerMemberType>>(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
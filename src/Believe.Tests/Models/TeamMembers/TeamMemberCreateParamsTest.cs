using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class TeamMemberCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamMemberCreateParams
        {
            Member = new Player()
            {
                CharacterID = "jamie-tartt",
                JerseyNumber = 9,
                Position = Position.Forward,
                TeamID = "afc-richmond",
                YearsWithTeam = 3,
                Assists = 23,
                GoalsScored = 47,
                IsCaptain = false,
                MemberType = MemberType.Player,
            },
        };

        Member expectedMember = new Player()
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };

        Assert.Equal(expectedMember, parameters.Member);
    }

    [Fact]
    public void Url_Works()
    {
        TeamMemberCreateParams parameters = new()
        {
            Member = new Player()
            {
                CharacterID = "jamie-tartt",
                JerseyNumber = 9,
                Position = Position.Forward,
                TeamID = "afc-richmond",
                YearsWithTeam = 3,
                Assists = 23,
                GoalsScored = 47,
                IsCaptain = false,
                MemberType = MemberType.Player,
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/team-members"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamMemberCreateParams
        {
            Member = new Player()
            {
                CharacterID = "jamie-tartt",
                JerseyNumber = 9,
                Position = Position.Forward,
                TeamID = "afc-richmond",
                YearsWithTeam = 3,
                Assists = 23,
                GoalsScored = 47,
                IsCaptain = false,
                MemberType = MemberType.Player,
            },
        };

        TeamMemberCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MemberTest : TestBase
{
    [Fact]
    public void PlayerValidationWorks()
    {
        Member value = new Player()
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };
        value.Validate();
    }

    [Fact]
    public void CoachValidationWorks()
    {
        Member value = new Coach()
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
            WinRate = 0.65,
        };
        value.Validate();
    }

    [Fact]
    public void MedicalStaffValidationWorks()
    {
        Member value = new MedicalStaff()
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };
        value.Validate();
    }

    [Fact]
    public void EquipmentManagerValidationWorks()
    {
        Member value = new EquipmentManager()
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            IsHeadKitman = true,
            MemberType = EquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };
        value.Validate();
    }

    [Fact]
    public void PlayerSerializationRoundtripWorks()
    {
        Member value = new Player()
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Member>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CoachSerializationRoundtripWorks()
    {
        Member value = new Coach()
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
            WinRate = 0.65,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Member>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MedicalStaffSerializationRoundtripWorks()
    {
        Member value = new MedicalStaff()
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Member>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EquipmentManagerSerializationRoundtripWorks()
    {
        Member value = new EquipmentManager()
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            IsHeadKitman = true,
            MemberType = EquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Member>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };

        string expectedCharacterID = "jamie-tartt";
        long expectedJerseyNumber = 9;
        ApiEnum<string, Position> expectedPosition = Position.Forward;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        long expectedAssists = 23;
        long expectedGoalsScored = 47;
        bool expectedIsCaptain = false;
        ApiEnum<string, MemberType> expectedMemberType = MemberType.Player;

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
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Player>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Player>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCharacterID = "jamie-tartt";
        long expectedJerseyNumber = 9;
        ApiEnum<string, Position> expectedPosition = Position.Forward;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        long expectedAssists = 23;
        long expectedGoalsScored = 47;
        bool expectedIsCaptain = false;
        ApiEnum<string, MemberType> expectedMemberType = MemberType.Player;

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
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
        };

        Assert.Null(model.Assists);
        Assert.False(model.RawData.ContainsKey("assists"));
        Assert.Null(model.GoalsScored);
        Assert.False(model.RawData.ContainsKey("goals_scored"));
        Assert.Null(model.IsCaptain);
        Assert.False(model.RawData.ContainsKey("is_captain"));
        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,

            // Null should be interpreted as omitted for these properties
            Assists = null,
            GoalsScored = null,
            IsCaptain = null,
            MemberType = null,
        };

        Assert.Null(model.Assists);
        Assert.False(model.RawData.ContainsKey("assists"));
        Assert.Null(model.GoalsScored);
        Assert.False(model.RawData.ContainsKey("goals_scored"));
        Assert.Null(model.IsCaptain);
        Assert.False(model.RawData.ContainsKey("is_captain"));
        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,

            // Null should be interpreted as omitted for these properties
            Assists = null,
            GoalsScored = null,
            IsCaptain = null,
            MemberType = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Player
        {
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = MemberType.Player,
        };

        Player copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MemberTypeTest : TestBase
{
    [Theory]
    [InlineData(MemberType.Player)]
    public void Validation_Works(MemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MemberType.Player)]
    public void SerializationRoundtrip_Works(MemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CoachTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
            WinRate = 0.65,
        };

        string expectedCharacterID = "jamie-tartt";
        ApiEnum<string, CoachSpecialty> expectedSpecialty = CoachSpecialty.HeadCoach;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        List<string> expectedCertifications = ["UEFA Pro License", "FA Level 4"];
        ApiEnum<string, CoachMemberType> expectedMemberType = CoachMemberType.Coach;
        double expectedWinRate = 0.65;

        Assert.Equal(expectedCharacterID, model.CharacterID);
        Assert.Equal(expectedSpecialty, model.Specialty);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
        Assert.NotNull(model.Certifications);
        Assert.Equal(expectedCertifications.Count, model.Certifications.Count);
        for (int i = 0; i < expectedCertifications.Count; i++)
        {
            Assert.Equal(expectedCertifications[i], model.Certifications[i]);
        }
        Assert.Equal(expectedMemberType, model.MemberType);
        Assert.Equal(expectedWinRate, model.WinRate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
            WinRate = 0.65,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coach>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
            WinRate = 0.65,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coach>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCharacterID = "jamie-tartt";
        ApiEnum<string, CoachSpecialty> expectedSpecialty = CoachSpecialty.HeadCoach;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        List<string> expectedCertifications = ["UEFA Pro License", "FA Level 4"];
        ApiEnum<string, CoachMemberType> expectedMemberType = CoachMemberType.Coach;
        double expectedWinRate = 0.65;

        Assert.Equal(expectedCharacterID, deserialized.CharacterID);
        Assert.Equal(expectedSpecialty, deserialized.Specialty);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
        Assert.NotNull(deserialized.Certifications);
        Assert.Equal(expectedCertifications.Count, deserialized.Certifications.Count);
        for (int i = 0; i < expectedCertifications.Count; i++)
        {
            Assert.Equal(expectedCertifications[i], deserialized.Certifications[i]);
        }
        Assert.Equal(expectedMemberType, deserialized.MemberType);
        Assert.Equal(expectedWinRate, deserialized.WinRate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
            WinRate = 0.65,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            WinRate = 0.65,
        };

        Assert.Null(model.Certifications);
        Assert.False(model.RawData.ContainsKey("certifications"));
        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            WinRate = 0.65,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            WinRate = 0.65,

            // Null should be interpreted as omitted for these properties
            Certifications = null,
            MemberType = null,
        };

        Assert.Null(model.Certifications);
        Assert.False(model.RawData.ContainsKey("certifications"));
        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            WinRate = 0.65,

            // Null should be interpreted as omitted for these properties
            Certifications = null,
            MemberType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
        };

        Assert.Null(model.WinRate);
        Assert.False(model.RawData.ContainsKey("win_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,

            WinRate = null,
        };

        Assert.Null(model.WinRate);
        Assert.True(model.RawData.ContainsKey("win_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,

            WinRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Coach
        {
            CharacterID = "jamie-tartt",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Certifications = ["UEFA Pro License", "FA Level 4"],
            MemberType = CoachMemberType.Coach,
            WinRate = 0.65,
        };

        Coach copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CoachMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(CoachMemberType.Coach)]
    public void Validation_Works(CoachMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CoachMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CoachMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CoachMemberType.Coach)]
    public void SerializationRoundtrip_Works(CoachMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CoachMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CoachMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CoachMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CoachMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MedicalStaffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };

        string expectedCharacterID = "jamie-tartt";
        ApiEnum<string, MedicalSpecialty> expectedSpecialty = MedicalSpecialty.SportsPsychologist;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        string expectedLicenseNumber = "PSY-12345";
        ApiEnum<string, MedicalStaffMemberType> expectedMemberType =
            MedicalStaffMemberType.MedicalStaff;
        List<string> expectedQualifications =
        [
            "PhD Clinical Psychology",
            "Sports Psychology Certification",
        ];

        Assert.Equal(expectedCharacterID, model.CharacterID);
        Assert.Equal(expectedSpecialty, model.Specialty);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
        Assert.Equal(expectedLicenseNumber, model.LicenseNumber);
        Assert.Equal(expectedMemberType, model.MemberType);
        Assert.NotNull(model.Qualifications);
        Assert.Equal(expectedQualifications.Count, model.Qualifications.Count);
        for (int i = 0; i < expectedQualifications.Count; i++)
        {
            Assert.Equal(expectedQualifications[i], model.Qualifications[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MedicalStaff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MedicalStaff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCharacterID = "jamie-tartt";
        ApiEnum<string, MedicalSpecialty> expectedSpecialty = MedicalSpecialty.SportsPsychologist;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        string expectedLicenseNumber = "PSY-12345";
        ApiEnum<string, MedicalStaffMemberType> expectedMemberType =
            MedicalStaffMemberType.MedicalStaff;
        List<string> expectedQualifications =
        [
            "PhD Clinical Psychology",
            "Sports Psychology Certification",
        ];

        Assert.Equal(expectedCharacterID, deserialized.CharacterID);
        Assert.Equal(expectedSpecialty, deserialized.Specialty);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
        Assert.Equal(expectedLicenseNumber, deserialized.LicenseNumber);
        Assert.Equal(expectedMemberType, deserialized.MemberType);
        Assert.NotNull(deserialized.Qualifications);
        Assert.Equal(expectedQualifications.Count, deserialized.Qualifications.Count);
        for (int i = 0; i < expectedQualifications.Count; i++)
        {
            Assert.Equal(expectedQualifications[i], deserialized.Qualifications[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
        };

        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
        Assert.Null(model.Qualifications);
        Assert.False(model.RawData.ContainsKey("qualifications"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",

            // Null should be interpreted as omitted for these properties
            MemberType = null,
            Qualifications = null,
        };

        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
        Assert.Null(model.Qualifications);
        Assert.False(model.RawData.ContainsKey("qualifications"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",

            // Null should be interpreted as omitted for these properties
            MemberType = null,
            Qualifications = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };

        Assert.Null(model.LicenseNumber);
        Assert.False(model.RawData.ContainsKey("license_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],

            LicenseNumber = null,
        };

        Assert.Null(model.LicenseNumber);
        Assert.True(model.RawData.ContainsKey("license_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],

            LicenseNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MedicalStaff
        {
            CharacterID = "jamie-tartt",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            LicenseNumber = "PSY-12345",
            MemberType = MedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology", "Sports Psychology Certification"],
        };

        MedicalStaff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MedicalStaffMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(MedicalStaffMemberType.MedicalStaff)]
    public void Validation_Works(MedicalStaffMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MedicalStaffMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MedicalStaffMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MedicalStaffMemberType.MedicalStaff)]
    public void SerializationRoundtrip_Works(MedicalStaffMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MedicalStaffMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MedicalStaffMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MedicalStaffMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MedicalStaffMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EquipmentManagerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            IsHeadKitman = true,
            MemberType = EquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };

        string expectedCharacterID = "jamie-tartt";
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        bool expectedIsHeadKitman = true;
        ApiEnum<string, EquipmentManagerMemberType> expectedMemberType =
            EquipmentManagerMemberType.EquipmentManager;
        List<string> expectedResponsibilities = ["Kit preparation", "Equipment maintenance"];

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
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            IsHeadKitman = true,
            MemberType = EquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EquipmentManager>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            IsHeadKitman = true,
            MemberType = EquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EquipmentManager>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCharacterID = "jamie-tartt";
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 3;
        bool expectedIsHeadKitman = true;
        ApiEnum<string, EquipmentManagerMemberType> expectedMemberType =
            EquipmentManagerMemberType.EquipmentManager;
        List<string> expectedResponsibilities = ["Kit preparation", "Equipment maintenance"];

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
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            IsHeadKitman = true,
            MemberType = EquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
        };

        Assert.Null(model.IsHeadKitman);
        Assert.False(model.RawData.ContainsKey("is_head_kitman"));
        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
        Assert.Null(model.Responsibilities);
        Assert.False(model.RawData.ContainsKey("responsibilities"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,

            // Null should be interpreted as omitted for these properties
            IsHeadKitman = null,
            MemberType = null,
            Responsibilities = null,
        };

        Assert.Null(model.IsHeadKitman);
        Assert.False(model.RawData.ContainsKey("is_head_kitman"));
        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
        Assert.Null(model.Responsibilities);
        Assert.False(model.RawData.ContainsKey("responsibilities"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,

            // Null should be interpreted as omitted for these properties
            IsHeadKitman = null,
            MemberType = null,
            Responsibilities = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EquipmentManager
        {
            CharacterID = "jamie-tartt",
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            IsHeadKitman = true,
            MemberType = EquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };

        EquipmentManager copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EquipmentManagerMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(EquipmentManagerMemberType.EquipmentManager)]
    public void Validation_Works(EquipmentManagerMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EquipmentManagerMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EquipmentManagerMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EquipmentManagerMemberType.EquipmentManager)]
    public void SerializationRoundtrip_Works(EquipmentManagerMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EquipmentManagerMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EquipmentManagerMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EquipmentManagerMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EquipmentManagerMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

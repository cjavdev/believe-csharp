using System.Text.Json;
using Believe.Core;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class TeamMemberRetrieveResponseTest : TestBase
{
    [Fact]
    public void PlayerValidationWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberPlayer()
        {
            ID = "jamie-tartt-richmond",
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = TeamMemberPlayerMemberType.Player,
        };
        value.Validate();
    }

    [Fact]
    public void CoachValidationWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberCoach()
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            Certifications = ["NCAA Division II"],
            MemberType = TeamMemberCoachMemberType.Coach,
            WinRate = 0.55,
        };
        value.Validate();
    }

    [Fact]
    public void MedicalStaffValidationWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberMedicalStaff()
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
            LicenseNumber = "PSY-12345",
            MemberType = TeamMemberMedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology"],
        };
        value.Validate();
    }

    [Fact]
    public void EquipmentManagerValidationWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberEquipmentManager()
        {
            ID = "nate-kitman-richmond",
            CharacterID = "nathan-shelley",
            TeamID = "afc-richmond",
            YearsWithTeam = 5,
            IsHeadKitman = true,
            MemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };
        value.Validate();
    }

    [Fact]
    public void PlayerSerializationRoundtripWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberPlayer()
        {
            ID = "jamie-tartt-richmond",
            CharacterID = "jamie-tartt",
            JerseyNumber = 9,
            Position = Position.Forward,
            TeamID = "afc-richmond",
            YearsWithTeam = 3,
            Assists = 23,
            GoalsScored = 47,
            IsCaptain = false,
            MemberType = TeamMemberPlayerMemberType.Player,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CoachSerializationRoundtripWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberCoach()
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            Certifications = ["NCAA Division II"],
            MemberType = TeamMemberCoachMemberType.Coach,
            WinRate = 0.55,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MedicalStaffSerializationRoundtripWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberMedicalStaff()
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
            LicenseNumber = "PSY-12345",
            MemberType = TeamMemberMedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EquipmentManagerSerializationRoundtripWorks()
    {
        TeamMemberRetrieveResponse value = new TeamMemberEquipmentManager()
        {
            ID = "nate-kitman-richmond",
            CharacterID = "nathan-shelley",
            TeamID = "afc-richmond",
            YearsWithTeam = 5,
            IsHeadKitman = true,
            MemberType = TeamMemberEquipmentManagerMemberType.EquipmentManager,
            Responsibilities = ["Kit preparation", "Equipment maintenance"],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

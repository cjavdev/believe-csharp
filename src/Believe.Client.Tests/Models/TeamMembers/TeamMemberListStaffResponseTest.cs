using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.TeamMembers;

namespace Believe.Client.Tests.Models.TeamMembers;

public class TeamMemberListStaffResponseTest : TestBase
{
    [Fact]
    public void MedicalStaffValidationWorks()
    {
        TeamMemberListStaffResponse value = new TeamMemberMedicalStaff()
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
        TeamMemberListStaffResponse value = new TeamMemberEquipmentManager()
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
    public void MedicalStaffSerializationRoundtripWorks()
    {
        TeamMemberListStaffResponse value = new TeamMemberMedicalStaff()
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
        var deserialized = JsonSerializer.Deserialize<TeamMemberListStaffResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EquipmentManagerSerializationRoundtripWorks()
    {
        TeamMemberListStaffResponse value = new TeamMemberEquipmentManager()
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
        var deserialized = JsonSerializer.Deserialize<TeamMemberListStaffResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

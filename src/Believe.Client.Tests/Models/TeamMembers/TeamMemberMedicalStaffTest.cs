using System.Collections.Generic;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Models.TeamMembers;

namespace Believe.Client.Tests.Models.TeamMembers;

public class TeamMemberMedicalStaffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberMedicalStaff
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

        string expectedID = "sharon-fieldstone-richmond";
        string expectedCharacterID = "dr-sharon";
        ApiEnum<string, MedicalSpecialty> expectedSpecialty = MedicalSpecialty.SportsPsychologist;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 1;
        string expectedLicenseNumber = "PSY-12345";
        ApiEnum<string, TeamMemberMedicalStaffMemberType> expectedMemberType =
            TeamMemberMedicalStaffMemberType.MedicalStaff;
        List<string> expectedQualifications = ["PhD Clinical Psychology"];

        Assert.Equal(expectedID, model.ID);
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
        var model = new TeamMemberMedicalStaff
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberMedicalStaff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberMedicalStaff
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberMedicalStaff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sharon-fieldstone-richmond";
        string expectedCharacterID = "dr-sharon";
        ApiEnum<string, MedicalSpecialty> expectedSpecialty = MedicalSpecialty.SportsPsychologist;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 1;
        string expectedLicenseNumber = "PSY-12345";
        ApiEnum<string, TeamMemberMedicalStaffMemberType> expectedMemberType =
            TeamMemberMedicalStaffMemberType.MedicalStaff;
        List<string> expectedQualifications = ["PhD Clinical Psychology"];

        Assert.Equal(expectedID, deserialized.ID);
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
        var model = new TeamMemberMedicalStaff
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
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
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
            LicenseNumber = "PSY-12345",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
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
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
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
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
            MemberType = TeamMemberMedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology"],
        };

        Assert.Null(model.LicenseNumber);
        Assert.False(model.RawData.ContainsKey("license_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
            MemberType = TeamMemberMedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
            MemberType = TeamMemberMedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology"],

            LicenseNumber = null,
        };

        Assert.Null(model.LicenseNumber);
        Assert.True(model.RawData.ContainsKey("license_number"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TeamMemberMedicalStaff
        {
            ID = "sharon-fieldstone-richmond",
            CharacterID = "dr-sharon",
            Specialty = MedicalSpecialty.SportsPsychologist,
            TeamID = "afc-richmond",
            YearsWithTeam = 1,
            MemberType = TeamMemberMedicalStaffMemberType.MedicalStaff,
            Qualifications = ["PhD Clinical Psychology"],

            LicenseNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberMedicalStaff
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

        TeamMemberMedicalStaff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamMemberMedicalStaffMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(TeamMemberMedicalStaffMemberType.MedicalStaff)]
    public void Validation_Works(TeamMemberMedicalStaffMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberMedicalStaffMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberMedicalStaffMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TeamMemberMedicalStaffMemberType.MedicalStaff)]
    public void SerializationRoundtrip_Works(TeamMemberMedicalStaffMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberMedicalStaffMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberMedicalStaffMemberType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberMedicalStaffMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberMedicalStaffMemberType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

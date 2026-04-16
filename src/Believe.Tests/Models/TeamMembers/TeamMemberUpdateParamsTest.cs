using System;
using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class TeamMemberUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamMemberUpdateParams
        {
            MemberID = "member_id",
            Updates = new PlayerUpdate()
            {
                Assists = 0,
                GoalsScored = 0,
                IsCaptain = true,
                JerseyNumber = 1,
                Position = Position.Goalkeeper,
                TeamID = "team_id",
                YearsWithTeam = 0,
            },
        };

        string expectedMemberID = "member_id";
        Updates expectedUpdates = new PlayerUpdate()
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        Assert.Equal(expectedMemberID, parameters.MemberID);
        Assert.Equal(expectedUpdates, parameters.Updates);
    }

    [Fact]
    public void Url_Works()
    {
        TeamMemberUpdateParams parameters = new()
        {
            MemberID = "member_id",
            Updates = new PlayerUpdate()
            {
                Assists = 0,
                GoalsScored = 0,
                IsCaptain = true,
                JerseyNumber = 1,
                Position = Position.Goalkeeper,
                TeamID = "team_id",
                YearsWithTeam = 0,
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://believe.cjav.dev/team-members/member_id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamMemberUpdateParams
        {
            MemberID = "member_id",
            Updates = new PlayerUpdate()
            {
                Assists = 0,
                GoalsScored = 0,
                IsCaptain = true,
                JerseyNumber = 1,
                Position = Position.Goalkeeper,
                TeamID = "team_id",
                YearsWithTeam = 0,
            },
        };

        TeamMemberUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class UpdatesTest : TestBase
{
    [Fact]
    public void PlayerUpdateValidationWorks()
    {
        Updates value = new PlayerUpdate()
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };
        value.Validate();
    }

    [Fact]
    public void CoachUpdateValidationWorks()
    {
        Updates value = new CoachUpdate()
        {
            Certifications = ["string"],
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
            WinRate = 0,
            YearsWithTeam = 0,
        };
        value.Validate();
    }

    [Fact]
    public void MedicalStaffUpdateValidationWorks()
    {
        Updates value = new MedicalStaffUpdate()
        {
            LicenseNumber = "license_number",
            Qualifications = ["string"],
            Specialty = MedicalSpecialty.TeamDoctor,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };
        value.Validate();
    }

    [Fact]
    public void EquipmentManagerUpdateValidationWorks()
    {
        Updates value = new EquipmentManagerUpdate()
        {
            IsHeadKitman = true,
            Responsibilities = ["string"],
            TeamID = "team_id",
            YearsWithTeam = 0,
        };
        value.Validate();
    }

    [Fact]
    public void PlayerUpdateSerializationRoundtripWorks()
    {
        Updates value = new PlayerUpdate()
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Updates>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CoachUpdateSerializationRoundtripWorks()
    {
        Updates value = new CoachUpdate()
        {
            Certifications = ["string"],
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
            WinRate = 0,
            YearsWithTeam = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Updates>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MedicalStaffUpdateSerializationRoundtripWorks()
    {
        Updates value = new MedicalStaffUpdate()
        {
            LicenseNumber = "license_number",
            Qualifications = ["string"],
            Specialty = MedicalSpecialty.TeamDoctor,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Updates>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void EquipmentManagerUpdateSerializationRoundtripWorks()
    {
        Updates value = new EquipmentManagerUpdate()
        {
            IsHeadKitman = true,
            Responsibilities = ["string"],
            TeamID = "team_id",
            YearsWithTeam = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Updates>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PlayerUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlayerUpdate
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        long expectedAssists = 0;
        long expectedGoalsScored = 0;
        bool expectedIsCaptain = true;
        long expectedJerseyNumber = 1;
        ApiEnum<string, Position> expectedPosition = Position.Goalkeeper;
        string expectedTeamID = "team_id";
        long expectedYearsWithTeam = 0;

        Assert.Equal(expectedAssists, model.Assists);
        Assert.Equal(expectedGoalsScored, model.GoalsScored);
        Assert.Equal(expectedIsCaptain, model.IsCaptain);
        Assert.Equal(expectedJerseyNumber, model.JerseyNumber);
        Assert.Equal(expectedPosition, model.Position);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlayerUpdate
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlayerUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlayerUpdate
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlayerUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAssists = 0;
        long expectedGoalsScored = 0;
        bool expectedIsCaptain = true;
        long expectedJerseyNumber = 1;
        ApiEnum<string, Position> expectedPosition = Position.Goalkeeper;
        string expectedTeamID = "team_id";
        long expectedYearsWithTeam = 0;

        Assert.Equal(expectedAssists, deserialized.Assists);
        Assert.Equal(expectedGoalsScored, deserialized.GoalsScored);
        Assert.Equal(expectedIsCaptain, deserialized.IsCaptain);
        Assert.Equal(expectedJerseyNumber, deserialized.JerseyNumber);
        Assert.Equal(expectedPosition, deserialized.Position);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlayerUpdate
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlayerUpdate { };

        Assert.Null(model.Assists);
        Assert.False(model.RawData.ContainsKey("assists"));
        Assert.Null(model.GoalsScored);
        Assert.False(model.RawData.ContainsKey("goals_scored"));
        Assert.Null(model.IsCaptain);
        Assert.False(model.RawData.ContainsKey("is_captain"));
        Assert.Null(model.JerseyNumber);
        Assert.False(model.RawData.ContainsKey("jersey_number"));
        Assert.Null(model.Position);
        Assert.False(model.RawData.ContainsKey("position"));
        Assert.Null(model.TeamID);
        Assert.False(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.YearsWithTeam);
        Assert.False(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlayerUpdate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlayerUpdate
        {
            Assists = null,
            GoalsScored = null,
            IsCaptain = null,
            JerseyNumber = null,
            Position = null,
            TeamID = null,
            YearsWithTeam = null,
        };

        Assert.Null(model.Assists);
        Assert.True(model.RawData.ContainsKey("assists"));
        Assert.Null(model.GoalsScored);
        Assert.True(model.RawData.ContainsKey("goals_scored"));
        Assert.Null(model.IsCaptain);
        Assert.True(model.RawData.ContainsKey("is_captain"));
        Assert.Null(model.JerseyNumber);
        Assert.True(model.RawData.ContainsKey("jersey_number"));
        Assert.Null(model.Position);
        Assert.True(model.RawData.ContainsKey("position"));
        Assert.Null(model.TeamID);
        Assert.True(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.YearsWithTeam);
        Assert.True(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlayerUpdate
        {
            Assists = null,
            GoalsScored = null,
            IsCaptain = null,
            JerseyNumber = null,
            Position = null,
            TeamID = null,
            YearsWithTeam = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlayerUpdate
        {
            Assists = 0,
            GoalsScored = 0,
            IsCaptain = true,
            JerseyNumber = 1,
            Position = Position.Goalkeeper,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        PlayerUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CoachUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CoachUpdate
        {
            Certifications = ["string"],
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
            WinRate = 0,
            YearsWithTeam = 0,
        };

        List<string> expectedCertifications = ["string"];
        ApiEnum<string, CoachSpecialty> expectedSpecialty = CoachSpecialty.HeadCoach;
        string expectedTeamID = "team_id";
        double expectedWinRate = 0;
        long expectedYearsWithTeam = 0;

        Assert.NotNull(model.Certifications);
        Assert.Equal(expectedCertifications.Count, model.Certifications.Count);
        for (int i = 0; i < expectedCertifications.Count; i++)
        {
            Assert.Equal(expectedCertifications[i], model.Certifications[i]);
        }
        Assert.Equal(expectedSpecialty, model.Specialty);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedWinRate, model.WinRate);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CoachUpdate
        {
            Certifications = ["string"],
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
            WinRate = 0,
            YearsWithTeam = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CoachUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CoachUpdate
        {
            Certifications = ["string"],
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
            WinRate = 0,
            YearsWithTeam = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CoachUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedCertifications = ["string"];
        ApiEnum<string, CoachSpecialty> expectedSpecialty = CoachSpecialty.HeadCoach;
        string expectedTeamID = "team_id";
        double expectedWinRate = 0;
        long expectedYearsWithTeam = 0;

        Assert.NotNull(deserialized.Certifications);
        Assert.Equal(expectedCertifications.Count, deserialized.Certifications.Count);
        for (int i = 0; i < expectedCertifications.Count; i++)
        {
            Assert.Equal(expectedCertifications[i], deserialized.Certifications[i]);
        }
        Assert.Equal(expectedSpecialty, deserialized.Specialty);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedWinRate, deserialized.WinRate);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CoachUpdate
        {
            Certifications = ["string"],
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
            WinRate = 0,
            YearsWithTeam = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CoachUpdate { };

        Assert.Null(model.Certifications);
        Assert.False(model.RawData.ContainsKey("certifications"));
        Assert.Null(model.Specialty);
        Assert.False(model.RawData.ContainsKey("specialty"));
        Assert.Null(model.TeamID);
        Assert.False(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.WinRate);
        Assert.False(model.RawData.ContainsKey("win_rate"));
        Assert.Null(model.YearsWithTeam);
        Assert.False(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CoachUpdate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CoachUpdate
        {
            Certifications = null,
            Specialty = null,
            TeamID = null,
            WinRate = null,
            YearsWithTeam = null,
        };

        Assert.Null(model.Certifications);
        Assert.True(model.RawData.ContainsKey("certifications"));
        Assert.Null(model.Specialty);
        Assert.True(model.RawData.ContainsKey("specialty"));
        Assert.Null(model.TeamID);
        Assert.True(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.WinRate);
        Assert.True(model.RawData.ContainsKey("win_rate"));
        Assert.Null(model.YearsWithTeam);
        Assert.True(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CoachUpdate
        {
            Certifications = null,
            Specialty = null,
            TeamID = null,
            WinRate = null,
            YearsWithTeam = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CoachUpdate
        {
            Certifications = ["string"],
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "team_id",
            WinRate = 0,
            YearsWithTeam = 0,
        };

        CoachUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MedicalStaffUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MedicalStaffUpdate
        {
            LicenseNumber = "license_number",
            Qualifications = ["string"],
            Specialty = MedicalSpecialty.TeamDoctor,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        string expectedLicenseNumber = "license_number";
        List<string> expectedQualifications = ["string"];
        ApiEnum<string, MedicalSpecialty> expectedSpecialty = MedicalSpecialty.TeamDoctor;
        string expectedTeamID = "team_id";
        long expectedYearsWithTeam = 0;

        Assert.Equal(expectedLicenseNumber, model.LicenseNumber);
        Assert.NotNull(model.Qualifications);
        Assert.Equal(expectedQualifications.Count, model.Qualifications.Count);
        for (int i = 0; i < expectedQualifications.Count; i++)
        {
            Assert.Equal(expectedQualifications[i], model.Qualifications[i]);
        }
        Assert.Equal(expectedSpecialty, model.Specialty);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MedicalStaffUpdate
        {
            LicenseNumber = "license_number",
            Qualifications = ["string"],
            Specialty = MedicalSpecialty.TeamDoctor,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MedicalStaffUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MedicalStaffUpdate
        {
            LicenseNumber = "license_number",
            Qualifications = ["string"],
            Specialty = MedicalSpecialty.TeamDoctor,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MedicalStaffUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedLicenseNumber = "license_number";
        List<string> expectedQualifications = ["string"];
        ApiEnum<string, MedicalSpecialty> expectedSpecialty = MedicalSpecialty.TeamDoctor;
        string expectedTeamID = "team_id";
        long expectedYearsWithTeam = 0;

        Assert.Equal(expectedLicenseNumber, deserialized.LicenseNumber);
        Assert.NotNull(deserialized.Qualifications);
        Assert.Equal(expectedQualifications.Count, deserialized.Qualifications.Count);
        for (int i = 0; i < expectedQualifications.Count; i++)
        {
            Assert.Equal(expectedQualifications[i], deserialized.Qualifications[i]);
        }
        Assert.Equal(expectedSpecialty, deserialized.Specialty);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MedicalStaffUpdate
        {
            LicenseNumber = "license_number",
            Qualifications = ["string"],
            Specialty = MedicalSpecialty.TeamDoctor,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MedicalStaffUpdate { };

        Assert.Null(model.LicenseNumber);
        Assert.False(model.RawData.ContainsKey("license_number"));
        Assert.Null(model.Qualifications);
        Assert.False(model.RawData.ContainsKey("qualifications"));
        Assert.Null(model.Specialty);
        Assert.False(model.RawData.ContainsKey("specialty"));
        Assert.Null(model.TeamID);
        Assert.False(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.YearsWithTeam);
        Assert.False(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MedicalStaffUpdate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MedicalStaffUpdate
        {
            LicenseNumber = null,
            Qualifications = null,
            Specialty = null,
            TeamID = null,
            YearsWithTeam = null,
        };

        Assert.Null(model.LicenseNumber);
        Assert.True(model.RawData.ContainsKey("license_number"));
        Assert.Null(model.Qualifications);
        Assert.True(model.RawData.ContainsKey("qualifications"));
        Assert.Null(model.Specialty);
        Assert.True(model.RawData.ContainsKey("specialty"));
        Assert.Null(model.TeamID);
        Assert.True(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.YearsWithTeam);
        Assert.True(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MedicalStaffUpdate
        {
            LicenseNumber = null,
            Qualifications = null,
            Specialty = null,
            TeamID = null,
            YearsWithTeam = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MedicalStaffUpdate
        {
            LicenseNumber = "license_number",
            Qualifications = ["string"],
            Specialty = MedicalSpecialty.TeamDoctor,
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        MedicalStaffUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EquipmentManagerUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EquipmentManagerUpdate
        {
            IsHeadKitman = true,
            Responsibilities = ["string"],
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        bool expectedIsHeadKitman = true;
        List<string> expectedResponsibilities = ["string"];
        string expectedTeamID = "team_id";
        long expectedYearsWithTeam = 0;

        Assert.Equal(expectedIsHeadKitman, model.IsHeadKitman);
        Assert.NotNull(model.Responsibilities);
        Assert.Equal(expectedResponsibilities.Count, model.Responsibilities.Count);
        for (int i = 0; i < expectedResponsibilities.Count; i++)
        {
            Assert.Equal(expectedResponsibilities[i], model.Responsibilities[i]);
        }
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedYearsWithTeam, model.YearsWithTeam);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EquipmentManagerUpdate
        {
            IsHeadKitman = true,
            Responsibilities = ["string"],
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EquipmentManagerUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EquipmentManagerUpdate
        {
            IsHeadKitman = true,
            Responsibilities = ["string"],
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EquipmentManagerUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsHeadKitman = true;
        List<string> expectedResponsibilities = ["string"];
        string expectedTeamID = "team_id";
        long expectedYearsWithTeam = 0;

        Assert.Equal(expectedIsHeadKitman, deserialized.IsHeadKitman);
        Assert.NotNull(deserialized.Responsibilities);
        Assert.Equal(expectedResponsibilities.Count, deserialized.Responsibilities.Count);
        for (int i = 0; i < expectedResponsibilities.Count; i++)
        {
            Assert.Equal(expectedResponsibilities[i], deserialized.Responsibilities[i]);
        }
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedYearsWithTeam, deserialized.YearsWithTeam);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EquipmentManagerUpdate
        {
            IsHeadKitman = true,
            Responsibilities = ["string"],
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EquipmentManagerUpdate { };

        Assert.Null(model.IsHeadKitman);
        Assert.False(model.RawData.ContainsKey("is_head_kitman"));
        Assert.Null(model.Responsibilities);
        Assert.False(model.RawData.ContainsKey("responsibilities"));
        Assert.Null(model.TeamID);
        Assert.False(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.YearsWithTeam);
        Assert.False(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new EquipmentManagerUpdate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new EquipmentManagerUpdate
        {
            IsHeadKitman = null,
            Responsibilities = null,
            TeamID = null,
            YearsWithTeam = null,
        };

        Assert.Null(model.IsHeadKitman);
        Assert.True(model.RawData.ContainsKey("is_head_kitman"));
        Assert.Null(model.Responsibilities);
        Assert.True(model.RawData.ContainsKey("responsibilities"));
        Assert.Null(model.TeamID);
        Assert.True(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.YearsWithTeam);
        Assert.True(model.RawData.ContainsKey("years_with_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EquipmentManagerUpdate
        {
            IsHeadKitman = null,
            Responsibilities = null,
            TeamID = null,
            YearsWithTeam = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EquipmentManagerUpdate
        {
            IsHeadKitman = true,
            Responsibilities = ["string"],
            TeamID = "team_id",
            YearsWithTeam = 0,
        };

        EquipmentManagerUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}

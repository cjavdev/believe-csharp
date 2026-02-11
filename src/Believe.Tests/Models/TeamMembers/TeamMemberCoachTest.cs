using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.TeamMembers;

namespace Believe.Tests.Models.TeamMembers;

public class TeamMemberCoachTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberCoach
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

        string expectedID = "ted-lasso-richmond";
        string expectedCharacterID = "ted-lasso";
        ApiEnum<string, CoachSpecialty> expectedSpecialty = CoachSpecialty.HeadCoach;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 2;
        List<string> expectedCertifications = ["NCAA Division II"];
        ApiEnum<string, TeamMemberCoachMemberType> expectedMemberType =
            TeamMemberCoachMemberType.Coach;
        double expectedWinRate = 0.55;

        Assert.Equal(expectedID, model.ID);
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
        var model = new TeamMemberCoach
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberCoach>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberCoach
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberCoach>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "ted-lasso-richmond";
        string expectedCharacterID = "ted-lasso";
        ApiEnum<string, CoachSpecialty> expectedSpecialty = CoachSpecialty.HeadCoach;
        string expectedTeamID = "afc-richmond";
        long expectedYearsWithTeam = 2;
        List<string> expectedCertifications = ["NCAA Division II"];
        ApiEnum<string, TeamMemberCoachMemberType> expectedMemberType =
            TeamMemberCoachMemberType.Coach;
        double expectedWinRate = 0.55;

        Assert.Equal(expectedID, deserialized.ID);
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
        var model = new TeamMemberCoach
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            WinRate = 0.55,
        };

        Assert.Null(model.Certifications);
        Assert.False(model.RawData.ContainsKey("certifications"));
        Assert.Null(model.MemberType);
        Assert.False(model.RawData.ContainsKey("member_type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            WinRate = 0.55,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            WinRate = 0.55,

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
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            WinRate = 0.55,

            // Null should be interpreted as omitted for these properties
            Certifications = null,
            MemberType = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            Certifications = ["NCAA Division II"],
            MemberType = TeamMemberCoachMemberType.Coach,
        };

        Assert.Null(model.WinRate);
        Assert.False(model.RawData.ContainsKey("win_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            Certifications = ["NCAA Division II"],
            MemberType = TeamMemberCoachMemberType.Coach,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            Certifications = ["NCAA Division II"],
            MemberType = TeamMemberCoachMemberType.Coach,

            WinRate = null,
        };

        Assert.Null(model.WinRate);
        Assert.True(model.RawData.ContainsKey("win_rate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TeamMemberCoach
        {
            ID = "ted-lasso-richmond",
            CharacterID = "ted-lasso",
            Specialty = CoachSpecialty.HeadCoach,
            TeamID = "afc-richmond",
            YearsWithTeam = 2,
            Certifications = ["NCAA Division II"],
            MemberType = TeamMemberCoachMemberType.Coach,

            WinRate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberCoach
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

        TeamMemberCoach copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamMemberCoachMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(TeamMemberCoachMemberType.Coach)]
    public void Validation_Works(TeamMemberCoachMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberCoachMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberCoachMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TeamMemberCoachMemberType.Coach)]
    public void SerializationRoundtrip_Works(TeamMemberCoachMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberCoachMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberCoachMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberCoachMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberCoachMemberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

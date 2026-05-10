using System;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Exceptions;
using Believe.Client.Models.TeamMembers;

namespace Believe.Client.Tests.Models.TeamMembers;

public class TeamMemberListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamMemberListParams
        {
            Limit = 10,
            MemberType = TeamMemberListParamsMemberType.Player,
            Skip = 0,
            TeamID = "team_id",
        };

        long expectedLimit = 10;
        ApiEnum<string, TeamMemberListParamsMemberType> expectedMemberType =
            TeamMemberListParamsMemberType.Player;
        long expectedSkip = 0;
        string expectedTeamID = "team_id";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMemberType, parameters.MemberType);
        Assert.Equal(expectedSkip, parameters.Skip);
        Assert.Equal(expectedTeamID, parameters.TeamID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TeamMemberListParams
        {
            MemberType = TeamMemberListParamsMemberType.Player,
            TeamID = "team_id",
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TeamMemberListParams
        {
            MemberType = TeamMemberListParamsMemberType.Player,
            TeamID = "team_id",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Skip = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TeamMemberListParams { Limit = 10, Skip = 0 };

        Assert.Null(parameters.MemberType);
        Assert.False(parameters.RawQueryData.ContainsKey("member_type"));
        Assert.Null(parameters.TeamID);
        Assert.False(parameters.RawQueryData.ContainsKey("team_id"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new TeamMemberListParams
        {
            Limit = 10,
            Skip = 0,

            MemberType = null,
            TeamID = null,
        };

        Assert.Null(parameters.MemberType);
        Assert.True(parameters.RawQueryData.ContainsKey("member_type"));
        Assert.Null(parameters.TeamID);
        Assert.True(parameters.RawQueryData.ContainsKey("team_id"));
    }

    [Fact]
    public void Url_Works()
    {
        TeamMemberListParams parameters = new()
        {
            Limit = 10,
            MemberType = TeamMemberListParamsMemberType.Player,
            Skip = 0,
            TeamID = "team_id",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://believe.cjav.dev/team-members?limit=10&member_type=player&skip=0&team_id=team_id"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamMemberListParams
        {
            Limit = 10,
            MemberType = TeamMemberListParamsMemberType.Player,
            Skip = 0,
            TeamID = "team_id",
        };

        TeamMemberListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TeamMemberListParamsMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(TeamMemberListParamsMemberType.Player)]
    [InlineData(TeamMemberListParamsMemberType.Coach)]
    [InlineData(TeamMemberListParamsMemberType.MedicalStaff)]
    [InlineData(TeamMemberListParamsMemberType.EquipmentManager)]
    public void Validation_Works(TeamMemberListParamsMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberListParamsMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberListParamsMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TeamMemberListParamsMemberType.Player)]
    [InlineData(TeamMemberListParamsMemberType.Coach)]
    [InlineData(TeamMemberListParamsMemberType.MedicalStaff)]
    [InlineData(TeamMemberListParamsMemberType.EquipmentManager)]
    public void SerializationRoundtrip_Works(TeamMemberListParamsMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberListParamsMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberListParamsMemberType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TeamMemberListParamsMemberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberListParamsMemberType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

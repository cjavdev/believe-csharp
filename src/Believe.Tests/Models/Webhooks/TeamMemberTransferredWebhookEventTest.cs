using System;
using System.Text.Json;
using Believe.Core;
using Believe.Exceptions;
using Believe.Models.Webhooks;

namespace Believe.Tests.Models.Webhooks;

public class TeamMemberTransferredWebhookEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberTransferredWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred,
        };

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        TeamMemberTransferredWebhookEventData expectedData = new()
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };
        string expectedEventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, TeamMemberTransferredWebhookEventEventType> expectedEventType =
            TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred;

        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedData, model.Data);
        Assert.Equal(expectedEventID, model.EventID);
        Assert.Equal(expectedEventType, model.EventType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamMemberTransferredWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferredWebhookEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberTransferredWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferredWebhookEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        TeamMemberTransferredWebhookEventData expectedData = new()
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };
        string expectedEventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, TeamMemberTransferredWebhookEventEventType> expectedEventType =
            TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred;

        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedData, deserialized.Data);
        Assert.Equal(expectedEventID, deserialized.EventID);
        Assert.Equal(expectedEventType, deserialized.EventType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamMemberTransferredWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberTransferredWebhookEvent
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                CharacterID = "character_id",
                CharacterName = "character_name",
                MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
                TeamID = "team_id",
                TeamMemberID = "team_member_id",
                TeamName = "team_name",
                TedReaction = "ted_reaction",
                TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
                PreviousTeamID = "previous_team_id",
                PreviousTeamName = "previous_team_name",
                TransferFeeGbp = "transfer_fee_gbp",
                YearsWithPreviousTeam = 0,
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred,
        };

        TeamMemberTransferredWebhookEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamMemberTransferredWebhookEventDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };

        string expectedCharacterID = "character_id";
        string expectedCharacterName = "character_name";
        ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType> expectedMemberType =
            TeamMemberTransferredWebhookEventDataMemberType.Player;
        string expectedTeamID = "team_id";
        string expectedTeamMemberID = "team_member_id";
        string expectedTeamName = "team_name";
        string expectedTedReaction = "ted_reaction";
        ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType> expectedTransferType =
            TeamMemberTransferredWebhookEventDataTransferType.Joined;
        string expectedPreviousTeamID = "previous_team_id";
        string expectedPreviousTeamName = "previous_team_name";
        string expectedTransferFeeGbp = "transfer_fee_gbp";
        long expectedYearsWithPreviousTeam = 0;

        Assert.Equal(expectedCharacterID, model.CharacterID);
        Assert.Equal(expectedCharacterName, model.CharacterName);
        Assert.Equal(expectedMemberType, model.MemberType);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedTeamMemberID, model.TeamMemberID);
        Assert.Equal(expectedTeamName, model.TeamName);
        Assert.Equal(expectedTedReaction, model.TedReaction);
        Assert.Equal(expectedTransferType, model.TransferType);
        Assert.Equal(expectedPreviousTeamID, model.PreviousTeamID);
        Assert.Equal(expectedPreviousTeamName, model.PreviousTeamName);
        Assert.Equal(expectedTransferFeeGbp, model.TransferFeeGbp);
        Assert.Equal(expectedYearsWithPreviousTeam, model.YearsWithPreviousTeam);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferredWebhookEventData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TeamMemberTransferredWebhookEventData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCharacterID = "character_id";
        string expectedCharacterName = "character_name";
        ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType> expectedMemberType =
            TeamMemberTransferredWebhookEventDataMemberType.Player;
        string expectedTeamID = "team_id";
        string expectedTeamMemberID = "team_member_id";
        string expectedTeamName = "team_name";
        string expectedTedReaction = "ted_reaction";
        ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType> expectedTransferType =
            TeamMemberTransferredWebhookEventDataTransferType.Joined;
        string expectedPreviousTeamID = "previous_team_id";
        string expectedPreviousTeamName = "previous_team_name";
        string expectedTransferFeeGbp = "transfer_fee_gbp";
        long expectedYearsWithPreviousTeam = 0;

        Assert.Equal(expectedCharacterID, deserialized.CharacterID);
        Assert.Equal(expectedCharacterName, deserialized.CharacterName);
        Assert.Equal(expectedMemberType, deserialized.MemberType);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedTeamMemberID, deserialized.TeamMemberID);
        Assert.Equal(expectedTeamName, deserialized.TeamName);
        Assert.Equal(expectedTedReaction, deserialized.TedReaction);
        Assert.Equal(expectedTransferType, deserialized.TransferType);
        Assert.Equal(expectedPreviousTeamID, deserialized.PreviousTeamID);
        Assert.Equal(expectedPreviousTeamName, deserialized.PreviousTeamName);
        Assert.Equal(expectedTransferFeeGbp, deserialized.TransferFeeGbp);
        Assert.Equal(expectedYearsWithPreviousTeam, deserialized.YearsWithPreviousTeam);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
        };

        Assert.Null(model.PreviousTeamID);
        Assert.False(model.RawData.ContainsKey("previous_team_id"));
        Assert.Null(model.PreviousTeamName);
        Assert.False(model.RawData.ContainsKey("previous_team_name"));
        Assert.Null(model.TransferFeeGbp);
        Assert.False(model.RawData.ContainsKey("transfer_fee_gbp"));
        Assert.Null(model.YearsWithPreviousTeam);
        Assert.False(model.RawData.ContainsKey("years_with_previous_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,

            PreviousTeamID = null,
            PreviousTeamName = null,
            TransferFeeGbp = null,
            YearsWithPreviousTeam = null,
        };

        Assert.Null(model.PreviousTeamID);
        Assert.True(model.RawData.ContainsKey("previous_team_id"));
        Assert.Null(model.PreviousTeamName);
        Assert.True(model.RawData.ContainsKey("previous_team_name"));
        Assert.Null(model.TransferFeeGbp);
        Assert.True(model.RawData.ContainsKey("transfer_fee_gbp"));
        Assert.Null(model.YearsWithPreviousTeam);
        Assert.True(model.RawData.ContainsKey("years_with_previous_team"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,

            PreviousTeamID = null,
            PreviousTeamName = null,
            TransferFeeGbp = null,
            YearsWithPreviousTeam = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TeamMemberTransferredWebhookEventData
        {
            CharacterID = "character_id",
            CharacterName = "character_name",
            MemberType = TeamMemberTransferredWebhookEventDataMemberType.Player,
            TeamID = "team_id",
            TeamMemberID = "team_member_id",
            TeamName = "team_name",
            TedReaction = "ted_reaction",
            TransferType = TeamMemberTransferredWebhookEventDataTransferType.Joined,
            PreviousTeamID = "previous_team_id",
            PreviousTeamName = "previous_team_name",
            TransferFeeGbp = "transfer_fee_gbp",
            YearsWithPreviousTeam = 0,
        };

        TeamMemberTransferredWebhookEventData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamMemberTransferredWebhookEventDataMemberTypeTest : TestBase
{
    [Theory]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.Player)]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.Coach)]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.MedicalStaff)]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.EquipmentManager)]
    public void Validation_Works(TeamMemberTransferredWebhookEventDataMemberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.Player)]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.Coach)]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.MedicalStaff)]
    [InlineData(TeamMemberTransferredWebhookEventDataMemberType.EquipmentManager)]
    public void SerializationRoundtrip_Works(
        TeamMemberTransferredWebhookEventDataMemberType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataMemberType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TeamMemberTransferredWebhookEventDataTransferTypeTest : TestBase
{
    [Theory]
    [InlineData(TeamMemberTransferredWebhookEventDataTransferType.Joined)]
    [InlineData(TeamMemberTransferredWebhookEventDataTransferType.Departed)]
    public void Validation_Works(TeamMemberTransferredWebhookEventDataTransferType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TeamMemberTransferredWebhookEventDataTransferType.Joined)]
    [InlineData(TeamMemberTransferredWebhookEventDataTransferType.Departed)]
    public void SerializationRoundtrip_Works(
        TeamMemberTransferredWebhookEventDataTransferType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventDataTransferType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TeamMemberTransferredWebhookEventEventTypeTest : TestBase
{
    [Theory]
    [InlineData(TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred)]
    public void Validation_Works(TeamMemberTransferredWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredWebhookEventEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<BelieveInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TeamMemberTransferredWebhookEventEventType.TeamMemberTransferred)]
    public void SerializationRoundtrip_Works(TeamMemberTransferredWebhookEventEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TeamMemberTransferredWebhookEventEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TeamMemberTransferredWebhookEventEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

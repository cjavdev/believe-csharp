using System;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Webhooks;

namespace Believe.Tests.Models.Webhooks;

public class UnwrapWebhookEventTest : TestBase
{
    [Fact]
    public void MatchCompletedValidationWorks()
    {
        UnwrapWebhookEvent value = new MatchCompletedWebhookEvent()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchCompletedWebhookEventDataMatchType.League,
                Result = MatchCompletedWebhookEventDataResult.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = MatchCompletedWebhookEventEventType.MatchCompleted,
        };
        value.Validate();
    }

    [Fact]
    public void TeamMemberTransferredValidationWorks()
    {
        UnwrapWebhookEvent value = new TeamMemberTransferredWebhookEvent()
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
        value.Validate();
    }

    [Fact]
    public void MatchCompletedSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new MatchCompletedWebhookEvent()
        {
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Data = new()
            {
                AwayScore = 0,
                AwayTeamID = "away_team_id",
                CompletedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                HomeScore = 0,
                HomeTeamID = "home_team_id",
                MatchID = "match_id",
                MatchType = MatchCompletedWebhookEventDataMatchType.League,
                Result = MatchCompletedWebhookEventDataResult.HomeWin,
                TedPostMatchQuote = "ted_post_match_quote",
                LessonLearned = "lesson_learned",
                ManOfTheMatch = "man_of_the_match",
            },
            EventID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            EventType = MatchCompletedWebhookEventEventType.MatchCompleted,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TeamMemberTransferredSerializationRoundtripWorks()
    {
        UnwrapWebhookEvent value = new TeamMemberTransferredWebhookEvent()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnwrapWebhookEvent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
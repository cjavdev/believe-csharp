using System.Text.Json;
using Believe.Client.Exceptions;
using Believe.Client.Models.Believe;
using Believe.Client.Models.Biscuits;
using Believe.Client.Models.Characters;
using Believe.Client.Models.Conflicts;
using Believe.Client.Models.Matches;
using Believe.Client.Models.Quotes;
using Believe.Client.Models.TeamMembers;
using Believe.Client.Models.Teams;
using Believe.Client.Models.TicketSales;
using Webhooks = Believe.Client.Models.Webhooks;

namespace Believe.Client.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new FrozenDictionaryConverterFactory(),
            new ApiEnumConverter<string, CharacterRole>(),
            new ApiEnumConverter<string, League>(),
            new ApiEnumConverter<string, MatchResult>(),
            new ApiEnumConverter<string, MatchType>(),
            new ApiEnumConverter<string, QuoteMoment>(),
            new ApiEnumConverter<string, QuoteTheme>(),
            new ApiEnumConverter<string, SituationType>(),
            new ApiEnumConverter<string, ConflictType>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, TeamMemberCoachMemberType>(),
            new ApiEnumConverter<string, CoachSpecialty>(),
            new ApiEnumConverter<string, TeamMemberEquipmentManagerMemberType>(),
            new ApiEnumConverter<string, MedicalSpecialty>(),
            new ApiEnumConverter<string, TeamMemberMedicalStaffMemberType>(),
            new ApiEnumConverter<string, TeamMemberPlayerMemberType>(),
            new ApiEnumConverter<string, Position>(),
            new ApiEnumConverter<string, MemberType>(),
            new ApiEnumConverter<string, CoachMemberType>(),
            new ApiEnumConverter<string, MedicalStaffMemberType>(),
            new ApiEnumConverter<string, EquipmentManagerMemberType>(),
            new ApiEnumConverter<string, TeamMemberListParamsMemberType>(),
            new ApiEnumConverter<string, Webhooks::RegisteredWebhookEventType>(),
            new ApiEnumConverter<string, Webhooks::WebhookTriggerEventResponseEventType>(),
            new ApiEnumConverter<string, Webhooks::MatchCompletedWebhookEventDataMatchType>(),
            new ApiEnumConverter<string, Webhooks::MatchCompletedWebhookEventDataResult>(),
            new ApiEnumConverter<string, Webhooks::MatchCompletedWebhookEventEventType>(),
            new ApiEnumConverter<
                string,
                Webhooks::TeamMemberTransferredWebhookEventDataMemberType
            >(),
            new ApiEnumConverter<
                string,
                Webhooks::TeamMemberTransferredWebhookEventDataTransferType
            >(),
            new ApiEnumConverter<string, Webhooks::TeamMemberTransferredWebhookEventEventType>(),
            new ApiEnumConverter<string, Webhooks::EventType>(),
            new ApiEnumConverter<string, Webhooks::WebhookTriggerEventParamsEventType>(),
            new ApiEnumConverter<string, Webhooks::MatchType>(),
            new ApiEnumConverter<string, Webhooks::Result>(),
            new ApiEnumConverter<string, Webhooks::MatchCompletedEventType>(),
            new ApiEnumConverter<string, Webhooks::MemberType>(),
            new ApiEnumConverter<string, Webhooks::TransferType>(),
            new ApiEnumConverter<string, Webhooks::TeamMemberTransferredEventType>(),
            new ApiEnumConverter<string, PurchaseMethod>(),
        },
    };

    internal static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="BelieveInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}

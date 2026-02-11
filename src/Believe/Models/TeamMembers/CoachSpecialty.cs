using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.TeamMembers;

/// <summary>
/// Coaching specialties.
/// </summary>
[JsonConverter(typeof(CoachSpecialtyConverter))]
public enum CoachSpecialty
{
    HeadCoach,
    AssistantCoach,
    GoalkeepingCoach,
    FitnessCoach,
    TacticalAnalyst,
}

sealed class CoachSpecialtyConverter : JsonConverter<CoachSpecialty>
{
    public override CoachSpecialty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "head_coach" => CoachSpecialty.HeadCoach,
            "assistant_coach" => CoachSpecialty.AssistantCoach,
            "goalkeeping_coach" => CoachSpecialty.GoalkeepingCoach,
            "fitness_coach" => CoachSpecialty.FitnessCoach,
            "tactical_analyst" => CoachSpecialty.TacticalAnalyst,
            _ => (CoachSpecialty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CoachSpecialty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CoachSpecialty.HeadCoach => "head_coach",
                CoachSpecialty.AssistantCoach => "assistant_coach",
                CoachSpecialty.GoalkeepingCoach => "goalkeeping_coach",
                CoachSpecialty.FitnessCoach => "fitness_coach",
                CoachSpecialty.TacticalAnalyst => "tactical_analyst",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

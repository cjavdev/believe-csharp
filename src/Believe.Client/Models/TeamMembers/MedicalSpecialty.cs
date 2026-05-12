using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Client.Exceptions;

namespace Believe.Client.Models.TeamMembers;

/// <summary>
/// Medical staff specialties.
/// </summary>
[JsonConverter(typeof(MedicalSpecialtyConverter))]
public enum MedicalSpecialty
{
    TeamDoctor,
    Physiotherapist,
    SportsPsychologist,
    Nutritionist,
    MassageTherapist,
}

sealed class MedicalSpecialtyConverter : JsonConverter<MedicalSpecialty>
{
    public override MedicalSpecialty Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "team_doctor" => MedicalSpecialty.TeamDoctor,
            "physiotherapist" => MedicalSpecialty.Physiotherapist,
            "sports_psychologist" => MedicalSpecialty.SportsPsychologist,
            "nutritionist" => MedicalSpecialty.Nutritionist,
            "massage_therapist" => MedicalSpecialty.MassageTherapist,
            _ => (MedicalSpecialty)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MedicalSpecialty value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MedicalSpecialty.TeamDoctor => "team_doctor",
                MedicalSpecialty.Physiotherapist => "physiotherapist",
                MedicalSpecialty.SportsPsychologist => "sports_psychologist",
                MedicalSpecialty.Nutritionist => "nutritionist",
                MedicalSpecialty.MassageTherapist => "massage_therapist",
                _ => throw new BelieveInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

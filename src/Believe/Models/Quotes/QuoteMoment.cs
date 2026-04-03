using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.Quotes;

/// <summary>
/// Types of moments when quotes occur.
/// </summary>
[JsonConverter(typeof(QuoteMomentConverter))]
public enum QuoteMoment
{
    HalftimeSpeech,
    PressConference,
    LockerRoom,
    Training,
    BiscuitsWithBoss,
    Pub,
    OneOnOne,
    Celebration,
    Crisis,
    Casual,
    Confrontation
}

sealed class QuoteMomentConverter : JsonConverter<QuoteMoment>
{
    public override QuoteMoment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "halftime_speech"=>QuoteMoment.HalftimeSpeech,
            "press_conference"=>QuoteMoment.PressConference,
            "locker_room"=>QuoteMoment.LockerRoom,
            "training"=>QuoteMoment.Training,
            "biscuits_with_boss"=>QuoteMoment.BiscuitsWithBoss,
            "pub"=>QuoteMoment.Pub,
            "one_on_one"=>QuoteMoment.OneOnOne,
            "celebration"=>QuoteMoment.Celebration,
            "crisis"=>QuoteMoment.Crisis,
            "casual"=>QuoteMoment.Casual,
            "confrontation"=>QuoteMoment.Confrontation,
            _ =>(QuoteMoment)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, QuoteMoment value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            QuoteMoment.HalftimeSpeech=>"halftime_speech",
            QuoteMoment.PressConference=>"press_conference",
            QuoteMoment.LockerRoom=>"locker_room",
            QuoteMoment.Training=>"training",
            QuoteMoment.BiscuitsWithBoss=>"biscuits_with_boss",
            QuoteMoment.Pub=>"pub",
            QuoteMoment.OneOnOne=>"one_on_one",
            QuoteMoment.Celebration=>"celebration",
            QuoteMoment.Crisis=>"crisis",
            QuoteMoment.Casual=>"casual",
            QuoteMoment.Confrontation=>"confrontation",
            _ => throw new BelieveInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}
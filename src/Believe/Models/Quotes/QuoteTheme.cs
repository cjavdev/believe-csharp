using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Exceptions;

namespace Believe.Models.Quotes;

/// <summary>
/// Themes that quotes can be categorized under.
/// </summary>
[JsonConverter(typeof(QuoteThemeConverter))]
public enum QuoteTheme
{
    Belief,
    Teamwork,
    Curiosity,
    Kindness,
    Resilience,
    Vulnerability,
    Growth,
    Humor,
    Wisdom,
    Leadership,
    Love,
    Forgiveness,
    Philosophy,
    Romance,
    CulturalPride,
    CulturalDifferences,
    Antagonism,
    Celebration,
    Identity,
    Isolation,
    Power,
    Sacrifice,
    Standards,
    Confidence,
    Conflict,
    Honesty,
    Integrity,
    Intimidation,
    Ambition,
    Narcissism,
    Maturity
}

sealed class QuoteThemeConverter : JsonConverter<QuoteTheme>
{
    public override QuoteTheme Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "belief"=>QuoteTheme.Belief,
            "teamwork"=>QuoteTheme.Teamwork,
            "curiosity"=>QuoteTheme.Curiosity,
            "kindness"=>QuoteTheme.Kindness,
            "resilience"=>QuoteTheme.Resilience,
            "vulnerability"=>QuoteTheme.Vulnerability,
            "growth"=>QuoteTheme.Growth,
            "humor"=>QuoteTheme.Humor,
            "wisdom"=>QuoteTheme.Wisdom,
            "leadership"=>QuoteTheme.Leadership,
            "love"=>QuoteTheme.Love,
            "forgiveness"=>QuoteTheme.Forgiveness,
            "philosophy"=>QuoteTheme.Philosophy,
            "romance"=>QuoteTheme.Romance,
            "cultural-pride"=>QuoteTheme.CulturalPride,
            "cultural-differences"=>QuoteTheme.CulturalDifferences,
            "antagonism"=>QuoteTheme.Antagonism,
            "celebration"=>QuoteTheme.Celebration,
            "identity"=>QuoteTheme.Identity,
            "isolation"=>QuoteTheme.Isolation,
            "power"=>QuoteTheme.Power,
            "sacrifice"=>QuoteTheme.Sacrifice,
            "standards"=>QuoteTheme.Standards,
            "confidence"=>QuoteTheme.Confidence,
            "conflict"=>QuoteTheme.Conflict,
            "honesty"=>QuoteTheme.Honesty,
            "integrity"=>QuoteTheme.Integrity,
            "intimidation"=>QuoteTheme.Intimidation,
            "ambition"=>QuoteTheme.Ambition,
            "narcissism"=>QuoteTheme.Narcissism,
            "maturity"=>QuoteTheme.Maturity,
            _ =>(QuoteTheme)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, QuoteTheme value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            QuoteTheme.Belief=>"belief",
            QuoteTheme.Teamwork=>"teamwork",
            QuoteTheme.Curiosity=>"curiosity",
            QuoteTheme.Kindness=>"kindness",
            QuoteTheme.Resilience=>"resilience",
            QuoteTheme.Vulnerability=>"vulnerability",
            QuoteTheme.Growth=>"growth",
            QuoteTheme.Humor=>"humor",
            QuoteTheme.Wisdom=>"wisdom",
            QuoteTheme.Leadership=>"leadership",
            QuoteTheme.Love=>"love",
            QuoteTheme.Forgiveness=>"forgiveness",
            QuoteTheme.Philosophy=>"philosophy",
            QuoteTheme.Romance=>"romance",
            QuoteTheme.CulturalPride=>"cultural-pride",
            QuoteTheme.CulturalDifferences=>"cultural-differences",
            QuoteTheme.Antagonism=>"antagonism",
            QuoteTheme.Celebration=>"celebration",
            QuoteTheme.Identity=>"identity",
            QuoteTheme.Isolation=>"isolation",
            QuoteTheme.Power=>"power",
            QuoteTheme.Sacrifice=>"sacrifice",
            QuoteTheme.Standards=>"standards",
            QuoteTheme.Confidence=>"confidence",
            QuoteTheme.Conflict=>"conflict",
            QuoteTheme.Honesty=>"honesty",
            QuoteTheme.Integrity=>"integrity",
            QuoteTheme.Intimidation=>"intimidation",
            QuoteTheme.Ambition=>"ambition",
            QuoteTheme.Narcissism=>"narcissism",
            QuoteTheme.Maturity=>"maturity",
            _ => throw new BelieveInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}
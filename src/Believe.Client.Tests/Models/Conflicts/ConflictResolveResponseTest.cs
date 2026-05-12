using System.Collections.Generic;
using System.Text.Json;
using Believe.Client.Core;
using Believe.Client.Models.Conflicts;

namespace Believe.Client.Tests.Models.Conflicts;

public class ConflictResolveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConflictResolveResponse
        {
            BarbecueSauceWisdom =
                "You know what they say - you catch more flies with honey than vinegar. But you also gotta speak up, 'cause a closed mouth don't get fed.",
            Diagnosis =
                "This ain't really about credit, partner. It's about feeling seen and valued. When Alex takes credit, you feel invisible, and that's gonna build up like steam in a pressure cooker.",
            DiamondDogsAdvice =
                "Roy says: 'Tell them to their face.' Higgins says: 'Perhaps document your contributions in emails beforehand.' Coach Beard just nodded mysteriously and quoted Sun Tzu.",
            PotentialOutcome =
                "Y'all might discover Alex didn't even realize they were doing it. Could turn a rival into an ally, like Roy and Jamie... eventually.",
            StepsToResolution =
            [
                "Request a private, casual conversation with Alex",
                "Share how you've been feeling using 'I' statements",
                "Ask if they're aware this has been happening",
                "Propose a collaboration system where you both present together",
                "Set up a weekly sync to align on contributions",
            ],
            TedApproach =
                "I'd bring Alex a coffee, maybe a biscuit, and say 'Hey, can we chat?' No accusations, just curiosity. Ask them how they think the project's going and what they see as everyone's contributions.",
        };

        string expectedBarbecueSauceWisdom =
            "You know what they say - you catch more flies with honey than vinegar. But you also gotta speak up, 'cause a closed mouth don't get fed.";
        string expectedDiagnosis =
            "This ain't really about credit, partner. It's about feeling seen and valued. When Alex takes credit, you feel invisible, and that's gonna build up like steam in a pressure cooker.";
        string expectedDiamondDogsAdvice =
            "Roy says: 'Tell them to their face.' Higgins says: 'Perhaps document your contributions in emails beforehand.' Coach Beard just nodded mysteriously and quoted Sun Tzu.";
        string expectedPotentialOutcome =
            "Y'all might discover Alex didn't even realize they were doing it. Could turn a rival into an ally, like Roy and Jamie... eventually.";
        List<string> expectedStepsToResolution =
        [
            "Request a private, casual conversation with Alex",
            "Share how you've been feeling using 'I' statements",
            "Ask if they're aware this has been happening",
            "Propose a collaboration system where you both present together",
            "Set up a weekly sync to align on contributions",
        ];
        string expectedTedApproach =
            "I'd bring Alex a coffee, maybe a biscuit, and say 'Hey, can we chat?' No accusations, just curiosity. Ask them how they think the project's going and what they see as everyone's contributions.";

        Assert.Equal(expectedBarbecueSauceWisdom, model.BarbecueSauceWisdom);
        Assert.Equal(expectedDiagnosis, model.Diagnosis);
        Assert.Equal(expectedDiamondDogsAdvice, model.DiamondDogsAdvice);
        Assert.Equal(expectedPotentialOutcome, model.PotentialOutcome);
        Assert.Equal(expectedStepsToResolution.Count, model.StepsToResolution.Count);
        for (int i = 0; i < expectedStepsToResolution.Count; i++)
        {
            Assert.Equal(expectedStepsToResolution[i], model.StepsToResolution[i]);
        }
        Assert.Equal(expectedTedApproach, model.TedApproach);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConflictResolveResponse
        {
            BarbecueSauceWisdom =
                "You know what they say - you catch more flies with honey than vinegar. But you also gotta speak up, 'cause a closed mouth don't get fed.",
            Diagnosis =
                "This ain't really about credit, partner. It's about feeling seen and valued. When Alex takes credit, you feel invisible, and that's gonna build up like steam in a pressure cooker.",
            DiamondDogsAdvice =
                "Roy says: 'Tell them to their face.' Higgins says: 'Perhaps document your contributions in emails beforehand.' Coach Beard just nodded mysteriously and quoted Sun Tzu.",
            PotentialOutcome =
                "Y'all might discover Alex didn't even realize they were doing it. Could turn a rival into an ally, like Roy and Jamie... eventually.",
            StepsToResolution =
            [
                "Request a private, casual conversation with Alex",
                "Share how you've been feeling using 'I' statements",
                "Ask if they're aware this has been happening",
                "Propose a collaboration system where you both present together",
                "Set up a weekly sync to align on contributions",
            ],
            TedApproach =
                "I'd bring Alex a coffee, maybe a biscuit, and say 'Hey, can we chat?' No accusations, just curiosity. Ask them how they think the project's going and what they see as everyone's contributions.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConflictResolveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConflictResolveResponse
        {
            BarbecueSauceWisdom =
                "You know what they say - you catch more flies with honey than vinegar. But you also gotta speak up, 'cause a closed mouth don't get fed.",
            Diagnosis =
                "This ain't really about credit, partner. It's about feeling seen and valued. When Alex takes credit, you feel invisible, and that's gonna build up like steam in a pressure cooker.",
            DiamondDogsAdvice =
                "Roy says: 'Tell them to their face.' Higgins says: 'Perhaps document your contributions in emails beforehand.' Coach Beard just nodded mysteriously and quoted Sun Tzu.",
            PotentialOutcome =
                "Y'all might discover Alex didn't even realize they were doing it. Could turn a rival into an ally, like Roy and Jamie... eventually.",
            StepsToResolution =
            [
                "Request a private, casual conversation with Alex",
                "Share how you've been feeling using 'I' statements",
                "Ask if they're aware this has been happening",
                "Propose a collaboration system where you both present together",
                "Set up a weekly sync to align on contributions",
            ],
            TedApproach =
                "I'd bring Alex a coffee, maybe a biscuit, and say 'Hey, can we chat?' No accusations, just curiosity. Ask them how they think the project's going and what they see as everyone's contributions.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConflictResolveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBarbecueSauceWisdom =
            "You know what they say - you catch more flies with honey than vinegar. But you also gotta speak up, 'cause a closed mouth don't get fed.";
        string expectedDiagnosis =
            "This ain't really about credit, partner. It's about feeling seen and valued. When Alex takes credit, you feel invisible, and that's gonna build up like steam in a pressure cooker.";
        string expectedDiamondDogsAdvice =
            "Roy says: 'Tell them to their face.' Higgins says: 'Perhaps document your contributions in emails beforehand.' Coach Beard just nodded mysteriously and quoted Sun Tzu.";
        string expectedPotentialOutcome =
            "Y'all might discover Alex didn't even realize they were doing it. Could turn a rival into an ally, like Roy and Jamie... eventually.";
        List<string> expectedStepsToResolution =
        [
            "Request a private, casual conversation with Alex",
            "Share how you've been feeling using 'I' statements",
            "Ask if they're aware this has been happening",
            "Propose a collaboration system where you both present together",
            "Set up a weekly sync to align on contributions",
        ];
        string expectedTedApproach =
            "I'd bring Alex a coffee, maybe a biscuit, and say 'Hey, can we chat?' No accusations, just curiosity. Ask them how they think the project's going and what they see as everyone's contributions.";

        Assert.Equal(expectedBarbecueSauceWisdom, deserialized.BarbecueSauceWisdom);
        Assert.Equal(expectedDiagnosis, deserialized.Diagnosis);
        Assert.Equal(expectedDiamondDogsAdvice, deserialized.DiamondDogsAdvice);
        Assert.Equal(expectedPotentialOutcome, deserialized.PotentialOutcome);
        Assert.Equal(expectedStepsToResolution.Count, deserialized.StepsToResolution.Count);
        for (int i = 0; i < expectedStepsToResolution.Count; i++)
        {
            Assert.Equal(expectedStepsToResolution[i], deserialized.StepsToResolution[i]);
        }
        Assert.Equal(expectedTedApproach, deserialized.TedApproach);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConflictResolveResponse
        {
            BarbecueSauceWisdom =
                "You know what they say - you catch more flies with honey than vinegar. But you also gotta speak up, 'cause a closed mouth don't get fed.",
            Diagnosis =
                "This ain't really about credit, partner. It's about feeling seen and valued. When Alex takes credit, you feel invisible, and that's gonna build up like steam in a pressure cooker.",
            DiamondDogsAdvice =
                "Roy says: 'Tell them to their face.' Higgins says: 'Perhaps document your contributions in emails beforehand.' Coach Beard just nodded mysteriously and quoted Sun Tzu.",
            PotentialOutcome =
                "Y'all might discover Alex didn't even realize they were doing it. Could turn a rival into an ally, like Roy and Jamie... eventually.",
            StepsToResolution =
            [
                "Request a private, casual conversation with Alex",
                "Share how you've been feeling using 'I' statements",
                "Ask if they're aware this has been happening",
                "Propose a collaboration system where you both present together",
                "Set up a weekly sync to align on contributions",
            ],
            TedApproach =
                "I'd bring Alex a coffee, maybe a biscuit, and say 'Hey, can we chat?' No accusations, just curiosity. Ask them how they think the project's going and what they see as everyone's contributions.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConflictResolveResponse
        {
            BarbecueSauceWisdom =
                "You know what they say - you catch more flies with honey than vinegar. But you also gotta speak up, 'cause a closed mouth don't get fed.",
            Diagnosis =
                "This ain't really about credit, partner. It's about feeling seen and valued. When Alex takes credit, you feel invisible, and that's gonna build up like steam in a pressure cooker.",
            DiamondDogsAdvice =
                "Roy says: 'Tell them to their face.' Higgins says: 'Perhaps document your contributions in emails beforehand.' Coach Beard just nodded mysteriously and quoted Sun Tzu.",
            PotentialOutcome =
                "Y'all might discover Alex didn't even realize they were doing it. Could turn a rival into an ally, like Roy and Jamie... eventually.",
            StepsToResolution =
            [
                "Request a private, casual conversation with Alex",
                "Share how you've been feeling using 'I' statements",
                "Ask if they're aware this has been happening",
                "Propose a collaboration system where you both present together",
                "Set up a weekly sync to align on contributions",
            ],
            TedApproach =
                "I'd bring Alex a coffee, maybe a biscuit, and say 'Hey, can we chat?' No accusations, just curiosity. Ask them how they think the project's going and what they see as everyone's contributions.",
        };

        ConflictResolveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

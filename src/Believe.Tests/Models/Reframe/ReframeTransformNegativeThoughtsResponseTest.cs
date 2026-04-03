using System.Text.Json;
using Believe.Core;
using Believe.Models.Reframe;

namespace Believe.Tests.Models.Reframe;

public class ReframeTransformNegativeThoughtsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",DrSharonInsight = "This thought pattern often stems from comparing your internal experience to others' external presentations. Consider: what evidence do you have that contradicts this belief?",
        };

        string expectedDailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.";
        string expectedOriginalThought = "I'm not good enough for this job.";
        string expectedReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.";
        string expectedTedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.";
        string expectedDrSharonInsight = "This thought pattern often stems from comparing your internal experience to others' external presentations. Consider: what evidence do you have that contradicts this belief?";

        Assert.Equal(expectedDailyAffirmation, model.DailyAffirmation);
        Assert.Equal(expectedOriginalThought, model.OriginalThought);
        Assert.Equal(expectedReframedThought, model.ReframedThought);
        Assert.Equal(expectedTedPerspective, model.TedPerspective);
        Assert.Equal(expectedDrSharonInsight, model.DrSharonInsight);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",DrSharonInsight = "This thought pattern often stems from comparing your internal experience to others' external presentations. Consider: what evidence do you have that contradicts this belief?",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReframeTransformNegativeThoughtsResponse>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",DrSharonInsight = "This thought pattern often stems from comparing your internal experience to others' external presentations. Consider: what evidence do you have that contradicts this belief?",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReframeTransformNegativeThoughtsResponse>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.";
        string expectedOriginalThought = "I'm not good enough for this job.";
        string expectedReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.";
        string expectedTedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.";
        string expectedDrSharonInsight = "This thought pattern often stems from comparing your internal experience to others' external presentations. Consider: what evidence do you have that contradicts this belief?";

        Assert.Equal(expectedDailyAffirmation, deserialized.DailyAffirmation);
        Assert.Equal(expectedOriginalThought, deserialized.OriginalThought);
        Assert.Equal(expectedReframedThought, deserialized.ReframedThought);
        Assert.Equal(expectedTedPerspective, deserialized.TedPerspective);
        Assert.Equal(expectedDrSharonInsight, deserialized.DrSharonInsight);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",DrSharonInsight = "This thought pattern often stems from comparing your internal experience to others' external presentations. Consider: what evidence do you have that contradicts this belief?",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",
        };

        Assert.Null(model.DrSharonInsight);
        Assert.False(model.RawData.ContainsKey("dr_sharon_insight"));

    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",

            DrSharonInsight = null,
        };

        Assert.Null(model.DrSharonInsight);
        Assert.True(model.RawData.ContainsKey("dr_sharon_insight"));

    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",

            DrSharonInsight = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReframeTransformNegativeThoughtsResponse
        {
            DailyAffirmation = "I am capable, I am learning, and I belong exactly where I am.",OriginalThought = "I'm not good enough for this job.",ReframedThought = "I'm still learning and growing in this role, and that's exactly where I should be.",TedPerspective = "You know what? Imposter syndrome is just your brain's way of telling you that you care. The folks who think they know everything? They're the ones you gotta worry about. You questioning yourself means you're paying attention.",DrSharonInsight = "This thought pattern often stems from comparing your internal experience to others' external presentations. Consider: what evidence do you have that contradicts this belief?",
        };

        ReframeTransformNegativeThoughtsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
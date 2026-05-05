using System;
using Believe.Client.Models.Reframe;

namespace Believe.Client.Tests.Models.Reframe;

public class ReframeTransformNegativeThoughtsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReframeTransformNegativeThoughtsParams
        {
            NegativeThought = "I'm not good enough for this job.",
            Recurring = true,
        };

        string expectedNegativeThought = "I'm not good enough for this job.";
        bool expectedRecurring = true;

        Assert.Equal(expectedNegativeThought, parameters.NegativeThought);
        Assert.Equal(expectedRecurring, parameters.Recurring);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReframeTransformNegativeThoughtsParams
        {
            NegativeThought = "I'm not good enough for this job.",
        };

        Assert.Null(parameters.Recurring);
        Assert.False(parameters.RawBodyData.ContainsKey("recurring"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReframeTransformNegativeThoughtsParams
        {
            NegativeThought = "I'm not good enough for this job.",

            // Null should be interpreted as omitted for these properties
            Recurring = null,
        };

        Assert.Null(parameters.Recurring);
        Assert.False(parameters.RawBodyData.ContainsKey("recurring"));
    }

    [Fact]
    public void Url_Works()
    {
        ReframeTransformNegativeThoughtsParams parameters = new()
        {
            NegativeThought = "I'm not good enough for this job.",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://believe.cjav.dev/reframe"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ReframeTransformNegativeThoughtsParams
        {
            NegativeThought = "I'm not good enough for this job.",
            Recurring = true,
        };

        ReframeTransformNegativeThoughtsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

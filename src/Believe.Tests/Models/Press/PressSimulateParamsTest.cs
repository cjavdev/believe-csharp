using System;
using Believe.Models.Press;

namespace Believe.Tests.Models.Press;

public class PressSimulateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new PressSimulateParams
        {
            Question = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",Hostile = true,Topic = "match_result",
        };

        string expectedQuestion = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?";
        bool expectedHostile = true;
        string expectedTopic = "match_result";

        Assert.Equal(expectedQuestion, parameters.Question);
        Assert.Equal(expectedHostile, parameters.Hostile);
        Assert.Equal(expectedTopic, parameters.Topic);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {


        var parameters = new PressSimulateParams
        {
            Question = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",Topic = "match_result",
        };

        Assert.Null(parameters.Hostile);
        Assert.False(parameters.RawBodyData.ContainsKey("hostile"));

    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {


        var parameters = new PressSimulateParams
        {
            Question = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",Topic = "match_result",

            // Null should be interpreted as omitted for these properties
            Hostile = null,
        };

        Assert.Null(parameters.Hostile);
        Assert.False(parameters.RawBodyData.ContainsKey("hostile"));

    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {


        var parameters = new PressSimulateParams
        {
            Question = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",Hostile = true,
        };

        Assert.Null(parameters.Topic);
        Assert.False(parameters.RawBodyData.ContainsKey("topic"));

    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {


        var parameters = new PressSimulateParams
        {
            Question = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",Hostile = true,

            Topic = null,
        };

        Assert.Null(parameters.Topic);
        Assert.True(parameters.RawBodyData.ContainsKey("topic"));

    }

    [Fact]
    public void Url_Works()
    {
        PressSimulateParams parameters = new()
        {
            Question = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",
        };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/press"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PressSimulateParams
        {
            Question = "Ted, your team just lost 5-0. How do you explain this embarrassing defeat?",
            Hostile = true,
            Topic = "match_result",
        };

        PressSimulateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
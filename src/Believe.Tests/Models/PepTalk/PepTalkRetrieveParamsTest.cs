using System;
using Believe.Models.PepTalk;

namespace Believe.Tests.Models.PepTalk;

public class PepTalkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PepTalkRetrieveParams { Stream = true };

        bool expectedStream = true;

        Assert.Equal(expectedStream, parameters.Stream);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PepTalkRetrieveParams { };

        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawQueryData.ContainsKey("stream"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PepTalkRetrieveParams
        {
            // Null should be interpreted as omitted for these properties
            Stream = null,
        };

        Assert.Null(parameters.Stream);
        Assert.False(parameters.RawQueryData.ContainsKey("stream"));
    }

    [Fact]
    public void Url_Works()
    {
        PepTalkRetrieveParams parameters = new() { Stream = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/pep-talk?stream=true"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PepTalkRetrieveParams { Stream = true };

        PepTalkRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

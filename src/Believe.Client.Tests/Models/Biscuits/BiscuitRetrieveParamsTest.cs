using System;
using Believe.Client.Models.Biscuits;

namespace Believe.Client.Tests.Models.Biscuits;

public class BiscuitRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BiscuitRetrieveParams { BiscuitID = "biscuit_id" };

        string expectedBiscuitID = "biscuit_id";

        Assert.Equal(expectedBiscuitID, parameters.BiscuitID);
    }

    [Fact]
    public void Url_Works()
    {
        BiscuitRetrieveParams parameters = new() { BiscuitID = "biscuit_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://believe.cjav.dev/biscuits/biscuit_id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BiscuitRetrieveParams { BiscuitID = "biscuit_id" };

        BiscuitRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

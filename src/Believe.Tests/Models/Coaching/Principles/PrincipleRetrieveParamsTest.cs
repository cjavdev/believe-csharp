using System;
using Believe.Models.Coaching.Principles;

namespace Believe.Tests.Models.Coaching.Principles;

public class PrincipleRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PrincipleRetrieveParams { PrincipleID = "principle_id" };

        string expectedPrincipleID = "principle_id";

        Assert.Equal(expectedPrincipleID, parameters.PrincipleID);
    }

    [Fact]
    public void Url_Works()
    {
        PrincipleRetrieveParams parameters = new() { PrincipleID = "principle_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://believe.cjav.dev/coaching/principles/principle_id"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PrincipleRetrieveParams { PrincipleID = "principle_id" };

        PrincipleRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

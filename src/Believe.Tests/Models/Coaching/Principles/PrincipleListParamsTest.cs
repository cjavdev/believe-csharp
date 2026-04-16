using System;
using Believe.Models.Coaching.Principles;

namespace Believe.Tests.Models.Coaching.Principles;

public class PrincipleListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PrincipleListParams { Limit = 10, Skip = 0 };

        long expectedLimit = 10;
        long expectedSkip = 0;

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSkip, parameters.Skip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PrincipleListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PrincipleListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Skip = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void Url_Works()
    {
        PrincipleListParams parameters = new() { Limit = 10, Skip = 0 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://believe.cjav.dev/coaching/principles?limit=10&skip=0"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PrincipleListParams { Limit = 10, Skip = 0 };

        PrincipleListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

using System;
using Believe.Core;
using Believe.Models.Quotes;

namespace Believe.Tests.Models.Quotes;

public class QuoteListByThemeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QuoteListByThemeParams
        {
            Theme = QuoteTheme.Belief,
            Limit = 10,
            Skip = 0,
        };

        ApiEnum<string, QuoteTheme> expectedTheme = QuoteTheme.Belief;
        long expectedLimit = 10;
        long expectedSkip = 0;

        Assert.Equal(expectedTheme, parameters.Theme);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSkip, parameters.Skip);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QuoteListByThemeParams { Theme = QuoteTheme.Belief };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Skip);
        Assert.False(parameters.RawQueryData.ContainsKey("skip"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new QuoteListByThemeParams
        {
            Theme = QuoteTheme.Belief,

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
        QuoteListByThemeParams parameters = new()
        {
            Theme = QuoteTheme.Belief,
            Limit = 10,
            Skip = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://believe.cjav.dev/quotes/themes/belief?limit=10&skip=0"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QuoteListByThemeParams
        {
            Theme = QuoteTheme.Belief,
            Limit = 10,
            Skip = 0,
        };

        QuoteListByThemeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

using System;
using Believe.Models.Matches;

namespace Believe.Tests.Models.Matches;

public class MatchGetTurningPointsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MatchGetTurningPointsParams { MatchID = "match_id" };

        string expectedMatchID = "match_id";

        Assert.Equal(expectedMatchID, parameters.MatchID);
    }

    [Fact]
    public void Url_Works()
    {
        MatchGetTurningPointsParams parameters = new() { MatchID = "match_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://believe.cjav.dev/matches/match_id/turning-points"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MatchGetTurningPointsParams { MatchID = "match_id" };

        MatchGetTurningPointsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

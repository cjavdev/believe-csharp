using System;
using Believe.Models.Matches.Commentary;

namespace Believe.Tests.Models.Matches.Commentary;

public class CommentaryStreamParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {


        var parameters = new CommentaryStreamParams
        {
            MatchID = "match_id",
        };

        string expectedMatchID = "match_id";

        Assert.Equal(expectedMatchID, parameters.MatchID);
    }

    [Fact]
    public void Url_Works()
    {
        CommentaryStreamParams parameters = new() { MatchID = "match_id" };

        var url = parameters.Url(
            new()
            {
                ApiKey = "My API Key"
            }
        );

        Assert.Equal(new Uri("https://believe.cjav.dev/matches/match_id/commentary/stream"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CommentaryStreamParams
        {
            MatchID = "match_id"
        };

        CommentaryStreamParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
using System;
using Believe.Models.Episodes;

namespace Believe.Tests.Models.Episodes;

public class EpisodeRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeRetrieveParams { EpisodeID = "episode_id" };

        string expectedEpisodeID = "episode_id";

        Assert.Equal(expectedEpisodeID, parameters.EpisodeID);
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeRetrieveParams parameters = new() { EpisodeID = "episode_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://believe.cjav.dev/episodes/episode_id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeRetrieveParams { EpisodeID = "episode_id" };

        EpisodeRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

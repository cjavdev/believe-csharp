using System;
using Believe.Models.Episodes;

namespace Believe.Tests.Models.Episodes;

public class EpisodeGetWisdomParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeGetWisdomParams { EpisodeID = "episode_id" };

        string expectedEpisodeID = "episode_id";

        Assert.Equal(expectedEpisodeID, parameters.EpisodeID);
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeGetWisdomParams parameters = new() { EpisodeID = "episode_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://believe.cjav.dev/episodes/episode_id/wisdom"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeGetWisdomParams { EpisodeID = "episode_id" };

        EpisodeGetWisdomParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

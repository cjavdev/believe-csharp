using System;
using Believe;

namespace Believe.Tests;

public class TestBase
{
    protected IBelieveClient client;

    public TestBase()
    {
        client = new BelieveClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}

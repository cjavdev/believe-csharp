using System;
using Believe.Client.Models.TeamMembers;

namespace Believe.Client.Tests.Models.TeamMembers;

public class TeamMemberDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TeamMemberDeleteParams { MemberID = "member_id" };

        string expectedMemberID = "member_id";

        Assert.Equal(expectedMemberID, parameters.MemberID);
    }

    [Fact]
    public void Url_Works()
    {
        TeamMemberDeleteParams parameters = new() { MemberID = "member_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://believe.cjav.dev/team-members/member_id"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TeamMemberDeleteParams { MemberID = "member_id" };

        TeamMemberDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

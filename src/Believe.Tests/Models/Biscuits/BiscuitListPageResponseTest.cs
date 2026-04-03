using System.Collections.Generic;
using System.Text.Json;
using Believe.Core;
using Believe.Models.Biscuits;

namespace Believe.Tests.Models.Biscuits;

public class BiscuitListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BiscuitListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "biscuit-001",
                    Message = "Sometimes the best thing you can do is just show up with something warm.",
                    PairsWellWith = "A hot cup of tea and an honest conversation",
                    TedNote = "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
                    Type = Type.Shortbread,
                    WarmthLevel = 9,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        List<Biscuit> expectedData =
        [
            new()
            {
                ID = "biscuit-001",
                Message = "Sometimes the best thing you can do is just show up with something warm.",
                PairsWellWith = "A hot cup of tea and an honest conversation",
                TedNote = "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
                Type = Type.Shortbread,
                WarmthLevel = 9,
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedPage, model.Page);
        Assert.Equal(expectedPages, model.Pages);
        Assert.Equal(expectedSkip, model.Skip);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BiscuitListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "biscuit-001",
                    Message = "Sometimes the best thing you can do is just show up with something warm.",
                    PairsWellWith = "A hot cup of tea and an honest conversation",
                    TedNote = "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
                    Type = Type.Shortbread,
                    WarmthLevel = 9,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BiscuitListPageResponse>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BiscuitListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "biscuit-001",
                    Message = "Sometimes the best thing you can do is just show up with something warm.",
                    PairsWellWith = "A hot cup of tea and an honest conversation",
                    TedNote = "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
                    Type = Type.Shortbread,
                    WarmthLevel = 9,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BiscuitListPageResponse>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Biscuit> expectedData =
        [
            new()
            {
                ID = "biscuit-001",
                Message = "Sometimes the best thing you can do is just show up with something warm.",
                PairsWellWith = "A hot cup of tea and an honest conversation",
                TedNote = "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
                Type = Type.Shortbread,
                WarmthLevel = 9,
            },
        ];
        bool expectedHasMore = true;
        long expectedLimit = 0;
        long expectedPage = 0;
        long expectedPages = 0;
        long expectedSkip = 0;
        long expectedTotal = 0;

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedPage, deserialized.Page);
        Assert.Equal(expectedPages, deserialized.Pages);
        Assert.Equal(expectedSkip, deserialized.Skip);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BiscuitListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "biscuit-001",
                    Message = "Sometimes the best thing you can do is just show up with something warm.",
                    PairsWellWith = "A hot cup of tea and an honest conversation",
                    TedNote = "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
                    Type = Type.Shortbread,
                    WarmthLevel = 9,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BiscuitListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "biscuit-001",
                    Message = "Sometimes the best thing you can do is just show up with something warm.",
                    PairsWellWith = "A hot cup of tea and an honest conversation",
                    TedNote = "Made these thinking about you. Hope your day is as sweet as these little fellas. - Ted",
                    Type = Type.Shortbread,
                    WarmthLevel = 9,
                },
            ],HasMore = true,Limit = 0,Page = 0,Pages = 0,Skip = 0,Total = 0,
        };

        BiscuitListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
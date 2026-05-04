using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Believe.Core;

namespace Believe.Models.Matches;

/// <summary>
/// WebSocket endpoint for real-time live match simulation.
///
/// <para>Connect to receive a stream of match events as they happen in a simulated
/// football match.</para>
///
/// <para>## Connection</para>
///
/// <para>Connect via WebSocket with optional query parameters to customize the simulation.</para>
///
/// <para>## Example WebSocket URL</para>
///
/// <para>``` ws://localhost:8000/matches/live ```</para>
///
/// <para>Append query parameters from the list above to customize the simulation.</para>
///
/// <para>## Server Messages</para>
///
/// <para>The server sends JSON messages with these types: - `match_start` - When
/// the match begins - `match_event` - For each match event (goals, fouls, cards,
/// etc.) - `match_end` - When the match concludes - `error` - If an error occurs
/// - `pong` - Response to client ping</para>
///
/// <para>## Client Messages</para>
///
/// <para>Send JSON to control the simulation: - `{"action": "ping"}` - Keep-alive,
/// server responds with `{"type": "pong"}` - `{"action": "pause"}` - Pause the simulation
/// - `{"action": "resume"}` - Resume a paused simulation - `{"action": "set_speed",
/// "speed": 2.0}` - Change playback speed (0.1-10.0) - `{"action": "get_status"}`
/// - Request current match status</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MatchStreamLiveParams : ParamsBase
{
    /// <summary>
    /// Away team name
    /// </summary>
    public string? AwayTeam
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("away_team");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("away_team", value);
        }
    }

    /// <summary>
    /// How eventful the match should be (1=boring, 10=chaos)
    /// </summary>
    public long? ExcitementLevel
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("excitement_level");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("excitement_level", value);
        }
    }

    /// <summary>
    /// Home team name
    /// </summary>
    public string? HomeTeam
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("home_team");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("home_team", value);
        }
    }

    /// <summary>
    /// Simulation speed multiplier (1.0 = real-time)
    /// </summary>
    public double? Speed
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<double>("speed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("speed", value);
        }
    }

    public MatchStreamLiveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MatchStreamLiveParams(MatchStreamLiveParams matchStreamLiveParams)
        : base(matchStreamLiveParams) { }
#pragma warning restore CS8618

    public MatchStreamLiveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MatchStreamLiveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MatchStreamLiveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MatchStreamLiveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/matches/live")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

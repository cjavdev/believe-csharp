using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Believe.Core;

namespace Believe.Models.Teams;

/// <summary>
/// Full team model with ID.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Team, TeamFromRaw>))]
public sealed record class Team : JsonModel
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Team culture/morale score (0-100)
    /// </summary>
    public required long CultureScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("culture_score");
        }
        init { this._rawData.Set("culture_score", value); }
    }

    /// <summary>
    /// Year the club was founded
    /// </summary>
    public required long FoundedYear
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("founded_year");
        }
        init { this._rawData.Set("founded_year", value); }
    }

    /// <summary>
    /// Current league
    /// </summary>
    public required ApiEnum<string, League> League
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, League>>("league");
        }
        init { this._rawData.Set("league", value); }
    }

    /// <summary>
    /// Team name
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Home stadium name
    /// </summary>
    public required string Stadium
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("stadium");
        }
        init { this._rawData.Set("stadium", value); }
    }

    /// <summary>
    /// Team's core values
    /// </summary>
    public required TeamValues Values
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TeamValues>("values");
        }
        init { this._rawData.Set("values", value); }
    }

    /// <summary>
    /// Annual budget in GBP
    /// </summary>
    public string? AnnualBudgetGbp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("annual_budget_gbp");
        }
        init { this._rawData.Set("annual_budget_gbp", value); }
    }

    /// <summary>
    /// Average match attendance
    /// </summary>
    public double? AverageAttendance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("average_attendance");
        }
        init { this._rawData.Set("average_attendance", value); }
    }

    /// <summary>
    /// Team contact email
    /// </summary>
    public string? ContactEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contact_email");
        }
        init { this._rawData.Set("contact_email", value); }
    }

    /// <summary>
    /// Whether the team is currently active
    /// </summary>
    public bool? IsActive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_active", value);
        }
    }

    /// <summary>
    /// Team nickname
    /// </summary>
    public string? Nickname
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nickname");
        }
        init { this._rawData.Set("nickname", value); }
    }

    /// <summary>
    /// Primary team color (hex)
    /// </summary>
    public string? PrimaryColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("primary_color");
        }
        init { this._rawData.Set("primary_color", value); }
    }

    /// <summary>
    /// List of rival team IDs
    /// </summary>
    public IReadOnlyList<string>? RivalTeams
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("rival_teams");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "rival_teams",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Secondary team color (hex)
    /// </summary>
    public string? SecondaryColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("secondary_color");
        }
        init { this._rawData.Set("secondary_color", value); }
    }

    /// <summary>
    /// Geographic coordinates for a location.
    /// </summary>
    public GeoLocation? StadiumLocation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GeoLocation>("stadium_location");
        }
        init { this._rawData.Set("stadium_location", value); }
    }

    /// <summary>
    /// Official team website
    /// </summary>
    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    /// <summary>
    /// Season win percentage
    /// </summary>
    public double? WinPercentage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("win_percentage");
        }
        init { this._rawData.Set("win_percentage", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CultureScore;
        _ = this.FoundedYear;
        this.League.Validate();
        _ = this.Name;
        _ = this.Stadium;
        this.Values.Validate();
        _ = this.AnnualBudgetGbp;
        _ = this.AverageAttendance;
        _ = this.ContactEmail;
        _ = this.IsActive;
        _ = this.Nickname;
        _ = this.PrimaryColor;
        _ = this.RivalTeams;
        _ = this.SecondaryColor;
        this.StadiumLocation?.Validate();
        _ = this.Website;
        _ = this.WinPercentage;
    }

    public Team() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Team(Team team)
        : base(team) { }
#pragma warning restore CS8618

    public Team(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Team(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamFromRaw.FromRawUnchecked"/>
    public static Team FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamFromRaw : IFromRawJson<Team>
{
    /// <inheritdoc/>
    public Team FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Team.FromRawUnchecked(rawData);
}

using IDFStrikeOps.Entities;
using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Services;

/// <summary>
/// A service class for the intelligence services.
/// </summary>
internal class IntelService : IIntelAnalyzer
{
    // <inheridoc/>
    public TargetType? GetLastKnownLocation(Terrorist terrorist, Dictionary<string, List<IntelligenceMessage>> messages)
    {
        return messages
            .Where(t => t.Key == terrorist.Name)
            .FirstOrDefault()
            .Value.OrderByDescending(t => t.TimeStamp)
            .FirstOrDefault()!.LocationType;
    }

    // <inheridoc/>
    public string GetMostTrackedTerrorist(Dictionary<string, List<IntelligenceMessage>> messages)
    {
        return messages.Aggregate((x, y) => x.Value.Count > y.Value.Count ? x : y).Key;
    }

    /// <summary>
    /// Calculating the quality score (dangerous level) of a terrorist.
    /// </summary>
    /// <param name="terrorist">Terrorist to assess.</param>
    /// <returns>The quality score.</returns>
    private int CalcQualityScore(Terrorist terrorist)
    {
        return (int)terrorist.Rank * ((int)terrorist.Weapons.Aggregate((x, y) => (int)x + y));
    }

    // <inheridoc/>
    public string PrioritizeTarget(List<Terrorist> terrorists)
    {
        string result = "The most dangerous terrorist is:\n";
        int scoreResult = 0;
        IEnumerable<Terrorist> liveTerrorists = terrorists.Where(t => t.IsAlive);
        
        if (terrorists.Count == 0)
            return "No live terrorist in the organization.";

        Terrorist? mostDangerous = terrorists.FirstOrDefault() ?? null;
        foreach (var terrorist in liveTerrorists)
        {
            int QualityScore = CalcQualityScore(terrorist);
            if (QualityScore > scoreResult)
            {
                scoreResult = QualityScore;
                mostDangerous = terrorist;
            }
        }
        return result += (mostDangerous ?? null)  + $"\nQuality score: {scoreResult}";
    }
}

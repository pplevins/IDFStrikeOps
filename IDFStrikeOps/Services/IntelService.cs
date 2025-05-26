using IDFStrikeOps.Entities;
using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Services;

internal class IntelService : IIntelAnalyzer
{
    public TargetType GetLastKnownLocation(Terrorist terrorist)
    {
        throw new NotImplementedException();
    }

    public string GetMostTrackedTerrorist(Dictionary<string, List<IntelligenceMessage>> messages)
    {
        return messages.Aggregate((x, y) => x.Value.Count > y.Value.Count ? x : y).Key;
    }

    public string PrioritizeTarget(List<Terrorist> terrorists)
    {
        string result = "The most dangerous terrorist is:\n";
        int scoreResult = 0;
        Terrorist? mostDangerous = terrorists.FirstOrDefault() ?? null;
        foreach (var terrorist in terrorists)
        {
            int QualityScore = (int)terrorist.Rank * ((int)terrorist.Weapons.Aggregate((x, y) => (int)x + y));
            if (QualityScore > scoreResult)
            {
                scoreResult = QualityScore;
                mostDangerous = terrorist;
            }
        }
        return result += (mostDangerous ?? null)  + $"\nQuality score: {scoreResult}";
    }
}

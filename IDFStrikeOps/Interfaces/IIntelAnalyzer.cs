using IDFStrikeOps.Entities;

namespace IDFStrikeOps.Interfaces;

internal interface IIntelAnalyzer
{
    public string GetMostTrackedTerrorist(Dictionary<string, List<IntelligenceMessage>> messages);

    public string PrioritizeTarget(List<Terrorist> terrorists);

    public TargetType? GetLastKnownLocation(Terrorist terrorist, Dictionary<string, List<IntelligenceMessage>> messages);
}

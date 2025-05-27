using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities;

internal class Aman
{
    public Dictionary<string, List<IntelligenceMessage>> TerroristIntells { get; set; }
    public IIntelAnalyzer IntelAnalyzer { get; }

    public Aman(IIntelAnalyzer analyzer) 
    {
        TerroristIntells = [];
        IntelAnalyzer = analyzer;
    }

    public void AddIntel(string terrorist, IntelligenceMessage intel)
    {
        if (TerroristIntells.ContainsKey(terrorist))
            TerroristIntells[terrorist].Add(intel);
        else
            TerroristIntells[terrorist] = [intel];
    }

    public string GetMostTrackedTerrorist()
    {
        return IntelAnalyzer.GetMostTrackedTerrorist(TerroristIntells);
    }

    public TargetType GetLastKnownLocation(Terrorist terrorist)
    {
        TargetType? location = IntelAnalyzer.GetLastKnownLocation(terrorist, TerroristIntells);
        return location ?? throw new NullReferenceException($"No known location for {terrorist.Name}");
    }
}

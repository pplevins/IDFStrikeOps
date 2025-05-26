using IDFStrikeOps.Interfaces;
using System.ComponentModel.Design;

namespace IDFStrikeOps.Entities;

internal class Aman
{
    Dictionary<string, List<IntelligenceMessage>> TerroristIntells { get; set; }
    public IIntelAnalyzer IntelAnalyzer { get; }

    public Aman(IIntelAnalyzer analyzer) 
    {
        TerroristIntells = [];
        IntelAnalyzer = analyzer;
    }
    // TODO: Check correctness at runtime.
    public void AddIntel(string terrorist, IntelligenceMessage intel)
    {
        if (TerroristIntells.ContainsKey(terrorist))
            TerroristIntells[terrorist].Add(intel);
        else
        {
            TerroristIntells[terrorist] = [intel];
        }
    }

    public string GetMostTrackedTerrorist()
    {
        return IntelAnalyzer.GetMostTrackedTerrorist(TerroristIntells);
    }
}

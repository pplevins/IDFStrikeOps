using IDFStrikeOps.Interfaces;
using IDFStrikeOps.Services;

namespace IDFStrikeOps.Entities;

internal class Aman
{
    Dictionary<string, List<IntelligenceMessage>> TerroristIntells { get; set; }
    IIntelAnalyzer IntelAnalyzer { get; }

    public Aman() 
    {
        TerroristIntells = [];
        IntelAnalyzer = new IntelService();
    }
    // TODO: Check correctness at runtime.
    public void AddIntel(string terrorist, IntelligenceMessage intel) => TerroristIntells[terrorist].Add(intel);
}

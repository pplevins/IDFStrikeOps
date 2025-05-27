using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities;

/// <summary>
/// Class representing the AMAN Military Intelligence.
/// </summary>
internal class Aman
{
    /// <summary>
    /// Dictionary of terrorist's intelligence messages.
    /// </summary>
    public Dictionary<string, List<IntelligenceMessage>> TerroristIntells { get; set; }

    /// <summary>
    /// Instance of the intelligence service.
    /// </summary>
    public IIntelAnalyzer IntelAnalyzer { get; }

    /// <summary>
    /// Constructor for Aman
    /// </summary>
    /// <param name="analyzer">intelligence analyzer service for Aman.</param>
    public Aman(IIntelAnalyzer analyzer) 
    {
        TerroristIntells = [];
        IntelAnalyzer = analyzer;
    }

    /// <summary>
    /// Adding intelligence message to the dictionary.
    /// </summary>
    /// <param name="terrorist">Name of the terrorist.</param>
    /// <param name="intel">The message to add.</param>
    public void AddIntel(string terrorist, IntelligenceMessage intel)
    {
        if (TerroristIntells.ContainsKey(terrorist))
            TerroristIntells[terrorist].Add(intel);
        else
            TerroristIntells[terrorist] = [intel];
    }

    /// <summary>
    /// Gets the terrorist with the most intells.
    /// </summary>
    /// <returns>The name of the terrorist</returns>
    public string GetMostTrackedTerrorist()
    {
        return IntelAnalyzer.GetMostTrackedTerrorist(TerroristIntells);
    }

    /// <summary>
    /// Gets the last known location of a terrorist from intel.
    /// </summary>
    /// <param name="terrorist">Terrorist to find.</param>
    /// <returns>The location type of the terrorist.</returns>
    /// <exception cref="NullReferenceException">In Case of the terrorist not found.</exception>
    public TargetType GetLastKnownLocation(Terrorist terrorist)
    {
        TargetType? location = IntelAnalyzer.GetLastKnownLocation(terrorist, TerroristIntells);
        return location ?? throw new NullReferenceException($"No known location for {terrorist.Name}");
    }
}

using IDFStrikeOps.Entities;

namespace IDFStrikeOps.Interfaces;

/// <summary>
/// Interface for a intelligence operations and services.
/// </summary>
internal interface IIntelAnalyzer
{
    /// <summary>
    /// Getting the terrorist with the most intelligence messages.
    /// </summary>
    /// <param name="messages">The messages archive.</param>
    /// <returns>The terrorist name.</returns>
    public string GetMostTrackedTerrorist(Dictionary<string, List<IntelligenceMessage>> messages);
    
    /// <summary>
    /// Proiritizing the most dangerous target.
    /// </summary>
    /// <param name="terrorists">The terrorist list.</param>
    /// <returns>The terrorist's data.</returns>
    public string PrioritizeTarget(List<Terrorist> terrorists);

    /// <summary>
    /// Gets the last known location type of a terrorist form the intel.
    /// </summary>
    /// <param name="terrorist"></param>
    /// <param name="messages"></param>
    /// <returns>The terrorist's location.</returns>
    public TargetType? GetLastKnownLocation(Terrorist terrorist, Dictionary<string, List<IntelligenceMessage>> messages);
}

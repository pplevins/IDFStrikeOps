using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities;

/// <summary>
/// Record of strike report.
/// </summary>
/// <param name="TerroristName">Target terrorist</param>
/// <param name="ExecutionTime">Time of order</param>
/// <param name="OfficerName">Commandor name</param>
/// <param name="StrikeUnitUsed">Strike unit used for the strike</param>
/// <param name="Success">result of the strike</param>
/// <param name="RemainingAmmo">remaining ammunition in the strike unit.</param>
internal record StrikeReport
(
    string TerroristName,
    DateTime ExecutionTime,
    string OfficerName,
    IStrikeUnit StrikeUnitUsed,
    bool Success,
    int RemainingAmmo
)
{
    
}

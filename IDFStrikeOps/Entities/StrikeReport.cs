using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities;

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

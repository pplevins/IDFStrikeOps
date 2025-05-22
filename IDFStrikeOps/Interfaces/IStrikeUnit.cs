using IDFStrikeOps.Entities;

namespace IDFStrikeOps.Interfaces;

internal interface IStrikeUnit
{
    string Name { get; }
    int AmmoCapacity { get; }
    double FuelSupply { get; }
    TargetType[] EffectiveAgainst { get; }

    bool Strike();

    void Refuel(double amount);
    bool IsEffective(TargetType target);
    StrikeReport GenerateReport(bool strikeSucceeded);
}

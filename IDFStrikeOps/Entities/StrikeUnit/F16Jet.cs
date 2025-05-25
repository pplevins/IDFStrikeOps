using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

internal class F16Jet : StrikeUnitBase, IStrikeUnit
{
    public F16Jet(string name) : base(name)
    {
        ammoCapacity = 8;
        fuelSupply = 1000;
        effectiveAgainst = [TargetType.Building];
    }

    public string Name => name;

    public int AmmoCapacity => ammoCapacity;

    public double FuelSupply => fuelSupply;

    public TargetType[] EffectiveAgainst => effectiveAgainst;

    public StrikeReport GenerateReport(bool strikeSucceeded)
    {
        throw new NotImplementedException();
    }

    public bool IsEffective(TargetType target)
    {
        throw new NotImplementedException();
    }

    public void Refuel(double value)
    {
        throw new NotImplementedException();
    }

    public bool Strike()
    {
        throw new NotImplementedException();
    }
}

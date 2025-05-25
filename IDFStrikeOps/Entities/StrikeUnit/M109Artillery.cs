using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

internal class M109Artillery : StrikeUnitBase, IStrikeUnit
{
    public M109Artillery(string name) : base(name)
    {
        effectiveAgainst = [TargetType.Person];
        ammoCapacity = 40;
        fuelSupply = 100;
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

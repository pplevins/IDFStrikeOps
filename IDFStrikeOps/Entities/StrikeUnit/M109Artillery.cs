using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

internal class M109Artillery : StrikeUnitBase, IStrikeUnit
{
    protected M109Artillery(string name) : base(name)
    {
    }

    public string Name => throw new NotImplementedException();

    public int AmmoCapacity => throw new NotImplementedException();

    public double FuelSupply => throw new NotImplementedException();

    public TargetType[] EffectiveAgainst => throw new NotImplementedException();

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

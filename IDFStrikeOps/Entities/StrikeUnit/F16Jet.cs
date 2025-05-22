using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

internal class F16Jet : StrikeUnitBase, IStrikeUnit
{
    protected F16Jet(string name) : base(name)
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

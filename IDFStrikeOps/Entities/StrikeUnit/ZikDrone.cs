using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

internal class ZikDrone : StrikeUnitBase, IStrikeUnit
{
    public ZikDrone(string name) : base(name)
    {
        ammoCapacity = 3;
        fuelSupply = 50;
        effectiveAgainst = [TargetType.Person, TargetType.Vehicle];
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

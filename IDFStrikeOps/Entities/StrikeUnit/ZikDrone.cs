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

    public double FuelSupply
    {
        get => fuelSupply;
        set => fuelSupply = value;
    }

    public TargetType[] EffectiveAgainst => effectiveAgainst;

    public bool IsEffective(TargetType target)
    {
        return EffectiveAgainst.Contains(target);
    }

    public bool IsFunctional()
    {
        if (FuelSupply < 10)
            Refuel(50 - FuelSupply);
        return AmmoCapacity >= 3;
    }

    public void Refuel(double value)
    {
        FuelSupply += value;
    }

    public bool Strike()
    {
        FuelSupply -= 5;
        return this.StrikeLogic();
    }
}

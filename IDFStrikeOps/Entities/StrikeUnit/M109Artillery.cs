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
        if (FuelSupply < 20)
            Refuel(100 - FuelSupply);
        return AmmoCapacity >= 3;
    }

    public void Refuel(double value)
    {
        FuelSupply += value;
    }

    public bool Strike()
    {
        FuelSupply -= 10;
        return this.StrikeLogic();
    }
}

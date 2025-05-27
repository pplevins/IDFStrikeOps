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
        if (FuelSupply < 300)
            Refuel(1000 - FuelSupply);
        return AmmoCapacity >= 3;
    }

    public void Refuel(double value)
    {
        FuelSupply += value;
    }

    public bool Strike()
    {
        FuelSupply -= 100;
        return this.StrikeLogic();
    }
}

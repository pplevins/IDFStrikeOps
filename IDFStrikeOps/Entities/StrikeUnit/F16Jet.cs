using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

/// <summary>
/// Class representing of F16 Jet.
/// </summary>
internal class F16Jet : StrikeUnitBase, IStrikeUnit
{
    /// <summary>
    /// F16 Jet constructor.
    /// </summary>
    /// <param name="name">Name for the name property.</param>
    public F16Jet(string name) : base(name)
    {
        ammoCapacity = 8;
        fuelSupply = 1000;
        effectiveAgainst = [TargetType.Building];
    }

    // <inheridoc/>
    public string Name => name;

    // <inheridoc/>
    public int AmmoCapacity => ammoCapacity;

    // <inheridoc/>
    public double FuelSupply 
    { 
        get => fuelSupply;
        set => fuelSupply = value;
    }

    // <inheridoc/>
    public TargetType[] EffectiveAgainst => effectiveAgainst;

    // <inheridoc/>
    public bool IsEffective(TargetType target)
    {
        return EffectiveAgainst.Contains(target);
    }

    // <inheridoc/>
    public bool IsFunctional()
    {
        if (FuelSupply < 300)
            Refuel(1000 - FuelSupply);
        return AmmoCapacity >= 3;
    }

    // <inheridoc/>
    public void Refuel(double value)
    {
        FuelSupply += value;
    }

    // <inheridoc/>
    public bool Strike()
    {
        FuelSupply -= 100;
        return this.StrikeLogic();
    }
}

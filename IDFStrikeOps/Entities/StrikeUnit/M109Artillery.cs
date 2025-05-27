using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

/// <summary>
/// Class representing of M109 Artillery.
/// </summary>
internal class M109Artillery : StrikeUnitBase, IStrikeUnit
{
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

    /// <summary>
    /// M109 Artillery constructor.
    /// </summary>
    /// <param name="name">Name for the name property.</param>
    public M109Artillery(string name) : base(name)
    {
        effectiveAgainst = [TargetType.Person];
        ammoCapacity = 40;
        fuelSupply = 100;
    }

    // <inheridoc/>
    public bool IsEffective(TargetType target)
    {
        return EffectiveAgainst.Contains(target);
    }

    // <inheridoc/>
    public bool IsFunctional()
    {
        if (FuelSupply < 20)
            Refuel(100 - FuelSupply);
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
        FuelSupply -= 10;
        return this.StrikeLogic();
    }
}

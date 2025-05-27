using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities.StrikeUnit;

/// <summary>
/// Class representing of Zik drone.
/// </summary>
internal class ZikDrone : StrikeUnitBase, IStrikeUnit
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
    /// Zik drone constructor.
    /// </summary>
    /// <param name="name">Name for the name property.</param>
    public ZikDrone(string name) : base(name)
    {
        ammoCapacity = 3;
        fuelSupply = 50;
        effectiveAgainst = [TargetType.Person, TargetType.Vehicle];
    }

    // <inheridoc/>
    public bool IsEffective(TargetType target)
    {
        return EffectiveAgainst.Contains(target);
    }

    // <inheridoc/>
    public bool IsFunctional()
    {
        if (FuelSupply < 10)
            Refuel(50 - FuelSupply);
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
        FuelSupply -= 5;
        return this.StrikeLogic();
    }
}

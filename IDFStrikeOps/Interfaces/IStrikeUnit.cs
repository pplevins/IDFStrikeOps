using IDFStrikeOps.Entities;

namespace IDFStrikeOps.Interfaces;

/// <summary>
/// Interface for a strike units operations and properties.
/// </summary>
internal interface IStrikeUnit
{
    /// <summary>
    /// Name of the strike unit.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Amount of ammunition left.
    /// </summary>
    int AmmoCapacity { get; }

    /// <summary>
    /// Amount of fuel left.
    /// </summary>
    double FuelSupply { get; }

    /// <summary>
    /// Type of targets the unit effective against.
    /// </summary>
    TargetType[] EffectiveAgainst { get; }

    /// <summary>
    /// Strike operation for the unit.
    /// </summary>
    /// <returns>true in case of target elimination and mission succses, false otherwise.</returns>
    bool Strike();

    /// <summary>
    /// Refuel mechanism for the strike unit.
    /// </summary>
    /// <param name="amount">Amount to refuel.</param>
    void Refuel(double amount);

    /// <summary>
    /// Checks if the unit effective against specific target.
    /// </summary>
    /// <param name="target">Location type target.</param>
    /// <returns>true in case the unit is effective, false otherwise.</returns>
    bool IsEffective(TargetType target);

    /// <summary>
    /// Checks if the unit is functional.
    /// </summary>
    /// <returns>true if the unit is functional, false otherwise.</returns>
    bool IsFunctional();
}

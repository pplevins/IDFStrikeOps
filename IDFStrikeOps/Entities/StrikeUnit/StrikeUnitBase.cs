namespace IDFStrikeOps.Entities.StrikeUnit;

/// <summary>
/// A base class for strike units for shared functionality and behaviour.
/// </summary>
internal class StrikeUnitBase
{
    protected string name;
    protected int ammoCapacity;
    protected double fuelSupply;
    protected TargetType[] effectiveAgainst;

    /// <summary>
    /// Constractor for strike unit.
    /// </summary>
    /// <param name="name">Name for the name property.</param>
    protected StrikeUnitBase(string name)
    {
        this.name = name;
        effectiveAgainst = [];
    }

    /// <summary>
    /// Basic logic of striking, shared by all strike units.
    /// </summary>
    /// <returns>true in case of target elimination and mission succses, false otherwise.</returns>
    protected bool StrikeLogic()
    {
        Random random = new();
        bool result = false;
        for (int i = 0; i < 3 && !result && ammoCapacity > 0; i++)
        {
            ammoCapacity--;
            result = Convert.ToBoolean(random.Next(2));
        }
        return result;
    }

    /// <summary>
    /// String represantation of strike unit, overrides toString.
    /// </summary>
    /// <returns>represantation of a strike unit instance.</returns>
    public override string ToString()
    {
        return $"Strike Unit type: {this.GetType().Name}\nName: {name}\n"
            + $"Ammunition Capacity: {ammoCapacity} Strikes\n" 
            + $"Effective against: {string.Join(", ", effectiveAgainst)}";
    }
}

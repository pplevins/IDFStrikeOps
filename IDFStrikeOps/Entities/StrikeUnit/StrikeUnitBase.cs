namespace IDFStrikeOps.Entities.StrikeUnit;

internal class StrikeUnitBase
{
    protected string name;
    protected int ammoCapacity;
    protected double fuelSupply;
    protected TargetType[] effectiveAgainst;

    protected StrikeUnitBase(string name)
    {
        this.name = name;
        effectiveAgainst = [];
    }

    public override string ToString()
    {
        return $"Strike Unit type: {this.GetType()}\nName: {name}\n"
            + $"Ammunition Capacity: {ammoCapacity} Strikes\n" 
            + $"Effective against: {string.Join(", ", effectiveAgainst)}";
    }
}

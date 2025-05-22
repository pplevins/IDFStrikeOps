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
}

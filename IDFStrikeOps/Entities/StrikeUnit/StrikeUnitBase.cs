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

    public override string ToString()
    {
        return $"Strike Unit type: {this.GetType().Name}\nName: {name}\n"
            + $"Ammunition Capacity: {ammoCapacity} Strikes\n" 
            + $"Effective against: {string.Join(", ", effectiveAgainst)}";
    }
}

using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities;

internal class IDF
{
    public DateTime DateOfFormation { get; }
    public string CurrentCommander { get; set; }
    List<IStrikeUnit> StrikeUnits { get; }
    List<StrikeReport> StrikeLogs { get; }

    public IDF(string currentCommander)
    {
        DateOfFormation = new DateTime(1987, 12, 15);
        CurrentCommander = currentCommander;
        StrikeUnits = [];
        StrikeLogs = [];
    }

    public void AddStrikeUnit(IStrikeUnit unit) => StrikeUnits.Add(unit);
    public void AddStrikeReport(StrikeReport report) => StrikeLogs.Add(report);

    public string GetStrikeUnitsList()
    {
        string result = "Current situation of all strike units:\n";
        for (int i = 0; i < StrikeUnits.Count; i++)
        {
            result += $"Strike unit No. {i + 1}:\n" + StrikeUnits[i] + "\n\n";
        }
        return result;
    }

    public IStrikeUnit GetStrikeUnitByName(string name)
    {
        return StrikeUnits.
            Where(unit => unit.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
            .FirstOrDefault() ?? throw new NullReferenceException($"No strike unit with the name {name}");
    }

    public StrikeReport OperateStrike(IStrikeUnit strikeUnit, Terrorist terrorist, string officerName)
    {
        DateTime timeOfOrder = DateTime.Now;
        int ammoUsed = strikeUnit.AmmoCapacity;
        bool sucsses = strikeUnit.Strike();
        ammoUsed -= strikeUnit.AmmoCapacity;
        if (sucsses)
        {
            terrorist.Eliminate();
        }
        return new StrikeReport(terrorist.Name, timeOfOrder, officerName, strikeUnit, sucsses, ammoUsed);
    }
}

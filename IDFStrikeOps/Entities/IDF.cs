using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities;

internal class IDF
{
    public DateTime DateOfFormation { get; }
    public string CurrentCommander { get; set; }
    List<IStrikeUnit> StrikeUnits { get; }
    public IDF(string currentCommander)
    {
        DateOfFormation = new DateTime(1987, 12, 15);
        CurrentCommander = currentCommander;
        StrikeUnits = [];
    }

    public void AddStrikeUnit(IStrikeUnit unit) => StrikeUnits.Add(unit);
}

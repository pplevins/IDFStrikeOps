using IDFStrikeOps.Interfaces;

namespace IDFStrikeOps.Entities;

/// <summary>
/// Class representing the Israeli Defence Forces.
/// </summary>
internal class IDF
{
    /// <summary>
    /// IDF formation date.
    /// </summary>
    public DateTime DateOfFormation { get; }

    /// <summary>
    /// Current commandor of IDF.
    /// </summary>
    public string CurrentCommander { get; set; }

    /// <summary>
    /// List of all strike units in IDF.
    /// </summary>
    List<IStrikeUnit> StrikeUnits { get; }

    /// <summary>
    /// List of all strike logs.
    /// </summary>
    List<StrikeReport> StrikeLogs { get; }

    /// <summary>
    /// Constructor for IDF.
    /// </summary>
    /// <param name="currentCommander">Name of current commandor.</param>
    public IDF(string currentCommander)
    {
        DateOfFormation = new DateTime(1987, 12, 15);
        CurrentCommander = currentCommander;
        StrikeUnits = [];
        StrikeLogs = [];
    }

    /// <summary>
    /// Adding strike unit to the list.
    /// </summary>
    /// <param name="unit">Strike unit to add.</param>
    public void AddStrikeUnit(IStrikeUnit unit) => StrikeUnits.Add(unit);

    /// <summary>
    /// Adding strike log to the list.
    /// </summary>
    /// <param name="report">Strike report to add.</param>
    public void AddStrikeReport(StrikeReport report) => StrikeLogs.Add(report);

    /// <summary>
    /// Get the full list of all strike units and their condition.
    /// </summary>
    /// <returns>string of all strike units.</returns>
    public string GetStrikeUnitsList()
    {
        string result = "Current situation of all strike units:\n";
        for (int i = 0; i < StrikeUnits.Count; i++)
        {
            result += $"Strike unit No. {i + 1}:\n" + StrikeUnits[i] + "\n\n";
        }
        return result;
    }

    /// <summary>
    /// Get stike unit by name.
    /// </summary>
    /// <param name="name">Name of the strike unit.</param>
    /// <returns>The strike unit.</returns>
    /// <exception cref="NullReferenceException">In case the strike unit not exist.</exception>
    public IStrikeUnit GetStrikeUnitByName(string name)
    {
        return StrikeUnits.
            Where(unit => unit.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
            .FirstOrDefault() ?? throw new NullReferenceException($"No strike unit with the name {name}");
    }

    /// <summary>
    /// Operating the strike operation.
    /// </summary>
    /// <param name="strikeUnit">Strike unit to operate.</param>
    /// <param name="terrorist">Target terorrist</param>
    /// <param name="officerName">Commandor of the strike.</param>
    /// <returns>Report of the strike.</returns>
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

namespace IDFStrikeOps.Entities;

/// <summary>
/// Class representing the Hamas terrorist organization.
/// </summary>
internal class Hamas
{
    /// <summary>
    /// Hamas formation date.
    /// </summary>
    public DateTime DateOfFormation { get; }

    /// <summary>
    /// Current commandor of Hamas.
    /// </summary>
    public string CurrentCommander { get; set; }

    /// <summary>
    /// List of known terrorist in the organization.
    /// </summary>
    public List<Terrorist> Terrorists { get; }

    /// <summary>
    /// Constructor for Hamas.
    /// </summary>
    /// <param name="currentCommander">Name of current commandor.</param>
    public Hamas(string currentCommander)
    {
        DateOfFormation = new DateTime(1987, 12, 15);
        CurrentCommander = currentCommander;
        this.Terrorists = [];
    }

    /// <summary>
    /// Adding terrorist to the organization.
    /// </summary>
    /// <param name="terrorist">Terrorist to add.</param>
    public void AddTerrorist(Terrorist terrorist) => Terrorists.Add(terrorist);

    /// <summary>
    /// Get terrorist by his name.
    /// </summary>
    /// <param name="name">Name of the terrorist.</param>
    /// <returns>The terrorist.</returns>
    /// <exception cref="NullReferenceException">In case the terrorist not exist or dead.</exception>
    public Terrorist GetTerroristByName(string name)
    {
        return Terrorists
            .Where(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
            .FirstOrDefault() 
            ?? throw new NullReferenceException($"Terrorist with the name {name} doesn't exist!");
    }
}

namespace IDFStrikeOps.Entities;

internal class Hamas
{
    public DateTime DateOfFormation { get; }
    public string CurrentCommander { get; set; }
    public List<Terrorist> Terrorists { get; }

    public Hamas(string currentCommander)
    {
        DateOfFormation = new DateTime(1987, 12, 15);
        CurrentCommander = currentCommander;
        this.Terrorists = [];
    }

    public void AddTerrorist(Terrorist terrorist) => Terrorists.Add(terrorist);

    public Terrorist GetTerroristByName(string name)
    {
        return Terrorists
            .Where(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) && t.IsAlive)
            .FirstOrDefault() 
            ?? throw new NullReferenceException($"Terrorist with the name {name} doesn't exist or he's dead!");
    }
}

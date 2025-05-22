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
}

namespace IDFStrikeOps.Entities;

internal class Terrorist
{
    public string Name { get; set; }
    public TerroristRank Rank { get; set; }
    public bool IsAlive { get; set; }
    public List<WeaponsType> Weapons { get; }

    public Terrorist(string name, TerroristRank rank = TerroristRank.Collaborator, bool isAlive = true) 
    {
        Name = name;
        IsAlive = isAlive;
        Rank = rank;
        Weapons = [];
    }

    public override string ToString()
    {
        return $"Hamas Terrorist:\nName: {Name}\nRank: {Rank}\nStatus: " 
            + (IsAlive ? "Alive\n" : "Dead\n")
            + "Armed with:\n"
            + string.Join(", ", Weapons);
    }

    public void AddWeapon(WeaponsType weapon)
    {
        Weapons.Add(weapon);
    }

    public void DeleteWeapon(WeaponsType weapon)
    {
        Weapons.Remove(weapon);
    }

    public void Eliminate() => IsAlive = false;
}

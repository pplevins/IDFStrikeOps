namespace IDFStrikeOps.Entities;

internal class Terrorist
{
    string Name { get; set; }
    TerroristRank Rank { get; set; }
    bool IsAlive { get; set; }
    List<WeaponsType> Weapons { get; }

    public Terrorist(string name, TerroristRank rank = TerroristRank.Collaborator, bool isAlive = true) 
    {
        Name = name;
        IsAlive = isAlive;
        Rank = rank;
        Weapons = [];
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

namespace IDFStrikeOps.Entities;

/// <summary>
/// Class representing terrorist.
/// </summary>
internal class Terrorist
{
    /// <summary>
    /// Terrorist name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Terrorist rank
    /// </summary>
    public TerroristRank Rank { get; set; }

    /// <summary>
    /// Terrorist alive or dead
    /// </summary>
    public bool IsAlive { get; set; }

    /// <summary>
    /// terrorist weapons arsenal
    /// </summary>
    public List<WeaponsType> Weapons { get; }

    /// <summary>
    /// Constructor for terrorist.
    /// </summary>
    /// <param name="name">Terrorist name</param>
    /// <param name="rank">Terrorist rank</param>
    /// <param name="isAlive">alive or dead</param>
    public Terrorist(string name, TerroristRank rank = TerroristRank.Collaborator, bool isAlive = true) 
    {
        Name = name;
        IsAlive = isAlive;
        Rank = rank;
        Weapons = [];
    }

    /// <summary>
    /// Representing terrorist with string.
    /// </summary>
    /// <returns>String representation of terrorist</returns>
    public override string ToString()
    {
        return $"Hamas Terrorist:\nName: {Name}\nRank: {Rank}\nStatus: " 
            + (IsAlive ? "Alive\n" : "Dead\n")
            + "Armed with:\n"
            + string.Join(", ", Weapons);
    }

    /// <summary>
    /// Adding weapon to the arsenal.
    /// </summary>
    /// <param name="weapon">Weapon to add.</param>
    public void AddWeapon(WeaponsType weapon) => Weapons.Add(weapon);

    /// <summary>
    /// Adding weapon to the arsenal.
    /// </summary>
    /// <param name="weapon">Weapon to add.</param>
    public void DeleteWeapon(WeaponsType weapon) => Weapons.Remove(weapon);

    /// <summary>
    /// Eliminating terrorist.
    /// </summary>
    public void Eliminate() => IsAlive = false;
}

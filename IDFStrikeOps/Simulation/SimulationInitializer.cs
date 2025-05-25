using IDFStrikeOps.Entities;
using IDFStrikeOps.Entities.StrikeUnit;

namespace IDFStrikeOps.Simulation;

internal static class SimulationInitializer
{
    private static Hamas? s_hamas;
    private static IDF? s_idf;
    private static Aman? s_aman;

    private static readonly Random s_rand = new();

    private static readonly List<string> s_terroristsNames = 
        [
        "Yahya Sinwar",
        "Mohammed Deif",
        "Ismail Haniyeh",
        "Saleh al-Arouri",
        "Mohammed Sinwar",
        "Marwan Issa",
        "Khaled Mashal",
        "Mahmoud al-Zahar",
        "Ibrahim al-Makadmeh",
        "Yahya Ayyash"
        ];


    private static int GenerateRandom(int min, int max)
    {
        return s_rand.Next(min, max);
    }
    
    private static void CreateTerrorists()
    {
        int terroristsCount = GenerateRandom(5, 11);
        for (int i = 0; i < terroristsCount; i++)
        {
            int weaponsNum = GenerateRandom(1, 3);
            TerroristRank rank = (TerroristRank)GenerateRandom(1, 6);
            Terrorist terrorist = new(s_terroristsNames[i], rank);
            for (int j = 0; j < weaponsNum; j++)
            {
                WeaponsType weapon = (WeaponsType)GenerateRandom(1, 5);
                terrorist.AddWeapon(weapon);
            }
            s_hamas!.AddTerrorist(terrorist);
        }
    }

    private static void CreateStrikeUnits()
    {
        s_idf!.AddStrikeUnit(new F16Jet("Bird"));
        s_idf!.AddStrikeUnit(new M109Artillery("Canon"));
        s_idf!.AddStrikeUnit(new ZikDrone("Zik"));
    }

    private static void CreateIntelMessages()
    {
        int messagesNum = GenerateRandom(10, 20);
        for (int i = 0; i < messagesNum; i++)
        {
            Terrorist terrorist = s_hamas!.Terrorists[i % s_hamas!.Terrorists.Count];
            s_aman!.AddIntel(terrorist.Name, new IntelligenceMessage(terrorist, (TargetType)GenerateRandom(0, 3), GenerateRandom(0, 101)));
        }
    }

    public static void Init(Hamas hamas, IDF idf, Aman aman)
    {
        s_hamas = hamas ?? throw new NullReferenceException("Hamas object can not be null!");
        s_idf = idf ?? throw new NullReferenceException("IDF object can not be null!");
        s_aman = aman ?? throw new NullReferenceException("Aman object can not be null!");

        CreateTerrorists();
        CreateStrikeUnits();
        CreateIntelMessages();
    }
}

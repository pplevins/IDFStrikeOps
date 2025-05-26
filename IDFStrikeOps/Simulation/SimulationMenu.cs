using IDFStrikeOps.Entities;
using IDFStrikeOps.Services;

namespace IDFStrikeOps.Simulation;

internal class SimulationMenu
{
    static readonly Hamas s_hamas = new("Mohammed Sinwar");
    static readonly IDF s_idf = new("Eyal Zamir");
    static readonly Aman s_aman = new(new IntelService());

    private static void MostTrackedTerroristOperation()
    {
        string terroristName = s_aman.GetMostTrackedTerrorist();
        Terrorist terrorist = s_hamas.GetTerroristByName(terroristName);
        Console.WriteLine($"The most tracked terrorist is\n{terrorist}");
    }

    private static void Menu()
    {
        Console.WriteLine("Welcome to the IDF Strike Operation System!");
        int choice = int.MinValue;
        do
        {
            try
            {
                Console.WriteLine(@"Select what operation you want to perform (0-4):
    0: Exit
    1: Identify the terrorist with the most intelligence reports
    2: Show all currently available strike units and their remaining capacity
    3: Determine the most dangerous terrorist
    4: Execute a strike
        ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Bye!");
                            break;
                        case 1:
                            MostTrackedTerroristOperation();
                            break;
                        case 2:
                            Console.WriteLine(s_idf.GetStrikeUnitsList());
                            break;
                        case 3:
                            Console.WriteLine(s_aman.IntelAnalyzer.PrioritizeTarget(s_hamas.Terrorists));
                            break;
                        case 4:
                            break;
                        default:
                            Console.WriteLine("it must be a number between 0-4!");
                            break;
                    }
                }
                else 
                { 
                    Console.WriteLine("The input must be a number!");
                    choice = int.MinValue;
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

        } while (choice != 0);
    }

    public static void Run()
    {
        SimulationInitializer.Init(s_hamas, s_idf, s_aman);
        Menu();
    }
}
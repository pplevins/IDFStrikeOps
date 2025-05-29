using IDFStrikeOps.Entities;
using IDFStrikeOps.Interfaces;
using IDFStrikeOps.Services;

namespace IDFStrikeOps.Simulation;

/// <summary>
/// A manager class for the simulation.
/// </summary>
internal class SimulationMenu
{
    static readonly Hamas s_hamas = new("Mohammed Sinwar");
    static readonly IDF s_idf = new("Eyal Zamir");
    static readonly Aman s_aman = new(new IntelService());

    /// <summary>
    /// Printing the most tracked terrorist data.
    /// </summary>
    private static void MostTrackedTerroristOperation()
    {
        string terroristName = s_aman.GetMostTrackedTerrorist();
        Terrorist terrorist = s_hamas.GetTerroristByName(terroristName);
        Console.WriteLine($"The most tracked terrorist is\n{terrorist}");
    }

    /// <summary>
    /// Inputing terrorist target.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="NullReferenceException"></exception>
    private static (Terrorist, TargetType) InputTarget()
    {
        Terrorist? target = null;
        TargetType? location = null;
        do
        {
            try
            {
                Console.Write("Enter target name: ");
                string targetName = Console.ReadLine() ?? throw new ArgumentNullException("No name was entered");
                target = s_hamas.GetTerroristByName(targetName);
                location = s_aman.GetLastKnownLocation(target);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (target == null || location == null);
        return (target, location ?? throw new NullReferenceException("no last known location for the target!"));
    }

    /// <summary>
    /// Inputting strike unit form the user.
    /// </summary>
    /// <param name="location">Location type for the strike unit.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    private static IStrikeUnit InputStrikeUnit(TargetType location)
    {
        IStrikeUnit? unit = null;
        do
        {
            try
            {
                Console.WriteLine("Select strike unit for the strike:");
                s_idf.GetStrikeUnitsList();
                string unitName = Console.ReadLine() ?? throw new ArgumentNullException("No name was entered");
                unit = s_idf.GetStrikeUnitByName(unitName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (unit == null || !unit.IsEffective(location) || !unit.IsFunctional());
        return unit;
    }

    /// <summary>
    /// Operating the strike operation in the simulation.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    private static StrikeReport OperateStrike()
    {
        Console.Write("Enter your name: ");
        string officerName = Console.ReadLine() ?? throw new ArgumentNullException("No name was entered");
        var (target, location) = InputTarget();

        Console.WriteLine($"The location type of the target is {location}.");
        IStrikeUnit unit = InputStrikeUnit(location);

        StrikeReport report = s_idf.OperateStrike(unit, target, officerName);
        s_idf.AddStrikeReport(report);
        return report;
    }

    /// <summary>
    /// Displaying the menu to the user.
    /// </summary>
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
                            Console.WriteLine(OperateStrike());
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

    /// <summary>
    /// Running point for the simulation.
    /// </summary>
    public static void Run()
    {
        SimulationInitializer.Init(s_hamas, s_idf, s_aman);
        Menu();
    }
}
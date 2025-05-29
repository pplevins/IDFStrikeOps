using IDFStrikeOps.Services;
using IDFStrikeOps.Simulation;

namespace IDFStrikeOps;

internal class Program
{
    /// <summary>
    /// Main of the program.
    /// </summary>
    /// <param name="args">Arguments passing from the console.</param>
    static async Task Main(string[] args)
    {
        await GeminiApiService.TalkToGeminiAsync();
        SimulationMenu.Run();
    }
}

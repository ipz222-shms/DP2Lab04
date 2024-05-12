using ChainOfResponsibilityLibrary;
using MediatorLibrary;
using MementoLibrary;
using ObserverLibrary;
using StrategyLibrary;
using ConsoleApp;

while (true)
{
    var i = 0;
    Console.WriteLine("Select scenario:");
    foreach (var scenario in Enum.GetValues<Scenario>())
        Console.WriteLine($"\t{++i}: {scenario}");

    Console.Write("\nEnter number: ");
    var input = Console.ReadLine();
    int selectedScenario;
    if (int.TryParse(input, out var iValue))
        selectedScenario = --iValue;
    else
    {
        Console.Clear();
        Console.WriteLine("Invalid input!\n");
        continue;
    }

    Console.Clear();
    if (!Enum.IsDefined(typeof(Scenario), selectedScenario))
    {
        Console.WriteLine("Unknown scenario!\n");
        continue;
    }
    
    Console.WriteLine($"Run '{(Scenario)selectedScenario}' scenario:\n\n");

    switch ((Scenario)selectedScenario)
    {
        case Scenario.ChainOfResponsibility:
            Console.WriteLine("Welcome to the support!" +
                              "\n\nPlease, select a category which best represents your question:" +
                              "\n\t1 - Account\n\t2 - Orders\n\t3 - Refund\n\t4 - Other");

            var supportHandler = new AccountSupport();
            supportHandler.SetNextHandler(new OrdersSupport())
                .SetNextHandler(new RefundSupport())
                .SetNextHandler(new OperatorSupport());
            supportHandler.Handle(SupportInput.GetInt());
            
            break;
        case Scenario.Mediator:
            Runway[] runways =
            [
                new Runway(),
                new Runway(),
                new Runway(),
                new Runway(),
                new Runway()
            ];
            Aircraft[] aircrafts =
            [
                new Aircraft("A", 5),
                new Aircraft("B", 12),
                new Aircraft("C", 100),
            ];
            CommandCentre centre = new(runways, aircrafts);
            
            aircrafts[0].Land(runways[1]);
            aircrafts[2].Land(runways[3]);
            aircrafts[0].TakeOff(runways[2]);
            aircrafts[1].Land(runways[4]);
            aircrafts[2].TakeOff(runways[2]);
            aircrafts[2].Land(runways[4]);
            
            break;
        case Scenario.Observer:
        case Scenario.Strategy:
        case Scenario.Memento:
        default:
            throw new NotImplementedException();
    }
    
    Console.Write("\n\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

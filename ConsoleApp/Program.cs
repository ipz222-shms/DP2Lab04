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
            ObserverLibrary.LightElementNode div = new("div");
            ObserverLibrary.LightElementNode btn = new("button");
            div.AppendChild(btn);
            btn.AppendChild(new ObserverLibrary.LightTextNode("Submit"));
            
            div.OnMouseOver += (node, _) => Console.WriteLine($"{node} Mouse Over!");
            div.OnMouseOut += (node, _) => Console.WriteLine($"{node} Mouse Out!");
            btn.OnClick += (node, _) => Console.WriteLine($"{node} Clicked!");
            btn.OnClick += (_, _) => Console.WriteLine("Form submitted!");
            
            Console.WriteLine($"{div.OuterHTML()}\n");
            div.EmulateMouseOver();
            btn.EmulateClick();
            div.EmulateMouseOut();
            
            break;
        case Scenario.Strategy:
            StrategyLibrary.LightElementNode body = new("body");
            LightImageNode img1 = new(@"https://picsum.photos/200", 
                new StrategyLibrary.ImageLoaders.WebImageLoader());
            LightImageNode img2 = new(@"D:\Development\source\repos\University\Course 2\Patterns\DP2Lab04\StrategyLibrary\Assets\984-200x200.jpg",
                new StrategyLibrary.ImageLoaders.FileImageLoader());
            body.AppendChild(img1);
            body.AppendChild(img2);
            
            Console.WriteLine(body.OuterHTML());
            
            break;
        case Scenario.Memento:
            TextEditor doc = new();
            
            doc.WriteLine("Hello World!");
            doc.Write("Hello");
            doc.Write(" Country!");
            Console.WriteLine($"{doc.ReadAll()}\n");

            doc.Save();
            
            doc.Purge();
            doc.WriteLine("Mykyta Shevtsov");
            doc.WriteLine("IPZ-22-2 [2]");
            Console.WriteLine(doc.ReadAll());
            
            doc.Restore();
            Console.WriteLine(doc.ReadAll());
            
            break;
        default:
            throw new NotImplementedException();
    }
    
    Console.Write("\n\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

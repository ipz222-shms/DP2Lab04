namespace ChainOfResponsibilityLibrary;

public static class SupportInput
{
    public static int GetInt(string message = "Select topic")
    {
        while (true)
        {
            Console.Write($"{message}: ");
            if (int.TryParse(Console.ReadLine(), out var res))
                return res;
            Console.WriteLine("Try again...");
        }
    }
}

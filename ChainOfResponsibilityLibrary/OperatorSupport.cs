namespace ChainOfResponsibilityLibrary;

public class OperatorSupport : BaseHandler
{
    public override void Handle(int level)
    {
        Console.WriteLine("You've reached the end.\nConnecting an operator...");
    }
}

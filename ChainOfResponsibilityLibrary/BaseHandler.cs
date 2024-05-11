namespace ChainOfResponsibilityLibrary;

public abstract class BaseHandler
{
    private BaseHandler? _next;

    public BaseHandler SetNextHandler(BaseHandler next)
    {
        _next = next;
        return next;
    }

    public abstract void Handle(int level);

    protected void Next(int level)
    {
        if (_next is null)
            Console.WriteLine("Connecting an operator...");
        else
            _next.Handle(level);
    }
}

namespace ChainOfResponsibilityLibrary;

public class RefundSupport : BaseHandler
{
    public override void Handle(int level)
    {
        if (level == 3)
            Console.WriteLine("<Proceed with refund>");
        else
            Next(level + 1);
    }
}

namespace ChainOfResponsibilityLibrary;

public class OrdersSupport : BaseHandler
{
    public override void Handle(int level)
    {
        if (level == 2)
        {
            Console.WriteLine("What's bothering you?" +
                              "\n\t1 - Worldwide shipping\n\t2 - Delivery delay\n\t3 - Place an order" +
                              "\n\t4 - Refund\n\t5 - Other");
            switch (SupportInput.GetInt())
            {
                case 1:
                    Console.WriteLine("<Worldwide shipping guide here>");
                    break;
                case 2:
                    Console.WriteLine("<Delivery delay policy here>");
                    break;
                case 3:
                    Console.WriteLine("<Proceed with order>");
                    break;
                case 4:
                    Next(level + 1);
                    break;
                default:
                    Next(level + 2);
                    break;
            }
        }
        else
            Next(level + 1);
    }
}

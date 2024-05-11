namespace ChainOfResponsibilityLibrary;

public class AccountSupport : BaseHandler
{
    public override void Handle(int level)
    {
        if (level == 1)
        {
            Console.WriteLine("What's bothering you?" +
                              "\n\t1 - Registration\n\t2 - Login\n\t3 - Password change\n\t4 - Other");
            switch (SupportInput.GetInt())
            {
                case 1:
                    Console.WriteLine("<Registration guide here>");
                    break;
                case 2:
                    Console.WriteLine("<Login guide here>");
                    break;
                case 3:
                    Console.WriteLine("<Prompt password change>");
                    break;
                case 4:
                default:
                    Next(level + 1);
                    break;
            }
        }
        else
            Next(level + 1);
    }
}

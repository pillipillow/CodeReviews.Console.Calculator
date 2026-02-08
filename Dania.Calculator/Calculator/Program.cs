using System.Text.RegularExpressions;
using CalculatorLibrary;

class Program
{
    static void Main(string[] args)
    {
        bool isEndApp = false;

        Calculator calculator = new Calculator();
        while (!isEndApp)
        {
            double num1 = 0;
            double num2 = 0;
            double result = 0;

            Console.Clear();
            Console.WriteLine($"Number of Calculations this session: {Helpers.GetNumberOfCalculations()}");
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\tA - Add");
            Console.WriteLine("\tS - Subtract");
            Console.WriteLine("\tM - Multiply");
            Console.WriteLine("\tD - Divide");
            Console.WriteLine("\tSQ - Square Root");
            Console.WriteLine("\tP - Power");
            Console.WriteLine("\tTE - 10x");
            Console.WriteLine("\tT - Trigonometry");
            Console.Write("Your option: ");

            string? op = Console.ReadLine();
            if (op != null) op = op.ToLower().Trim();

            if (Regex.IsMatch(op, "[a|s|m|d]") &&  op != "sq")
            {
                Console.WriteLine("Type a number, and then press Enter: ");
                num1 = Helpers.CheckInputIsDouble();

                Console.WriteLine("Type another number, and then press Enter: ");
                num2 = Helpers.CheckInputIsDouble();

                result = calculator.DoOperation(num1, num2, op);
                Helpers.CheckResultIsNaN(result);

                Helpers.IncreaseNumberOfCalculations();
            }
            else if (Regex.IsMatch(op, "[p]"))
            {
                Console.WriteLine("Type the base number, and then press Enter: ");
                num1 = Helpers.CheckInputIsDouble();

                Console.WriteLine("Type the power number, and then press Enter: ");
                num2 = Helpers.CheckInputIsDouble();

                result = calculator.DoPower(num1, num2);
                Helpers.CheckResultIsNaN(result);

                Helpers.IncreaseNumberOfCalculations();
            }
            else if (Regex.IsMatch(op, "[sq|te]") && (op == "sq" || op == "te"))
            {
                Console.WriteLine("Type a number, and then press Enter: ");
                num1 = Helpers.CheckInputIsDouble();

                switch (op)
                {
                    case "sq":
                        result = calculator.DoSquareRoot(num1);
                        break;
                    case "te":
                        result = calculator.DoTenExponent(num1);
                        break;
                }
                Helpers.CheckResultIsNaN(result);

                Helpers.IncreaseNumberOfCalculations();
            }
            else if (Regex.IsMatch(op, "[t]"))
            {
                Console.WriteLine("Choose an option from the list: ");
                Console.WriteLine("\tS - sin");
                Console.WriteLine("\tC - cos");
                Console.WriteLine("\tT - tan");
                Console.Write("Your option: ");

                do
                {
                    op = Console.ReadLine();
                    if (op != null) op = op.ToLower().Trim();

                    if (!Regex.IsMatch(op, "[s|c|t]"))
                        Console.WriteLine("Error: Unrecognized input.");

                } while (!Regex.IsMatch(op, "[s|c|t]"));

                Console.WriteLine("Type a radian, and then press Enter: ");
                num1 = Helpers.CheckInputIsDouble();

                result = calculator.DoTrigonometry(num1, op);
                Helpers.CheckResultIsNaN(result);

                Helpers.IncreaseNumberOfCalculations();
            }
            else
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            Console.WriteLine("------------------------\n");

            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") isEndApp = true;

            Console.WriteLine("\n");
        }

        calculator.Finish();
        return;
    }
}

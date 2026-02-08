public class Helpers
{
    static int numberOfCalculations = 0;

    public static double CheckInputIsDouble()
    {
        string? numInput = Console.ReadLine();
        double cleanNum = 0;

        while (!double.TryParse(numInput, out cleanNum))
        {
            Console.WriteLine("This is not a valid input. Please enter a numeric value: ");
            numInput = Console.ReadLine();
        }

        return cleanNum;
    }

    public static void CheckResultIsNaN(double result)
    {
        try
        {
            if (double.IsNaN(result))
            {
                Console.WriteLine("This operation will result in a mathematical error.\n");
            }
            else Console.WriteLine("Your result: {0:0.##}\n", result);
        }
        catch (Exception e)
        {
            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
        }
    }

    public static void IncreaseNumberOfCalculations()
    {
        numberOfCalculations++;
    }

    public static int GetNumberOfCalculations()
    { 
        return numberOfCalculations;
    }
}

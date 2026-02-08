using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;

        public Calculator() 
        {
            StreamWriter logfile = File.CreateText("calculator.json");
            logfile.AutoFlush = true;
            writer = new JsonTextWriter(logfile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            double result = double.NaN;

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    writer.WriteValue("Divide");
                    break;
                default:
                    break;
            }

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double DoSquareRoot(double num)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand");
            writer.WriteValue(num);
            writer.WritePropertyName("Operation");
            writer.WriteValue("Square Root");

            double result = Math.Sqrt(num);

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double DoPower(double based, double power)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Base");
            writer.WriteValue(based);
            writer.WritePropertyName("Exponent");
            writer.WriteValue(power);
            writer.WritePropertyName("Operation");
            writer.WriteValue("Power");

            double result = Math.Pow(based,power);

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double DoTenExponent(double exponent)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Exponent");
            writer.WriteValue(exponent);
            writer.WritePropertyName("Operation");
            writer.WriteValue("Ten Exponent");

            double result = Math.Pow(10, exponent);

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double DoTrigonometry(double num, string op)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand");
            writer.WriteValue(num);
            writer.WritePropertyName("Operation");

            double result = double.NaN;

            switch (op)
            {
                case "s":
                    writer.WriteValue("Sin");
                    result = Math.Sin(num);
                    break;
                case "c":
                    writer.WriteValue("Cos");
                    result = Math.Cos(num);
                    break;
                case "t":
                    writer.WriteValue("Tan");
                    result = Math.Tan(num);
                    break;
            }

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public void Finish()
        { 
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }

}

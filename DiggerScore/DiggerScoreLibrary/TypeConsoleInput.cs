using System.Text.RegularExpressions;

namespace Validation
{
    public class TypeConsoleInput
    {
        public static string? HiddenString()
        {            
            string? hiddenString = string.Empty;

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter) break;

                Console.Write("*");
                hiddenString += key.KeyChar;
            }

            Console.WriteLine();
            return hiddenString!;
        }

        public static string? NotEmptyString(string? inputMessage,string? warningMessage)
        {
            string? _ = string.Empty;

            while (true)
            {
                Console.Write(inputMessage+" ");
                _=Console.ReadLine();
                if (string.IsNullOrEmpty(_)) Console.WriteLine(warningMessage);
                else return _;
            }
        }

        public static int IntValue (string? inputMessage, string? warningMessage)
        {
            int _ = default;

            while (true)
            {
                Console.Write(inputMessage+" ");
                if (int.TryParse(Console.ReadLine(), out _)) return _;
                else Console.WriteLine(warningMessage);
            }
        }

        public static byte ByteValue(string? inputMessage, string? warningMessage)
        {
            byte _ = default;

            while (true)
            {
                Console.Write(inputMessage+" ");
                if (byte.TryParse(Console.ReadLine(), out _)) return _;
                else Console.WriteLine(warningMessage);
            }
        }

        public static double DoubleValue(string? inputMessage, string? warningMessage)
        {
            double _ = default;

            while (true)
            {
                Console.Write(inputMessage+" ");
                if (double.TryParse(Console.ReadLine(), out _)) return _;
                else Console.WriteLine(warningMessage);
            }
        }
    }
}
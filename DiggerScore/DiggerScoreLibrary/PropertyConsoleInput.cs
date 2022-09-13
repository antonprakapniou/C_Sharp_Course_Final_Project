using System.Text.RegularExpressions;

namespace Validation
{
    public class PropertyConsoleInput
    { 
        public static string Name(string inputMessage)
        {
            string? pattern=string.Empty;
            string? warningMessage=string.Empty;
            
            using (Pattern _=new())
            {
                pattern=_!.Name![0];
                warningMessage=_!.Name![1];
            }

            while (true)
            {
                Console.Write(inputMessage+" ");
                string? name=Console.ReadLine();
                if (Regex.IsMatch(name!, pattern, RegexOptions.IgnoreCase)) return name!;
                else Console.WriteLine(warningMessage);
            }
        }

        public static string Password(string inputMessage)
        {
            string? pattern = string.Empty;
            string? warningMessage = string.Empty;

            using (Pattern _ = new())
            {
                pattern=_!.Password![0];
                warningMessage=_!.Password![1];
            }

            while (true)
            {
                Console.Write(inputMessage+" ");
                string? password=TypeConsoleInput.HiddenString();
                if (Regex.IsMatch(password!, pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Repeat, please");
                    string?repeatPassword=TypeConsoleInput.HiddenString();
                    if (password!.Equals(repeatPassword)) return password!;
                    else Console.WriteLine("Password not confirmed. Try again");
                }
                else Console.WriteLine(warningMessage);
            }
        }

        public static string Email(string inputMessage)
        {
            string? pattern = string.Empty;
            string? warningMessage = string.Empty;

            using (Pattern _ = new())
            {
                pattern=_!.Email![0];
                warningMessage=_!.Email![1];
            }

            while (true)
            {
                Console.Write(inputMessage+" ");
                string? email = Console.ReadLine();
                if (Regex.IsMatch(email!, pattern, RegexOptions.IgnoreCase)) return email!;
                else Console.WriteLine(warningMessage);
            }
        }

        public static string PhoneNumber(string inputMessage)
        {
            while (true)
            {
                string? regionPhoneCode = "+375";
                byte numberLength = 7;
                byte operatorSymbolCount = 2;
                int symbolCount = default;
                string? phoneNumber = string.Empty;
                string? currenString = string.Empty;
                string? decimalChar = default;

                Console.Write(inputMessage+" ");
                currenString=regionPhoneCode+"(";
                Console.Write(currenString);
                phoneNumber=currenString;                

                while (symbolCount<operatorSymbolCount)
                {
                    char inputSymbol = Console.ReadKey(true).KeyChar;
                    Console.Write(inputSymbol);
                    phoneNumber += inputSymbol;
                    decimalChar+=inputSymbol;
                    symbolCount++;
                }

                currenString=")";
                Console.Write(currenString);
                phoneNumber+=currenString;
                symbolCount = default;                

                while (symbolCount<numberLength)
                {
                    char inputSymbol = Console.ReadKey(true).KeyChar;
                    Console.Write(inputSymbol);
                    phoneNumber += inputSymbol;
                    decimalChar+=inputSymbol;                    
                    symbolCount++;
                }

                Console.WriteLine();

                if (decimalChar!.ToCharArray().All(_ => char.IsNumber(_))) return phoneNumber;
                else Console.WriteLine("Number must contain only digits. Try again");
            }
        }
    }
}
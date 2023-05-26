using System;
using System.Collections.Generic;
using System.Text;

namespace NewToDoApp
{
    internal class Validations
    {
        public class Validation
        {
            public static bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            public static bool IsValidPassword(string password)
            {
                if (password.Length < 8)
                {
                    return false;
                }

                bool hasUpperCase = false;
                bool hasLowerCase = false;
                bool hasDigit = false;

                foreach (char c in password)
                {
                    if (char.IsUpper(c))
                    {
                        hasUpperCase = true;
                    }
                    else if (char.IsLower(c))
                    {
                        hasLowerCase = true;
                    }
                    else if (char.IsDigit(c))
                    {
                        hasDigit = true;
                    }
                }

                return hasUpperCase && hasLowerCase && hasDigit;
            }

            public static bool ValidateEnumValue(Priority.PriorityLevel priority)
            {
                //if (string.IsNullOrWhiteSpace(priority.ToString()))
                //    return false;
                return Enum.IsDefined(typeof(Priority.PriorityLevel), priority.ToString());
            }

            public static string ReadPassword()
            {
                var password = string.Empty;
                ConsoleKey key;

                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        Console.Write("\b \b");
                        password = password[0..^1];

                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        password += keyInfo.KeyChar;

                    }
                } while (key != ConsoleKey.Enter);
                Console.WriteLine();
                return password;
            }
        }
    }
}

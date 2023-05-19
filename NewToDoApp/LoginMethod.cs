using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NewToDoApp.Validations;

namespace NewToDoApp
{
    internal class LoginMethod
    {
        public static void Login(List<User> users) 
        {

            User userS = users.FirstOrDefault();

            Console.Write("Enter your email: ");
            string enteredEmail = Console.ReadLine();

            if (!Validation.IsValidEmail(enteredEmail))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email format.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter your password: ");
            string enteredPassword = Validation.ReadPassword();
            
            User currentUser = users.FirstOrDefault(u => u.Email == enteredEmail && u.Password == enteredPassword);
            
            if (currentUser != null)
            {
                Console.WriteLine($"Welcome, {currentUser.Name}!");
                currentUser = userS;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Login Successful.");
                Console.ResetColor();

                userS.Task = new List<Task>();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email or password.");
                Console.ResetColor();
                return;
            }


        }
    }
}

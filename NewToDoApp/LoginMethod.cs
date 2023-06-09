﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static NewToDoApp.Validations;

namespace NewToDoApp
{
    internal class LoginMethod
    {
        public static void Login(List<User> users) 
        {
            
            User currentUser = users.FirstOrDefault();

          while(true)
          {

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
            
            User user = users.FirstOrDefault(u => u.Email == enteredEmail && u.Password == enteredPassword);
            //currentUser.Id = users.Where(u => u.Email == enteredEmail &&
            //               u.Password == enteredPassword).Select(user => user.Id)
            //               .FirstOrDefault();

            if (currentUser != null)
            {
                Console.WriteLine($"Welcome, {currentUser.Name}!");
                user = currentUser;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Login Successful.");
                Console.ResetColor();
                    //continue;
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
}

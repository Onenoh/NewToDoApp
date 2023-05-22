using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NewToDoApp.Validations;

namespace NewToDoApp
{
    internal class Registration
    {

        public static void UserRegistration(List<Task> task, List<User> users)
        {
            User currentUser = null;

            while (true)
            {
                try
                {

                    Console.WriteLine();
                    Console.WriteLine("Choose any of the following options: ");
                    Console.WriteLine();
                    Console.WriteLine("1.   Register");
                    Console.WriteLine("2.   Login");
                    Console.WriteLine("3.   Logout");
                    Console.WriteLine("4.   Quit");
                    Console.WriteLine();


                    int command = int.Parse(Console.ReadLine());

                    if (command == 1)
                    {
                        Console.WriteLine("User Registration");
                        Console.WriteLine();

                        User user = new User();

                        

                        while (true)
                        {
                            Console.Write("Name: ");
                            user.Name = Console.ReadLine();

                            if (string.IsNullOrEmpty(user.Name))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input. Please enter a non-empty name.");
                                Console.ResetColor();
                                

                            }
                            else if (user.Name.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Name can only contain letters and spaces.");
                                Console.ResetColor();
                            }
                            else if (user.Name.Contains("  "))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Name cannot contain more than one consecutive space.");
                                Console.ResetColor();
                            }
                            else if (user.Name.Length > 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Name cannot be longer than 50 characters.");
                                Console.ResetColor();
                            } else
                            {
                                break;
                            }
                        }

                        while (true)
                        {
                            Console.Write("Email: ");
                            user.Email = Console.ReadLine();

                            if (!Validation.IsValidEmail(user.Email))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid email format.");
                                Console.ResetColor();
                            }else
                            {
                                break;
                            }
                        }
                       
                      while(true)
                      {

                        Console.Write("Password: ");
                        user.Password = Validation.ReadPassword();

                        Console.Write("Confirm password: ");
                        string password2 = Validation.ReadPassword();

                        if (user.Password == password2)
                        {
                            if (!Validation.IsValidPassword(user.Password))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid password. Password must be at least 8 characters long and contain at least one \nuppercase letter, one lowercase letter, and one digit.");
                                Console.ResetColor();
                                continue;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Passwords match!.");
                                Console.ResetColor();
                            }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Registration successful.");
                                Console.ResetColor();
                                Thread.Sleep(1000);
                                Console.Clear();

                                users.Add(user);
                                currentUser = user;
                               
                        }
                        else
                        {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Passwords do not match.");
                                Console.ResetColor();     
                        }

                            break;

                        }
                    }
                    else if (command == 2)
                    {
                        LoginMethod.Login(users);

                       // continue;
                    }
                    else if (command == 3)
                    {
                        if (currentUser == null)
                        {
                            Console.WriteLine("You are not logged in.");
                            continue;
                        }

                        currentUser = null;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Logged out.");
                        Console.ResetColor();
                        continue;
                    }
                    else if (command == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Goodbye!");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid command.");
                        Console.ResetColor();
                        continue;
                    }

                    TaskManager.UserToDoOptions(task, users, currentUser);
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number." + e);
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large or too small to be represented as an integer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}

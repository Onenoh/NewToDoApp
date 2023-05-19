using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static NewToDoApp.Validations;
using System.Threading.Tasks;
using System.Threading;

namespace NewToDoApp
{
    internal class TaskManager
    {

        public static void UserToDoOptions(List<Task> task, List<User> users, User currentUser)
        {
      
            while (true)
            {
                try
                {
                    if (users.Count > 0)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        Console.WriteLine($"Welcome {currentUser.Name}.");
                        Console.WriteLine();
                    }

                    Console.WriteLine("1.   Add task");
                    Console.WriteLine("2.   Complete task");
                    Console.WriteLine("3.   Edit Title");
                    Console.WriteLine("4.   Edit Description");
                    Console.WriteLine("5.   Edit date");
                    Console.WriteLine("6.   Edit priority level");
                    Console.WriteLine("7.   Delete task");
                    Console.WriteLine("8.   View task");
                    Console.WriteLine("9.   Exit");
                    Console.WriteLine();
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        AddTask(task, users);
                    }

                    else if (choice == 2)
                    {
                        CompleteTask(task);
                    }

                    else if (choice == 3)
                    {
                        EditTitle(task);
                    }

                    else if (choice == 4)
                    {
                        EditDescription(task);
                    }

                    else if (choice == 5)
                    {
                        EditDate(task);
                    }

                    else if (choice == 6)
                    {
                        EditPriority(task);
                    }

                    else if (choice == 7)
                    {
                        DeleteTask(task);
                    }
                    else if (choice == 8)
                    {
                        UI.HeaderDisplay();

                        UI.PrintTable(task, currentUser);

                    }
                    else if (choice == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Ciao!");
                        Console.ResetColor();
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Number is too large or too small to be represented as an integer.");
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error occurred: Please enter a valid input" );
                    Console.ResetColor();
                    continue;
                }
            }
        }

        public static void AddTask(List<Task> Task, List<User> users)
        {
            Task tasks = new Task();
            User userS = users.FirstOrDefault();
            users.Add(userS);

            Console.Write("Enter task title: ");
            tasks.Title = Console.ReadLine();

            if (string.IsNullOrEmpty(tasks.Title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a non-empty title.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter task description: ");
            tasks.Description = Console.ReadLine();

            if (string.IsNullOrEmpty(tasks.Description))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a non-empty description.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter task due date (MM/dd/yyyy): ");
            string firstDueDate = Console.ReadLine();

            if (!DateTime.TryParse(firstDueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Date not valid. Please enter a date in the format MM/dd/yyyy.");
                Console.ResetColor();
                return;
            }

            if (dueDate < DateTime.Today)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Due date must be a future date.");
                Console.ResetColor();
                return;
            }

            tasks.DueDate = dueDate;

            Console.Write("Enter task priority (Low, Medium, High): ");
            Priority.PriorityLevel Priority = (Priority.PriorityLevel)Enum.Parse(typeof(Priority.PriorityLevel), Console.ReadLine(), true);


            if (!Validation.ValidateEnumValue(Priority))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid priority. Please enter 'Low', 'Medium', or 'High'.");
                Console.ResetColor();
                return;
            }
            tasks.Priority = Priority;

            userS.Task.Add(tasks);
            
            tasks.UserId = userS.Id;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task added successfully!");
            Console.ResetColor();
        }

        public static void CompleteTask(List<Task> task)
        {
            if (task.Count > 0)
            {
                Console.WriteLine("Enter the number of the task you want to mark as complete: ");
                for (int i = 0; i < task.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ")" + task[i].IsCompleted);
                }
                int taskNum = int.Parse(Console.ReadLine()) - 1;
                task[taskNum].IsCompleted = true;
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task marked as complete successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid task number.");
                Console.ResetColor();
                Console.WriteLine();
                return;
            }
        }

        public static void EditTitle(List<Task> task)
        {
            if (task.Count > 0)
            {
                Console.WriteLine("Enter the number of the task title you want to edit: ");
                for (int i = 0; i < task.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ")" + task[i].Title);
                }
                Task newEdit = task.FirstOrDefault(task => task.Title == task.Title);
                int taskNum = int.Parse(Console.ReadLine());

                if (taskNum < 1 || taskNum > task.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter the correct number.");
                    Console.ResetColor();
                    return;
                }
                Console.WriteLine("Enter new task title:");
                string newTitle = Console.ReadLine();

                if (string.IsNullOrEmpty(newTitle))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a non-empty new title.");
                    Console.ResetColor();
                    return;
                }
                newEdit.Title = newTitle;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task title updated successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid task number.");
                Console.ResetColor();
                Console.WriteLine();
                return;
            }
        }

        public static void EditDescription(List<Task> task)
        {
            if (task.Count > 0)
            {
                Console.WriteLine("Enter the number of the task description you want to edit:");
                for (int i = 0; i < task.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ")" + task[i].Description);
                }

                if (!int.TryParse(Console.ReadLine(), out int taskNum) || taskNum < 1 || taskNum > task.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid task number. Please enter a valid integer value.");
                    Console.ResetColor();
                    return;
                }

                Task newEdit = task[taskNum - 1];
                Console.WriteLine("Enter new task description:");
                string newDescription = Console.ReadLine();

                if (string.IsNullOrEmpty(newDescription))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a non-empty new description.");
                    Console.ResetColor();
                    return;
                }
                newEdit.Description = newDescription;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task description updated successfully!");
                Console.ResetColor();
            }
        }

        public static void EditDate(List<Task> task)
        {
            if (task.Count > 0)
            {
                Console.WriteLine("Enter the number of task date to edit: ");
                for (int i = 0; i < task.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ")" + task[i].DueDate);
                }
                int taskNum = int.Parse(Console.ReadLine());

                if (taskNum > 0 && taskNum <= task.Count)
                {
                    Task newEdit = task[taskNum - 1];

                    Console.WriteLine("Enter new due date (MM-dd-yyyy):");

                    if (!DateTime.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newDueDate))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Date not valid. Please enter a date in the format MM-dd-yyyy.");
                        Console.ResetColor();
                        return;
                    }
                    newEdit.DueDate = newDueDate;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Task due date updated successfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid task number.");
                    Console.WriteLine();
                    Console.ResetColor();
                }

            }
        }

        public static void EditPriority(List<Task> task)
        {
            if (task.Count > 0)
            {
                Console.WriteLine("Enter the number of the task to edit priority level:");
                for (int i = 0; i < task.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ")" + task[i].Priority);
                }

                if (!int.TryParse(Console.ReadLine(), out int taskNum) || taskNum < 1 || taskNum > task.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid task number. Please enter a valid integer value.");
                    Console.ResetColor();
                    return;
                }

                Task newEdit = task[taskNum - 1];
                Console.WriteLine("Enter new priority level (Low, Medium, High) to edit:");
                if (!Enum.TryParse(Console.ReadLine(), true, out Priority.PriorityLevel newPriority))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid priority. Please enter 'Low', 'Medium', or 'High'.");
                    Console.ResetColor();
                    return;
                }

                newEdit.Priority = newPriority;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Task priority level updated successfully!");
                Console.ResetColor();
            }
        }

        public static void DeleteTask(List<Task> task)
        {
            if (task.Count > 0)
            {
                Console.WriteLine("Enter the number of the task you want to delete: ");

                for (int i = 0; i < task.Count; i++)
                {
                    Console.WriteLine("(" + (i + 1) + ") " + task[i].Id);
                }
                int taskNum = int.Parse(Console.ReadLine());
                taskNum--;

                if (taskNum >= 0 && taskNum < task.Count)
                {
                    task.RemoveAt(taskNum);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Task deleted successfully!");
                    Console.WriteLine("");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid task number.");
                    Console.WriteLine();
                    Console.ResetColor();
                    return;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NewToDoApp
{
    internal class UI
    {
        static readonly int tableWidth = 90;

        public static void HeaderDisplay()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                  To-Do Application                                                     ");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PrintTable(List<Task> task, User currentUser)
        {

            Console.WriteLine(CentreText("All Tasks", tableWidth));
            PrintLine();
            PrintRow("ID", "Title", "Description", "Due Date", "Priority", "Complete");
            PrintLine();
            foreach (Task tasks in task)
            {
                if (tasks.UserId == currentUser.Id && currentUser.IsNewUser)
                {
                    PrintRow(tasks.Id.ToString(), tasks.Title,
                    tasks.Description, tasks.DueDate.ToString("MM/dd/yyyy hh:mm tt"), tasks.Priority.ToString(),
                    tasks.IsCompleted ? "Completed" : "Not completed");
                }
            }
            PrintLine();
            Console.WriteLine("\n \n");

        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        static string CentreText(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            int totalSpaces = width - text.Length;
            int leftSpaces = totalSpaces / 2;
            return new string(' ', leftSpaces) + text + new string(' ', totalSpaces - leftSpaces);
        }

        public class TaskCounter
        {
            public static int count = 1;

            public static int GetNextID()
            {
                return count++;
            }
        }

    }
}


using System;
using System.Collections.Generic;

namespace NewToDoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task> task = new List<Task>();
            List<User> users = new List<User>();

            MainEntries.Entries(task, users);
        }
    }
}

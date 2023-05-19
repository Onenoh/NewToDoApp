using System;
using System.Collections.Generic;
using System.Text;

namespace NewToDoApp
{
    internal class MainEntries
    {
        private static User currentUser;

        public static void Entries(List<Task> task, List<User> users)
        {

                UI.HeaderDisplay();

                Registration.UserRegistration(task, users);
                TaskManager.UserToDoOptions(task, users, currentUser);
        }
    }
}

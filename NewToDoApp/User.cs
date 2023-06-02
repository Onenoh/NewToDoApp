using System;
using System.Collections.Generic;
using System.Text;

namespace NewToDoApp
{
    internal class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Task> Task { get; set; } = new List<Task>();
    }
}

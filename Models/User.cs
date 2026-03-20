using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.models
{
    public class User
    {
        private static int _nextId = 1;
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }

        public User(string firstName, string lastName, UserType type)
        {
            IdUser = _nextId++;
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }
    }
}

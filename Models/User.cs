using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User
{
    private static int _nextId = 1;
    public int IdUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType Type { get; set; }
    public User(string FirstName, string LastName, UserType Type)
    {
        IdUser = _nextId++;
        FirstName = FirstName;
        LastName = LastName;
        Type = Type;
    }
    
}
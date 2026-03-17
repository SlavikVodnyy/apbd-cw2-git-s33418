using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rental : IRentalServices
{
    public void addEquipment(Equipment equipment)
    {
        Database.Singleton.Instance.Equipment.Add(equipment);
    }
    public void addUser(User user)
    {
        Database.Singleton.Instance.Users.Add(user);
    }
    public List<Equipment> getAllequipment()
    {
        return Database.Singleton.Instance.Equipment;
    }
    public List<Equipment> GetAllAvailableEquipment()
    {
        return Database.Singleton.Instance.Equipment.Where(e => e.IsAvailable).ToList();
    }
    public string generateReport()
    {
        var report = new StringBuilder();
        report.AppendLine("Rental Report:");
        report.AppendLine("Users:");
        foreach (var user in Database.Singleton.Instance.Users)
        {
            report.AppendLine($"- {user.FirstName} {user.LastName} ({user.Type})");
        }
        report.AppendLine("Equipment:");
        foreach (var equipment in Database.Singleton.Instance.Equipment)
        {
            report.AppendLine($"- {equipment.Name} (Available: {equipment.IsAvailable})");
        }
        return report.ToString();
    }
}
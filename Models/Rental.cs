using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APBD_TASK2.Database;
using APBD_TASK2.models;

namespace APBD_TASK2.models
{
    public class Rental : IRentalServices
    {
        public void addEquipment(Equipment equipment)
        {
            Singleton.Instance.Equipment.Add(equipment);
        }

        public void addUser(User user)
        {
            Singleton.Instance.Users.Add(user);
        }

        public List<Equipment> getAllequipment()
        {
            return Singleton.Instance.Equipment;
        }

        public List<Equipment> GetAllAvailableEquipment()
        {
            return Singleton.Instance.Equipment.Where(e => e.IsAvailable).ToList();
        }

        public string generateReport()
        {
            var report = new StringBuilder();
            report.AppendLine("Rental Report:");
            report.AppendLine("Users:");
            foreach (var user in Singleton.Instance.Users)
            {
                report.AppendLine($"- {user.FirstName} {user.LastName} ({user.Type})");
            }
            report.AppendLine("Equipment:");
            foreach (var equipment in Singleton.Instance.Equipment)
            {
                report.AppendLine($"- {equipment.Name} (Available: {equipment.IsAvailable})");
            }
            return report.ToString();
        }
    }
}

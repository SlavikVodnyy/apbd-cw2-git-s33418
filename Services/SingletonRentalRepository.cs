using APBD_TASK2.Database;
using System.Collections.Generic;
using APBD_TASK2.models;
using APBD_TASK2.Interfaces;

namespace APBD_TASK2.Services
{
    public class SingletonRentalRepository : IRentalRepository
    {
        public List<Equipment> GetAllEquipment() => Singleton.Instance.Equipment;

        public List<User> GetAllUsers() => Singleton.Instance.Users;

        public List<RentalRecord> GetAllRentalRecords() => Singleton.Instance.RentalRecords;

        public void AddEquipment(Equipment equipment) => Singleton.Instance.Equipment.Add(equipment);

        public void AddUser(User user) => Singleton.Instance.Users.Add(user);

        public void AddRentalRecord(RentalRecord record) => Singleton.Instance.RentalRecords.Add(record);
    }
}

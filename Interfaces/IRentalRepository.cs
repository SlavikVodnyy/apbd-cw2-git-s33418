using System.Collections.Generic;
using APBD_TASK2.models;

namespace APBD_TASK2.Interfaces
{
    public interface IRentalRepository
    {
        List<Equipment> GetAllEquipment();
        List<User> GetAllUsers();
        List<RentalRecord> GetAllRentalRecords();

        void AddEquipment(Equipment equipment);
        void AddUser(User user);
        void AddRentalRecord(RentalRecord record);
    }
}

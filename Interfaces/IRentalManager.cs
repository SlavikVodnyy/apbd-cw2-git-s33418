using System.Collections.Generic;
using APBD_TASK2.models;
using APBD_TASK2.Services;

namespace APBD_TASK2.Interfaces
{
    public interface IRentalManager
    {
        OperationResult AddEquipment(Equipment equipment);
        OperationResult AddUser(User user);
        OperationResult RentEquipment(int userId, int equipmentId, int days);
        OperationResult ReturnEquipment(int equipmentId, DateTime returnDate );
        List<Equipment> GetAvailableEquipment();
        string GenerateReport();
    }
}

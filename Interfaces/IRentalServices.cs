using System;

public interface IRentalServices
{
   void addUser(User user);
    void addEquipment(Equipment equipment);
    List<Equipment> getAllequipment();
    List<Equipment> GetAllAvailableEquipment();
    string generateReport();
}

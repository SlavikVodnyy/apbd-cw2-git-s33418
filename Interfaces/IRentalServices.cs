using System;
using System.Collections.Generic;
using APBD_TASK2.models;

public interface IRentalServices
{
    void addUser(User user);
    void addEquipment(Equipment equipment);
    List<Equipment> getAllequipment();
    List<Equipment> GetAllAvailableEquipment();
    string generateReport();
}

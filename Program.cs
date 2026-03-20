using APBD_TASK2.Database;
using APBD_TASK2.models;
using APBD_TASK2.Models;
using APBD_TASK2.Services;

var repository = new SingletonRentalRepository();
var manager = new RentalManager(repository);

// Equipment
var laptop = new Laptop("Lenovo ThinkPad X1 Carbon", "Portable laptop", 16, 15);
var mobilePhone = new Mobile("iPhone 17 Pro", "Latest iPhone model", 512);
var tablet = new Tablet("iPad Pro", "High-end tablet", 1024);
var ipadAir = new Tablet("iPad Air", "Mid-range tablet", 256);
var desktop = new Laptop("Dell XPS 8940", "Powerful laptop", 32, 27);

manager.AddEquipment(laptop);
manager.AddEquipment(mobilePhone);
manager.AddEquipment(tablet);
manager.AddEquipment(ipadAir);
manager.AddEquipment(desktop);

// Users
var user1 = new User("Ivan", "Ivanov", UserType.student);
var user2 = new User("Anna", "Petrova", UserType.employee);
var user3 = new User("John", "Smith", UserType.student);

manager.AddUser(user1);
manager.AddUser(user2);
manager.AddUser(user3);

// Rentals
var rentResult1 = manager.RentEquipment(user1.IdUser, laptop.IdEquipment, 7);
Console.WriteLine(rentResult1.Message);

var rentResult2 = manager.RentEquipment(user1.IdUser, ipadAir.IdEquipment, 3);
Console.WriteLine(rentResult2.Message);

var rentResult3 = manager.RentEquipment(user1.IdUser, desktop.IdEquipment, 5);
Console.WriteLine(rentResult3.Message);

var rentResult4 = manager.RentEquipment(user2.IdUser, mobilePhone.IdEquipment, 1);
Console.WriteLine(rentResult4.Message);

var rentResult5 = manager.RentEquipment(user3.IdUser, tablet.IdEquipment, 5);
Console.WriteLine(rentResult5.Message);

// Return
var returnDate = DateTime.Now;

var returnResult = manager.ReturnEquipment(laptop.IdEquipment, returnDate);
Console.WriteLine(returnResult.Message);

var lateDate = DateTime.Now.AddDays(5);

var returnResult1 = manager.ReturnEquipment(mobilePhone.IdEquipment, lateDate);

Console.WriteLine(returnResult.Message);

// Report
Console.WriteLine(manager.GenerateReport());


using APBD_TASK2.Database;
using APBD_TASK2.models;
using APBD_TASK2.Services;
using APBD_TASK2.Models;


var repository = new SingletonRentalRepository();
var manager = new RentalManager(repository);

var laptop = new Laptop("Lenovo ThinkPad X1 Carbon", "Portable laptop", 16, 15);
manager.AddEquipment(laptop);

var mobilePhone = new Mobile("iPhone 17 Pro", "Latest iPhone model", 512);
manager.AddEquipment(mobilePhone);

var tablet = new Tablet("iPad Pro", "High-end tablet", 1024);
manager.AddEquipment(tablet);

var  IpadAir = new Tablet("iPad Air", "Mid-range tablet", 256);
manager.AddEquipment(IpadAir);

var desktop = new Laptop("Dell XPS 8940", "Powerful laptop", 32, 27);


var user = new User("Ivan", "Ivanov", UserType.student);
manager.AddUser(user);
var user2 = new User("Anna", "Petrova", UserType.employee);
manager.AddUser(user2);
var user3 = new User("John", "Smith", UserType.student);
manager.AddUser(user3);



var rentResult = manager.RentEquipment(user.IdUser, laptop.IdEquipment, 7);
Console.WriteLine(rentResult.Message);
manager.CheckLimit(user.IdUser);


var rentResult1 = manager.RentEquipment(user.IdUser, IpadAir.IdEquipment, 3);
Console.WriteLine(rentResult1.Message);
manager.CheckLimit(user.IdUser);

var rentResult4 = manager.RentEquipment(user.IdUser, desktop.IdEquipment, 5);
Console.WriteLine(rentResult4.Message);
manager.CheckLimit(user.IdUser);

var rentResult2 = manager.RentEquipment(user2.IdUser, mobilePhone.IdEquipment, 10);
Console.WriteLine(rentResult2.Message);

var rentResult3 = manager.RentEquipment(user3.IdUser, tablet.IdEquipment, 5);
Console.WriteLine(rentResult3.Message);

var returnResult = manager.ReturnEquipment(laptop.IdEquipment);
Console.WriteLine(returnResult.Message);

Console.WriteLine(manager.GenerateReport());

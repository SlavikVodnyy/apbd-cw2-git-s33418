

using APBD_TASK2.Database;
using APBD_TASK2.models;

var db = Singleton.Instance;

var laptop = new Laptop("Lenovo ThinkPad X1 Carbon", "Portable laptop", 16, 15);
db.Equipment.Add(laptop);


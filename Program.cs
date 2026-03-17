

using APBD_TASK2.Database;

var db = Singleton.Instance;

var laptop = new models.Laptop("Lenovo ThinkPad X1 Carbon", 16, 15);
db.Equipment.Add(laptop);


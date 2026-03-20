using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Database
{
    public class Singleton
    {
        private static Singleton? _instance;
        public static Singleton Instance
        {
            get
            {
                _instance ??= new Singleton();
                return _instance;
            }
        }

        private Singleton() { }

        //TODO: add collections for items in the exercise
        //public List<Class> Class { get; } = new();

        public List<models.Equipment> Equipment { get; set; } = new List<models.Equipment>();
        public List<models.User> Users { get; set; } = new List<models.User>();
        public List<models.RentalRecord> RentalRecords { get; set; } = new List<models.RentalRecord>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.models
{
    public  abstract class Equipment
    {
        public int IdEquipment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime addedData { get; set; }
        public EquipmentStatus Status { get; set; }

        public Equipment(string Name, string Description)
        {
            IdEquipment = _nextId++;
            Name = Name;
            Description = Description;
            addedData = DateTime.Now;
            Status = EquipmentStatus.available;
        }
    }
}
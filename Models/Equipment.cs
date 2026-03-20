using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.models
{
    public abstract class Equipment
    {
        private static int _nextId = 1;

        public int IdEquipment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public EquipmentStatus Status { get; set; }

        public bool IsAvailable => Status == EquipmentStatus.available;

        public Equipment(string name, string description)
        {
            IdEquipment = _nextId++;
            Name = name;
            Description = description;
            AddedDate = DateTime.Now;
            Status = EquipmentStatus.available;
        }
    }
}

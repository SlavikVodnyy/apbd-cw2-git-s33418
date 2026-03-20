using APBD_TASK2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class Tablet : Equipment
    {
        public int Space { get; set; }

        public Tablet(string name, string description, int space)
            : base(name, description)
        {
            Space = space;
        }
    }
}

using APBD_TASK2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Models
{
    internal class Mobile : Equipment
    {
        public int Space { get; set; }
       
        public Mobile( string name, string descrption, int space)
            : base(name, descrption)
        {
            Space = space;
        }
    }
}

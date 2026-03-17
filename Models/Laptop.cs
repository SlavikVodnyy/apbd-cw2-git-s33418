using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.models
{
    public class Laptop : Equipment
    {
        public int RamGB { get; set; }
        public int ScreenSize { get; set; }

        public Laptop(string Name, int RamGB, int ScreenSize) {
        : base(name)
                {  RamGB = RamGB;
                   ScreenSize = screen;
                }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMemory.Model
{
    public class MemPossition
    {
        public MemPossition(int x, int y)
        {
            memX = x; memY = y;
        }

        public int memX { get; set; }
        public int memY { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace win2d_village
{
    static class Statics
    {
        public static Random Random;
        static Statics()
        {
            Random = new Random(DateTime.Now.Millisecond);
        }
    }
}

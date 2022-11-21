using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMonthPreperationKit
{
    class FlippingBits
    {

        public static long RunExercise(long n)
        {   
            return ~Convert.ToUInt32(n);
        }

        public static void Run()
        {
            Console.WriteLine(RunExercise(3));
        }
    }
}

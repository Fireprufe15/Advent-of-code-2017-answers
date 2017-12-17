using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay17 {
    class Program {
        static void Main(string[] args) {

            List<int> buffer = new List<int> { 0 };
            var stepValue = int.Parse(Console.ReadLine());
            int insertVal = 0;
            int marker = 0;
            int numberAfterZero = 0;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            while (insertVal < 2017) {
                marker += stepValue;
                while (marker > insertVal) {
                    marker -= insertVal + 1;
                }
                insertVal++;
                //buffer.Insert(marker + 1, insertVal);
                if (marker + 1 == 1) {
                    numberAfterZero = insertVal;
                }
                marker++;
            }
            //var nextNumber = buffer[buffer.IndexOf(2017) + 1];
            stopWatch.Stop();
            Console.WriteLine(numberAfterZero);
            Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString());
            Console.ReadKey();
        }
    }
    //Part 1: < 1 ms
    //Part 2: 212 ms
}

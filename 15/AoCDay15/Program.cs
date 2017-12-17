using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay15 {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Gen A Value: ");
            var genA = long.Parse(Console.ReadLine());
            Console.WriteLine("Gen B Value: ");
            var genB = long.Parse(Console.ReadLine());

            var score = 0;

            for (int i = 0; i < 5000000; i++) {

                long genANewVal = 9999;
                while (genANewVal % 4 != 0) {
                    genANewVal = (genA * 16807) % 2147483647;
                    genA = genANewVal;
                }

                long genBNewVal = 9999;
                while (genBNewVal % 8 != 0) {
                    genBNewVal = (genB * 48271) % 2147483647;
                    genB = genBNewVal;
                }

                var aBinary = Convert.ToString(genANewVal, 2).PadLeft(32,'0');
                var bBinary = Convert.ToString(genBNewVal, 2).PadLeft(32, '0');
                if (aBinary.Substring(aBinary.Length-16) == bBinary.Substring(bBinary.Length - 16)) {
                    score++;
                }
                //genA = genANewVal;
                //genB = genBNewVal;
            }

            Console.WriteLine(score);
            Console.ReadKey();

        }
    }
}

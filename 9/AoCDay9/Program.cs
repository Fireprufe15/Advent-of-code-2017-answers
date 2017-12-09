using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay9 {
    class Program {
        static void Main(string[] args) {

            var garbageDisposal = 0;
            bool insideGarbage = false;
            var openedBrackets = 0;
            var score = 0;
            string input = "";
            using (TextReader tr = new StreamReader(new FileStream("input.txt", FileMode.OpenOrCreate))) {
                input = tr.ReadToEnd();
            }

            for (int i = 0; i < input.Length; i++) {

                if (insideGarbage) {

                    if (input[i] == '!') {
                        i++;
                        continue;
                    }

                    if (input[i] == '>') {
                        insideGarbage = false;
                        continue;
                    }
                    garbageDisposal++;
                    continue;

                }

                if (input[i] == '{') {

                    openedBrackets++;
                    score += openedBrackets;
                    continue;

                }

                if (input[i] == '}') {
                    openedBrackets--;
                    continue;
                }

                if (input[i] == ',') {
                    continue;
                }

                if (input[i] == '<') {

                    insideGarbage = true;
                    continue;

                }

            }
            Console.WriteLine("Score: "+score);
            Console.WriteLine("Garbage Disposal: " + garbageDisposal);
            Console.ReadKey();
        }
    }
}

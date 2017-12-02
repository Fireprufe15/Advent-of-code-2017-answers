using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay1Part2 {
    class Program {
        static void Main(string[] args) {

            string input; /*= Console.ReadLine();*/

            using (TextReader tr = new StreamReader(new FileStream("in.txt", FileMode.OpenOrCreate))) {
                input = tr.ReadToEnd();
            }

            List<int> vals = new List<int>();

            for (int i = 0; i < input.Length; i++) {
                if (i >= input.Length/2) {
                    var loc = input.Length - i;
                    var looped = (input.Length / 2) - loc;
                    if (input[looped] == input[i]) {
                        vals.Add(int.Parse(input[i].ToString()));
                    }
                    continue;
                }
                if (input[i] == input[i + (input.Length/2)]) {
                    vals.Add(int.Parse(input[i].ToString()));
                }
            }

            var res = vals.Sum();
            Console.WriteLine(res);
            Console.ReadKey();

        }

    }    
}

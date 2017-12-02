using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay1 {
    class Program {
        static void Main(string[] args) {

            string input;

            using (TextReader tr = new StreamReader(new FileStream("in.txt", FileMode.OpenOrCreate))) {
                input = tr.ReadToEnd();
            }

            List<int> vals = new List<int>();

            for (int i = 0; i < input.Length; i++) {
                if (i == input.Length-1) {
                    if (input[i] == input[0]) {
                        vals.Add(int.Parse(input[i].ToString()));                        
                    }
                    continue;
                }
                if (input[i] == input[i+1]) {
                    vals.Add(int.Parse(input[i].ToString()));
                }
            }

            var res = vals.Sum();
            Console.WriteLine(res);
            Console.ReadKey();

        }
    }
}

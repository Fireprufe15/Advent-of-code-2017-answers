using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay2 {
    class Program {
        static void Main(string[] args) {

            int sum = 0;
            char delimiter = '\t';
            List<List<int>> table = new List<List<int>>();

            using (TextReader tr = new StreamReader(new FileStream("in.txt", FileMode.OpenOrCreate))) {
                while (tr.Peek() > 0) {
                    string[] line = tr.ReadLine().Split(delimiter);
                    int[] line2 = Array.ConvertAll<String, int>(line, int.Parse);
                    table.Add(line2.ToList());
                }
            }

            foreach (var item in table) {

                var max = item.Max();
                var min = item.Min();
                sum += max - min;

            }

            Console.WriteLine(sum.ToString());
            Console.ReadKey();

        }
    }
}

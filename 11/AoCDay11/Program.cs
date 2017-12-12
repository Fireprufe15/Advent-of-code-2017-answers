using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay11 {
    class Program {
        static void Main(string[] args) {

            var x = 0;
            var y = 0;
            var z = 0;
            var furthestDistance = 0;
            List<string> instructions = new List<string>();

            using (TextReader tr = new StreamReader("input.txt")) {

                var text = tr.ReadToEnd();
                var items = text.Split(',');
                foreach (var item in items) {
                    instructions.Add(item);
                }

            }

            foreach (var item in instructions) {
                switch (item) {
                    case "n":
                        z--;
                        y++;
                        break;
                    case "ne":
                        z--;
                        x++;
                        break;
                    case "nw":
                        y++;
                        x--;
                        break;
                    case "s":
                        y--;
                        z++;
                        break;
                    case "se":
                        x++;
                        y--;
                        break;
                    case "sw":
                        x--;
                        z++;
                        break;
                    default:
                        break;
                }
                var dist = (Math.Abs(x) + Math.Abs(y) + Math.Abs(z)) / 2;
                if (dist > furthestDistance) furthestDistance = dist;
            }

            Console.WriteLine((Math.Abs(x)+Math.Abs(y) + Math.Abs(z))/2);
            Console.WriteLine(furthestDistance);
            Console.ReadKey();

        }
    }
}

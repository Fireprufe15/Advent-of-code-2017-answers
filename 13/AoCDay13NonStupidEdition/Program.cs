using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay13NonStupidEdition {
    class Program {
        static void Main(string[] args) {

            List<int> layers = new List<int>();
            int layerCounter = 0;

            using (TextReader tr = new StreamReader("input.txt")) {
                while (tr.Peek() > 0) {
                    var item = tr.ReadLine();
                    var items = item.Split(new string[] { ": " }, StringSplitOptions.None);
                    while (layerCounter < int.Parse(items[0])) {
                        layers.Add(0);
                        layerCounter++;
                    }
                    if (items[0] == layerCounter.ToString()) {
                        layers.Add(int.Parse(items[1]));
                        layerCounter++;
                    }
                }
            }

            int delay = 0;
            bool caught = false;
            do {
                caught = false;
                var time = 0 + delay;
                foreach (var item in layers) {
                    if (item == 0) {
                        time++;
                        continue;
                    }
                    if (Math.Abs(time % ((2 * item)-2)) == 0) {
                        caught = true;
                        break;
                    }
                    time++;
                }
                delay++;

            } while (caught);
            Console.WriteLine(delay-1);
            Console.ReadKey();
        }
    }
}

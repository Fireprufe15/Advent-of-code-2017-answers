using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay13 {
    class Program {
        static void Main(string[] args) {

            int packetPosition = 0;
            int layerCounter = 0;
            int severity = 0;
            var layers = new List<int[]>();
            using (TextReader tr = new StreamReader("input.txt")) {
                while (tr.Peek() > 0) {
                    var item = tr.ReadLine();
                    var items = item.Split(new string[] { ": " }, StringSplitOptions.None);
                    while (layerCounter < int.Parse(items[0])) {
                        layers.Add(new int[0]);
                        layerCounter++;
                    }
                    if (items[0] == layerCounter.ToString()) {
                        layers.Add(new int[int.Parse(items[1])]);
                        layerCounter++;
                    }
                }
            }            

            var delay = 0;
            bool caught = false;
            do {
                caught = false;
                packetPosition = 0 - delay;
                severity = 0;
                foreach (var item in layers) {
                    for (int i = 0; i < item.Length; i++) {
                        item[i] = 0;
                    }
                }

                foreach (var item in layers) {
                    if (item.Length != 0) item[0] = 1;
                }
                while (packetPosition < layerCounter) {

                    if (packetPosition > -1 && layers[packetPosition].Length != 0 && (layers[packetPosition][0] == 1 || layers[packetPosition][0] == 2)) {
                        caught = true;                        
                        severity += (packetPosition * layers[packetPosition].Length);
                        break;
                    }
                    packetPosition++;
                    foreach (var item in layers) {
                        var pos = 0;
                        var reverse = false;
                        for (int i = 0; i < item.Length; i++) {
                            if (item[i] == 1) {
                                pos = i;
                                item[i] = 0;
                                break;
                            }
                            if (item[i] == 2) {
                                reverse = true;
                                pos = i;
                                item[i] = 0;
                                break;
                            }
                        }
                        try {
                            if (!reverse && item.Length != 0) item[pos + 1] = 1;
                            if (reverse && item.Length != 0) item[pos - 1] = 2;
                        }
                        catch (IndexOutOfRangeException e) {

                            if (pos == 0) {
                                item[1] = 1;
                            }
                            else {
                                item[pos - 1] = 2;
                            }
                        }
                    }
                }
                delay++;
            } while (caught);


            Console.WriteLine(delay-1);
            Console.ReadKey();
        }
    }
}

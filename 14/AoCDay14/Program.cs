using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AoCDay14 {
    class Program {
        static void Main(string[] args) {

            KnotHasher.KnotHasher knot = new KnotHasher.KnotHasher();
            var input = Console.ReadLine();
            List<string> hashes = new List<string>();
            List<string> binaryHashes = new List<string>();
            for (int i = 0; i < 128; i++) {
                hashes.Add(knot.Hash(input + "-" + i.ToString()));
            }

            foreach (var item in hashes) {
                string binarystring = String.Join(String.Empty,
                    item.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                    )
                );
                binaryHashes.Add(binarystring);
            }

            var blockCount = 0;
            foreach (var item in binaryHashes) {
                blockCount += item.Where(x => x == '1').Count();
            }

            int[,] regionTable = new int[128,128];

            int highestRegion = 0;
            foreach (var item in binaryHashes) {
                for (int i = 0; i < item.Length; i++) {
                    var itemIndex = binaryHashes.IndexOf(item);
                    if (item[i] == '1' && regionTable[itemIndex,i] == 0) {
                        highestRegion++;
                        var existingCoords = new List<Tuple<int, int>>();
                        try {                            
                            var regionCoords = TraceRegion(existingCoords, binaryHashes, new Tuple<int, int>(itemIndex, i));                            
                            foreach (var coord in regionCoords) {
                                regionTable[coord.Item1, coord.Item2] = highestRegion;
                            }
                        }
                        catch (StackOverflowException e) {
                            Console.WriteLine(e.Message);                          
                        }
                        
                       
                    }
                }
            }

            Console.WriteLine(blockCount);
            Console.WriteLine(highestRegion);

            for (int i = 0; i < 128; i++) {
                for (int j = 0; j < 128; j++) {
                    Console.Write(regionTable[i, j] + "\t");
                }
                Console.Write("\n");
            }

            Console.ReadKey();
        }

        public static List<Tuple<int, int>> TraceRegion(List<Tuple<int, int>> existingCoords, List<string> hashes, Tuple<int, int> startCoords) {

            bool exhausted = false;
            existingCoords.Add(startCoords);
            while (!exhausted) {
                exhausted = true;
                foreach (var item in new List<Tuple<int,int>>(existingCoords)) {
                    if (item.Item1 > 0 && hashes[item.Item1 - 1][item.Item2] == '1' && !existingCoords.Contains(new Tuple<int, int>(item.Item1 - 1, item.Item2))) {
                        existingCoords.Add(new Tuple<int, int>(item.Item1 - 1, item.Item2));
                        exhausted = false;
                    }
                    if (item.Item2 > 0 && hashes[item.Item1][item.Item2 - 1] == '1' && !existingCoords.Contains(new Tuple<int, int>(item.Item1, item.Item2 - 1))) {
                        existingCoords.Add(new Tuple<int, int>(item.Item1, item.Item2 - 1));
                        exhausted = false;
                    }
                    if (item.Item1 < 127 && hashes[item.Item1 + 1][item.Item2] == '1' && !existingCoords.Contains(new Tuple<int, int>(item.Item1 + 1, item.Item2))) {
                        existingCoords.Add(new Tuple<int, int>(item.Item1 + 1, item.Item2));
                        exhausted = false;
                    }
                    if (item.Item2 < 127 && hashes[item.Item1][item.Item2 + 1] == '1' && !existingCoords.Contains(new Tuple<int, int>(item.Item1, item.Item2 + 1))) {
                        existingCoords.Add(new Tuple<int, int>(item.Item1, item.Item2 + 1));
                        exhausted = false;
                    }
                }
            }
            return existingCoords;

        }
    }
}

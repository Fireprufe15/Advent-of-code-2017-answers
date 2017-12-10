using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocDay10 {
    class Program {
        static void Main(string[] args) {

            int skipSize = 0;
            int position = 0;
            List<int> list = new List<int>(256);
            List<int> denseHash = new List<int>();

            for (int i = 0; i < 256; i++) {
                list.Add(i);
            }

            List<int> lengths = new List<int>();

            using (TextReader tr = new StreamReader("input.txt")) {

                var st = tr.ReadLine();
                foreach (var item in st) {
                    lengths.Add((int)item);
                }

            }
            lengths.AddRange(new int[] { 17, 31, 73, 47, 23 });

            for (int i = 0; i < 64; i++) {
                foreach (var item in lengths) {

                    if (position + item < list.Count) {
                        var subsequence = list.GetRange(position, item);
                        subsequence.Reverse();
                        list.RemoveRange(position, item);
                        list.InsertRange(position, subsequence);
                    }
                    else {
                        var sub = list.GetRange(position, list.Count - position);
                        var remainingCount = item - sub.Count;
                        var sub2 = list.GetRange(0, remainingCount);
                        sub.AddRange(sub2);
                        sub.Reverse();
                        list.RemoveRange(position, list.Count - position);
                        list.InsertRange(list.Count, sub.Take(sub.Count - sub2.Count));
                        sub.RemoveRange(0, sub.Count - sub2.Count);
                        list.RemoveRange(0, sub.Count);
                        list.InsertRange(0, sub);
                    }

                    position += item + skipSize;
                    skipSize++;
                    while (position >= list.Count) {
                        position -= list.Count;
                    }
                }
            }

            for (int i = 0; i < 16; i++) {
                var subList = list.Take(16).ToList();
                var res = subList[0] ^ subList[1] ^ subList[2] ^ subList[3] ^ subList[4] ^ subList[5] ^ subList[6] ^ subList[7] ^ subList[8] ^ subList[9] ^ subList[10] ^ subList[11] ^ subList[12] ^ subList[13] ^ subList[14] ^ subList[15];
                denseHash.Add(res);
                list.RemoveRange(0, 16);
            }

            string final = "";
            foreach (var item in denseHash) {
                var hex = item.ToString("X");
                if (hex.Length == 1) {
                    hex = hex.Insert(0, "0");
                }
                final += hex;
            }

            Console.WriteLine(final);
            Console.ReadKey();

        }
    }
}

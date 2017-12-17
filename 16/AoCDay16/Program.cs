using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay16 {
    class Program {
        static void Main(string[] args) {

            string original = "abcdefghijklmnop";
            List<char> programs = new List<char>(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' });
            string[] moves;
            int danceCount = 0;
            using (TextReader tr = new StreamReader("input.txt")) {
                string line = tr.ReadToEnd();
                moves = line.Split(',');
            }
            while (true) {
                foreach (var item in moves) {
                    switch (item[0]) {
                        case 's':
                            var moveCount = int.Parse(item.Substring(1));
                            for (int i = 0; i < moveCount; i++) {
                                var letter = programs.Last();
                                programs.Remove(letter);
                                programs.Insert(0, letter);
                            }
                            break;
                        case 'p':
                            var firstLetter = item[1];
                            var secondLetter = item[3];
                            var indexFirst = programs.IndexOf(firstLetter);
                            var indexSecond = programs.IndexOf(secondLetter);
                            programs[indexFirst] = secondLetter;
                            programs[indexSecond] = firstLetter;
                            break;
                        case 'x':
                            var commandPars = item.Remove(0, 1).Split('/');
                            var letterOne = programs[int.Parse(commandPars[0])];
                            var letterTwo = programs[int.Parse(commandPars[1])];
                            programs[int.Parse(commandPars[0])] = letterTwo;
                            programs[int.Parse(commandPars[1])] = letterOne;
                            break;
                        default:
                            break;
                    }
                }
                danceCount++;
                var danceString = "";
                foreach (var item in programs) {
                    danceString += item;
                }
                if (danceString == original) {
                    break;
                }
            }

            danceCount = 1000000000 % danceCount;

            for (int j = 0; j < danceCount; j++) {
                {
                    foreach (var item in moves) {
                        switch (item[0]) {
                            case 's':
                                var moveCount = int.Parse(item.Substring(1));
                                for (int i = 0; i < moveCount; i++) {
                                    var letter = programs.Last();
                                    programs.Remove(letter);
                                    programs.Insert(0, letter);
                                }
                                break;
                            case 'p':
                                var firstLetter = item[1];
                                var secondLetter = item[3];
                                var indexFirst = programs.IndexOf(firstLetter);
                                var indexSecond = programs.IndexOf(secondLetter);
                                programs[indexFirst] = secondLetter;
                                programs[indexSecond] = firstLetter;
                                break;
                            case 'x':
                                var commandPars = item.Remove(0, 1).Split('/');
                                var letterOne = programs[int.Parse(commandPars[0])];
                                var letterTwo = programs[int.Parse(commandPars[1])];
                                programs[int.Parse(commandPars[0])] = letterTwo;
                                programs[int.Parse(commandPars[1])] = letterOne;
                                break;
                            default:
                                break;
                        }
                    }
                }                
            }
            var finalstring = "";
            foreach (var item in programs) {
                finalstring += item;
            }
            Console.WriteLine(finalstring);
            Console.ReadKey();
        }
    }
}

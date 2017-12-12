using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay12 {
    class Program {
        static void Main(string[] args) {

            List<ProgramPipe> programs = new List<ProgramPipe>();
            using (TextReader tr = new StreamReader("input.txt")) {
                while (tr.Peek() > 0) {
                    var line = tr.ReadLine();
                    var lineSplit = line.Split(new string[] { " <-> " }, StringSplitOptions.None);
                    var lineSplit2 = lineSplit[1].Split(new string[] { ", " }, StringSplitOptions.None);
                    foreach (var item in lineSplit2) {
                        var existingLink = programs.Where(x => x.ProgramName == item).FirstOrDefault();
                        if (existingLink == null) {
                            programs.Add(new ProgramPipe(item));
                        }
                    }
                    var existingItem = programs.Where(x => x.ProgramName == lineSplit[0]).FirstOrDefault();
                    if (existingItem != null) {
                        foreach (var item in lineSplit2) {
                            var link = programs.Where(x => x.ProgramName == item).FirstOrDefault();
                            existingItem.Links.Add(link);
                        }
                    }
                    else {
                        programs.Add(new ProgramPipe() {
                            ProgramName = lineSplit[0],
                        });
                        var addedItem = programs.Where(x => x.ProgramName == lineSplit[0]).FirstOrDefault();
                        foreach (var item in lineSplit2) {
                            var link = programs.Where(x => x.ProgramName == item).FirstOrDefault();
                            addedItem.Links.Add(link);
                        }
                    }
                }                
            }

            List<ProgramPipe> visitedNodes = new List<ProgramPipe>();
            var answer = connectedNodeCount(programs.Where(x => x.ProgramName == "0").First(), visitedNodes);
            Console.WriteLine(answer);
            Console.WriteLine(groupCount(programs));
            Console.ReadKey();
        }

        static int connectedNodeCount(ProgramPipe pp, List<ProgramPipe> visitedNodes) {
            visitedNodes.Add(pp);
            var count = 1;
            foreach (var item in pp.Links) {
                if (!visitedNodes.Contains(item)) {
                    count += connectedNodeCount(item, visitedNodes);
                }
            }
            return count;
        }

        static int groupCount(List<ProgramPipe> programs) {
            int groups = 0;
            while (programs.Count > 0) {
                List<ProgramPipe> visitedNodes = new List<ProgramPipe>();
                connectedNodeCount(programs[0], visitedNodes);
                groups++;
                programs.RemoveAll(x => visitedNodes.Contains(x));
            }
            return groups;
        }
    }

    public class ProgramPipe {

        public string ProgramName { get; set; }
        public List<ProgramPipe> Links { get; set; }
        public ProgramPipe() {
            Links = new List<ProgramPipe>();
        }
        public ProgramPipe(string name) {
            this.ProgramName = name;
            Links = new List<ProgramPipe>();
        }

    }
}

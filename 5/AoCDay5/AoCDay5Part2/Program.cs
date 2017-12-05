using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay5Part2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> commands = new List<int>();

            using (TextReader tr = new StreamReader(new FileStream("input.txt", FileMode.OpenOrCreate)))
            {
                while (tr.Peek() > 0)
                {
                    commands.Add(int.Parse(tr.ReadLine()));
                }
            }

            int stepCounter = 0;
            var pos = 0;
            while (pos < commands.Count && pos > -1)
            {
                stepCounter++;
                var newpos = pos + commands[pos];
                if (commands[pos] >= 3)
                {
                    commands[pos]--;
                }
                else
                {
                    commands[pos]++;
                }
                pos = newpos;
            }
            Console.WriteLine(stepCounter);
            Console.ReadKey();
        }
    }
}

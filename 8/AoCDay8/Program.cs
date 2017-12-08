using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay8
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxValue = 0;
            var registers = new List<Register>();
            List<string[]> commands = new List<string[]>();
            using (TextReader tr = new StreamReader(new FileStream("input.txt", FileMode.OpenOrCreate)))
            {
                while (tr.Peek() > 0)
                {                    
                    var parts = tr.ReadLine().Split(' ');
                    commands.Add(parts);
                    if (registers.Where(x => x.Name == parts[0]).Count() == 0)
                    {
                        registers.Add(new Register(parts[0]));
                    }
                }
            }
            foreach (var item in commands)
            {
                var conditionRegister = registers.Where(x => x.Name == item[4]).First();
                var effectRegister = registers.Where(x => x.Name == item[0]).First();
                bool doIt = false;
                switch (item[5])
                {
                    case ">":
                        doIt = conditionRegister.Value > int.Parse(item[6]);
                        break;
                    case "<":
                        doIt = conditionRegister.Value < int.Parse(item[6]);
                        break;
                    case ">=":
                        doIt = conditionRegister.Value >= int.Parse(item[6]);
                        break;
                    case "<=":
                        doIt = conditionRegister.Value <= int.Parse(item[6]);
                        break;
                    case "==":
                        doIt = conditionRegister.Value == int.Parse(item[6]);
                        break;
                    case "!=":
                        doIt = conditionRegister.Value != int.Parse(item[6]);
                        break;
                    default:
                        break;
                }
                if (doIt)
                {
                    switch (item[1])
                    {
                        case "inc":
                            effectRegister.Value += int.Parse(item[2]);
                            break;
                        case "dec":
                            effectRegister.Value -= int.Parse(item[2]);
                            break;
                        default:
                            break;
                    }
                }
                if (registers.Max(x => x.Value) > maxValue)
                {
                    maxValue = registers.Max(x => x.Value);
                }
            }
            Console.WriteLine(registers.Max(x => x.Value));
            Console.WriteLine(maxValue);
            Console.ReadKey();

        }
    }
    
    public class Register
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Register(string name)
        {
            Name = name;
            Value = 0;
        }
    }
}

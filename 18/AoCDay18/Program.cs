using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay18 {
    class Program {
        static void Main(string[] args) {

            Dictionary<string, int> registers = new Dictionary<string, int>();
            List<DuetCommand> commands = new List<DuetCommand>();
            int LastFrequency = 0;
            using (TextReader tr = new StreamReader("input.txt")) {
                while (tr.Peek() > 0) {
                    string line = tr.ReadLine();
                    var parts = line.Split(' ');
                    var cmd = new DuetCommand() {
                        Command = parts[0],
                        Register = parts[1]
                    };
                    if (parts.Length > 2) {
                        try {
                            cmd.Number = int.Parse(parts[2]);
                        }
                        catch (Exception) {

                            cmd.Register2 = parts[2];
                        }
                    }
                    commands.Add(cmd);
                }
            }

            for (int i = 0; (i < commands.Count && i > -1);) {
                var offset = 1;
                if (!registers.ContainsKey(commands[i].Register)) {
                    registers.Add(commands[i].Register, 0);
                }
                switch (commands[i].Command) {
                    case "snd":
                        LastFrequency = registers[commands[i].Register];
                        break;
                    case "set":                     
                        if (commands[i].Register2 != string.Empty && commands[i].Register2 != null) {
                            registers[commands[i].Register] = registers[commands[i].Register2];
                        }
                        else {
                            registers[commands[i].Register] = commands[i].Number;
                        }                                              
                        break;
                    case "add":
                        if (registers.ContainsKey(commands[i].Register)) {
                            if (commands[i].Register2 != string.Empty && commands[i].Register2 != null) {
                                registers[commands[i].Register] += registers[commands[i].Register2];
                            }
                            else {
                                registers[commands[i].Register] += commands[i].Number;
                            }                            
                        }
                        break;
                    case "mul":
                        if (registers.ContainsKey(commands[i].Register)) {
                            if (commands[i].Register2 != string.Empty && commands[i].Register2 != null) {
                                registers[commands[i].Register] *= registers[commands[i].Register2];
                            }
                            else {
                                registers[commands[i].Register] *= commands[i].Number;
                            }
                        }
                        break;
                    case "mod":
                        if (registers.ContainsKey(commands[i].Register)) {
                            if (commands[i].Register2 != string.Empty && commands[i].Register2 != null) {
                                registers[commands[i].Register] %= registers[commands[i].Register2];
                            }
                            else {
                                registers[commands[i].Register] %= commands[i].Number;
                            }
                        }
                        break;
                    case "rcv":
                        if (registers.ContainsKey(commands[i].Register) && registers[commands[i].Register] != 0) {
                            i = commands.Count;
                        }
                        break;
                    case "jgz":
                        if (registers[commands[i].Register] > 0) {
                            if (registers.ContainsKey(commands[i].Register)) {
                                if (commands[i].Register2 != string.Empty && commands[i].Register2 != null) {
                                    offset = registers[commands[i].Register2];
                                }
                                else {
                                    offset = commands[i].Number;
                                }
                            }
                            
                        }
                        break;
                    default:
                        break;
                }
                i += offset;
            }

            Console.WriteLine(LastFrequency);
            Console.ReadKey();
        }

    }

    public class DuetCommand {
        public string Command { get; set; }
        public string Register { get; set; }
        public string Register2 { get; set; }
        public int Number { get; set; }
    }
}

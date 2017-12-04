using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay4
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            int validPasswords = 0;

            using (TextReader tr = new StreamReader(new FileStream("input.txt", FileMode.OpenOrCreate)))
            {
                while (tr.Peek() > 0)
                {
                    input = tr.ReadLine();
                    var passwords = input.Split(' ');
                    var invalid = false;
                    for (int i = 0; i < passwords.Length; i++)
                    {
                        for (int j = 0; j < passwords.Length; j++)
                        {
                            if (j == i) continue;
                            if (passwords[i] == passwords[j])
                            {
                                invalid = true;
                                break;
                            }                            
                        }
                        if (invalid) break;
                    }
                    if (!invalid) validPasswords++;
                }
                Console.WriteLine(validPasswords.ToString());
                Console.ReadKey();
            }
        }
    }
}

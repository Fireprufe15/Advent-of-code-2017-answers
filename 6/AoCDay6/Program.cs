using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay6
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> banks = new List<int>() { 14, 0, 15, 12, 11, 11, 3, 5, 1, 6, 8, 4, 9, 1, 8, 4 };
            List<int> looped = new List<int>();
            List<List<int>> configurations = new List<List<int>>();
            bool going = true;
            bool checkAgain = false;
            var count = 0;
            while (going)
            {
                if (checkAgain)
                {
                    count++;
                }
                var max = banks.Max();
                var loc = banks.IndexOf(max);
                banks[loc] = 0;
                while (max > 0)
                {
                    if (loc < banks.Count - 1) loc++;
                    else loc = 0;
                    banks[loc]++;
                    max--;
                }
                if (checkAgain && banks.SequenceEqual(looped))
                {
                    going = false;
                }
                foreach (var item in configurations)
                {
                    if (!checkAgain && item.SequenceEqual(banks))
                    {
                        looped = new List<int>(banks);
                        checkAgain = true;
                        break;                        
                    }                    
                }
                
                configurations.Add(new List<int>(banks));

            }

           
            Console.WriteLine(count);
            Console.ReadKey();
        }       
    }
}

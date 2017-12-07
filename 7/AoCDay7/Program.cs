using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PBuilding> mainList = new List<PBuilding>();
            var reqChange = 0;
            using (TextReader tr = new StreamReader(new FileStream("input.txt", FileMode.OpenOrCreate)))
            {
                while (tr.Peek() > 0)
                {
                    string line = tr.ReadLine();
                    string name = line.Substring(0, line.IndexOf(' '));
                    line = line.Remove(0, line.IndexOf(' ')+1);

                    string weight = line.Substring(1, line.IndexOf(')')-1);
                    line = line.Remove(0, line.IndexOf(')')+1);
                    if (line.Length == 0)
                    {
                        mainList.Add(new PBuilding() { Name = name, Weight = int.Parse(weight) });
                        continue;
                    }
                    line = line.Remove(0, line.IndexOf('>') + 2);

                    string[] topBuildings = line.Split(new string[] { ", " }, StringSplitOptions.None);
                    var newBuilding = new PBuilding()
                    {
                        Name = name,
                        Weight = int.Parse(weight),
                        StackingPendingList = topBuildings.ToList(),
                    };                    
                    mainList.Add(newBuilding);
                }
                
                while (mainList.Count > 1)
                {
                    var originalList = new List<PBuilding>(mainList);
                    foreach (var item in originalList)
                    {
                        if (item.StackingPendingList.Count == 0) continue;
                        var realListEquiv = mainList.Where(x => x.Name == item.Name).First();
                        foreach (var stacked in new List<string>(item.StackingPendingList))
                        {
                            var realBuilding = mainList.Where(x => x.Name == stacked).First();
                            if (realBuilding.StackingPendingList.Count == 0)
                            {
                                realListEquiv.Stacked.Add(realBuilding);
                                realListEquiv.StackingPendingList.Remove(realBuilding.Name);
                                mainList.Remove(realBuilding);
                            }
                        }
                    }
                }

                bool balancing = false;
                PBuilding unbalancedBuilding = mainList[0];
                while (!balancing)
                {
                    if (unbalancedBuilding.Stacked.Where(x => x.Balanced == false).Count() > 0)
                    {
                        unbalancedBuilding = unbalancedBuilding.Stacked.Where(x => x.Balanced == false).First();
                    }
                    else
                    {
                        unbalancedBuilding.Weight += unbalancedBuilding.BalanceWeight;
                        if (unbalancedBuilding.Balanced)
                        {
                            balancing = true;
                            reqChange = unbalancedBuilding.TotalWeight();
                        }
                        else
                        {
                            unbalancedBuilding.Weight -= unbalancedBuilding.BalanceWeight;
                            balancing = true;
                            reqChange = unbalancedBuilding.TotalWeight();
                        }
                    }
                    
                }
                Console.WriteLine(reqChange);
                Console.WriteLine(mainList[0].Name);
                Console.ReadKey();
            }
        }
    }

    public class PBuilding
    {
        public string Name { get; set; }
        public List<PBuilding> Stacked { get; set; }
        public int Weight { get; set; }
        public List<string> StackingPendingList { get; set; }

        public PBuilding()
        {
            Stacked = new List<PBuilding>();
            StackingPendingList = new List<string>();
        }

        public override string ToString()
        {
            return Balanced.ToString() + " "+TotalWeight();
        }

        public int TotalWeight()
        {
            if (Stacked.Count == 0)
            {
                return Weight;
            }
            var totalWeight = Weight;
            foreach (var item in Stacked)
            {
                totalWeight += item.TotalWeight();
            }
            return totalWeight;
        } 
        
        public bool Balanced
        {
            get {
                if (Stacked.GroupBy(x => x.TotalWeight()).Select(g => g.First()).ToList().Count() == 1)
                {
                    return true;
                }
                return false;
            }            
        }

        public int BalanceWeight
        {
            get { return Stacked.GroupBy(x => x.TotalWeight()).Select(g => g.First()).ToList()[0].TotalWeight() - Stacked.GroupBy(x => x.TotalWeight()).Select(g => g.First()).ToList()[1].TotalWeight(); }
        }
    }
}

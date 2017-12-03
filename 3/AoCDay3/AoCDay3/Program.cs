using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay3 {
    enum direction {
        right = 1,
        up = 2,
        left = 3,
        down = 4
    }
    class Program {
        static void Main(string[] args) {

            int val = int.Parse(Console.ReadLine());



            int x = 0;
            int y = 0;
            direction dir = direction.right;
            int intensity = 1;
            int usedIntensity = 0;
            int currentLoc = 1;

            while (currentLoc != val) {
                if (usedIntensity < intensity) {
                    switch (dir) {
                        case direction.right:
                            x++;                           
                            break;
                        case direction.up:
                            y--;
                            break;
                        case direction.left:
                            x--;
                            break;
                        case direction.down:
                            y++;
                            break;
                        default:
                            break;
                    }
                    currentLoc++;
                    usedIntensity++;
                }
                else {
                    switch (dir) {
                        case direction.right:
                            dir = direction.up;
                            usedIntensity = 0;
                            break;
                        case direction.up:
                            dir = direction.left;
                            usedIntensity = 0;
                            intensity++;
                            break;
                        case direction.left:
                            dir = direction.down;
                            usedIntensity = 0;
                            break;
                        case direction.down:
                            dir = direction.right;
                            usedIntensity = 0;
                            intensity++;
                            break;
                        default:
                            break;
                    }
                }                
            }

            Console.WriteLine(x.ToString()+" "+y.ToString());

            var distance = Math.Abs(x) + Math.Abs(y);

            Console.WriteLine(distance.ToString());

            Console.ReadKey();
        }
    }
}

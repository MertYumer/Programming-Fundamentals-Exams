using System;
using System.Linq;
using System.Collections.Generic;

namespace P02_Snowmen
{
    public class Program
    {
        public static void Main()
        {
            var snowmen = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (snowmen.Count > 1)
            {
                for (int i = 0; i < snowmen.Count; i++)
                {
                    if (snowmen.Count(x => x != -1) == 1)
                    {
                        break;
                    }

                    if (snowmen[i] == -1)
                    {
                        continue;
                    }

                    int attacker = i;
                    int target = snowmen[i];
                    if (target >= snowmen.Count)
                    {
                        target %= snowmen.Count;
                    }

                    int difference = Math.Abs(attacker - target);
                    if (difference % 2 == 0 && difference != 0)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {attacker} wins");
                        snowmen[target] = -1;
                    }

                    else if (difference % 2 == 1)
                    {
                        Console.WriteLine($"{attacker} x {target} -> {target} wins");
                        snowmen[attacker] = -1;
                    }

                    else if (difference == 0)
                    {
                        Console.WriteLine($"{attacker} performed harakiri");
                        snowmen[attacker] = -1;
                    }
                }
                snowmen = snowmen.Where(x => x != -1).ToList();
            }
        }
    }
}

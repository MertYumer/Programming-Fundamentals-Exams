using System;
using System.Linq;
using System.Collections.Generic;

namespace P02_MemoryView
{
    public class Program
    {
        public static void Main()
        {
            string word = string.Empty;
            var allNumbers = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Visual Studio crash")
                {
                    break;
                }

                var currentNumbers = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                allNumbers.AddRange(currentNumbers);
            }

            for (int i = 0; i < allNumbers.Count - 5; i++)
            {
                if (allNumbers[i] == 32656 && allNumbers[i + 1] == 19759 &&
                    allNumbers[i + 2] == 32763 && allNumbers[i + 3] == 0 &&
                    allNumbers[i + 4] > 0 && allNumbers[i + 5] == 0)
                {
                    for (int j = i + 6; j < i + 6 + allNumbers[i + 4]; j++)
                    {
                        if (allNumbers[j] >= 0 && allNumbers[j] <= 127)
                        {
                            word += Convert.ToChar(allNumbers[j]);
                        }
                        
                    }
                    Console.WriteLine(word);
                    word = string.Empty;
                    i = i + 6 + allNumbers[i + 4];
                }
            }
        }
    }
}

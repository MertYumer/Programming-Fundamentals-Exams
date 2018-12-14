using System;
using System.Linq;
using System.Collections.Generic;

namespace P02_GrainsOfSand
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(long.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Mort")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

                int element = int.Parse(command[1]);

                if (command[0] == "Add")
                {
                    numbers.Add(element);
                }

                else if (command[0] == "Remove")
                {
                    if (numbers.Contains(element))
                    {
                        numbers.Remove(element);
                    }

                    else
                    {
                        if (element >= 0 && element < numbers.Count)
                        {
                            numbers.RemoveAt(element);
                        }
                    }
                }

                else if (command[0] == "Replace")
                {
                    long replacement = long.Parse(command[2]);

                    if (numbers.Contains(element))
                    {
                        int index = numbers.IndexOf(element);
                        numbers.Remove(element);
                        numbers.Insert(index, replacement);
                    }
                }

                else if (command[0] == "Increase")
                {
                    long index = 0;
                    bool valueExist = false;

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] >= element)
                        {
                            valueExist = true;
                            numbers = numbers.Select(x => x + numbers[i]).ToList();
                            break;
                        }
                        index = numbers[numbers.Count - 1];
                    }
                    if (!valueExist)
                    {
                        numbers = numbers.Select(x => x + index).ToList();
                    }
                }

                else if (command[0] == "Collapse")
                {
                    numbers.RemoveAll(x => x < element);
                }
            }
        }
    }
}

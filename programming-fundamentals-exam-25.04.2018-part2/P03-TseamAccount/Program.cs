using System;
using System.Linq;

namespace P03_TseamAccount
{
    public class Program
    {
        public static void Main()
        {
            var games = Console.ReadLine()
                .Split()
                .ToList();
            
            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" -".ToCharArray())
                    .ToArray();

                switch (command[0])
                {
                    case "Install":
                        if (!games.Contains(command[1]))
                        {
                            games.Add(command[1]);
                        }
                        break;

                    case "Uninstall":
                        games.Remove(command[1]);
                        break;

                    case "Update":
                        if (games.Contains(command[1]))
                        {
                            games.Remove(command[1]);
                            games.Add(command[1]);
                        }
                        break;

                    case "Expansion":
                        if (games.Contains(command[1]))
                        {
                            int index = games.IndexOf(command[1]);
                            games.Insert(index + 1, $"{command[1]}:{command[2]}");
                        }
                        break;

                    case "Play!":
                        Console.WriteLine(string.Join(" ", games));
                        return;
                }
            }
        }
    }
}

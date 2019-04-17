namespace P04_HornetArmada
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            string pattern = @"(?<activity>\d+) = (?<name>[^=\->: ]+) -> (?<type>[^=\->: ]+):(?<count>\d+)";
            var legions = new List<Legion>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                Match matchedLegion = Regex.Match(input, pattern);

                long activity = long.Parse(matchedLegion.Groups["activity"].Value);
                string name = matchedLegion.Groups["name"].Value;
                string type = matchedLegion.Groups["type"].Value;
                long count = long.Parse(matchedLegion.Groups["count"].Value);

                var legion = new Legion(activity, name);
                legion.SoldierTypeAndCount.Add(type, count);

                int index = legions.FindIndex(l => l.Name == legion.Name);

                if (index == -1)
                {
                    legions.Add(legion);
                }

                else
                {
                    if (!legions[index].SoldierTypeAndCount.ContainsKey(type))
                    {
                        legions[index].SoldierTypeAndCount.Add(type, count);
                    }

                    else
                    {
                        legions[index].SoldierTypeAndCount[type] += count;
                    }

                    if (legions[index].LastActivity < legion.LastActivity)
                    {
                        legions[index].LastActivity = legion.LastActivity;
                    }
                }
            }

            var command = Console.ReadLine().Split('\\');

            if (command.Length == 2)
            {
                long activity = long.Parse(command[0]);
                string type = command[1];

                var result = legions
                    .Where(x => x.SoldierTypeAndCount.ContainsKey(type))
                    .ToList();

                var finalStats = new Dictionary<string, long>();

                foreach (var legion in result)
                {
                    if (legion.LastActivity < activity && legion.SoldierTypeAndCount.ContainsKey(type))
                    {
                        long finalCount = legion.SoldierTypeAndCount.Where(x => x.Key == type).FirstOrDefault().Value;
                        finalStats.Add(legion.Name, finalCount);
                    }
                }

                var printedStats = finalStats.OrderByDescending(x => x.Value);

                foreach (var legion in printedStats)
                {
                    Console.WriteLine($"{legion.Key} -> {legion.Value}");
                }
            }

            else if (command.Length == 1)
            {
                string type = command[0];

                var result = legions
                    .Where(x => x.SoldierTypeAndCount.ContainsKey(type))
                    .ToList();

                var finalStats = new Dictionary<string, long>();

                foreach (var legion in result)
                {
                    if (legion.SoldierTypeAndCount.ContainsKey(type))
                    {
                        long activity = legion.LastActivity;
                        finalStats.Add(legion.Name, activity);
                    }
                }

                var printedStats = finalStats.OrderByDescending(x => x.Value);

                foreach (var legion in printedStats)
                {
                    Console.WriteLine($"{legion.Value} : {legion.Key}");
                }
            }
        }
    }

    public class Legion
    {
        public long LastActivity { get; set; }

        public string Name { get; set; }

        public Dictionary<string, long> SoldierTypeAndCount { get; set; }

        public Legion(long activity, string name)
        {
            LastActivity = activity;
            Name = name;
            SoldierTypeAndCount = new Dictionary<string, long>();
        }
    }
}

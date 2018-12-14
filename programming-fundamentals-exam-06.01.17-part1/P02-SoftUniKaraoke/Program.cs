namespace P02_SoftUniKaraoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var songs = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var stats = new Dictionary<string, List<string>>();

            while (true)
            {
                var performance = Console.ReadLine().Split(", ");

                if (performance[0] == "dawn")
                {
                    if (stats.Count == 0)
                    {
                        Console.WriteLine("No awards");
                        break;
                    }

                    var result = stats
                        .OrderByDescending(p => p.Value.Count)
                        .ThenBy(p => p.Key);

                    foreach (var person in result)
                    {
                        var sortedAwards = person.Value
                            .OrderBy(a => a)
                            .ToList();

                        Console.WriteLine($"{person.Key}: {sortedAwards.Count} awards");

                        foreach (var currentAward in sortedAwards)
                        {
                            Console.WriteLine($"--{currentAward}");
                        }
                    }

                    break;
                }

                string participant = performance[0];
                string song = performance[1];
                string award = performance[2];

                if (participants.Contains(participant) && songs.Contains(song))
                {
                    if (!stats.ContainsKey(participant))
                    {
                        stats.Add(participant, new List<string>());
                        stats[participant].Add(award);
                    }

                    else if (!stats[participant].Contains(award))
                    {
                        stats[participant].Add(award);
                    }
                }
            }
        }
    }
}

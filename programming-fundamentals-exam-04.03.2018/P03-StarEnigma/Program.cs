using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace P05_StarEnigma
{
    public class Program
    {
        public static void Main()
        {
            string regex = @"[^@\-!:>]*?\@(?<planet>[A-Za-z]+)[^@\-!:>]*?\:(?<population>\d+)[^@\-!:>]*?\!(?<attackType>[AD])\![^@\-!:>]*?\-\>(?<soldierCount>\d+)[^@\-!:>]*?";
            int count = int.Parse(Console.ReadLine());
            var planetsStats = new Dictionary<string, List<string>>();
            planetsStats.Add("Attacked planets", new List<string>());
            planetsStats.Add("Destroyed planets", new List<string>());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                char[] message = input.ToCharArray();
                int key = 0;

                foreach (var symbol in message)
                {
                    if (symbol == 's' || symbol == 'S' ||
                        symbol == 't' || symbol == 'T' ||
                        symbol == 'a' || symbol == 'A' ||
                        symbol == 'r' || symbol == 'R')
                    {
                        key++;
                    }
                }

                for (int j = 0; j < message.Length; j++)
                {
                    message[j] = (char)(message[j] - key);
                }

                string decryptedMessage = new string(message);

                Match matchedTarget = Regex.Match(decryptedMessage, regex);

                if (matchedTarget.Groups.Count == 1)
                {
                    continue;
                }

                string planet = matchedTarget.Groups["planet"].Value;
                string attackType = matchedTarget.Groups["attackType"].Value;

                if (attackType == "A")
                {
                    planetsStats["Attacked planets"].Add(planet);
                }

                else
                {
                    planetsStats["Destroyed planets"].Add(planet);
                }
            }

            foreach (var planet in planetsStats)
            {
                Console.WriteLine($"{planet.Key}: {planet.Value.Count}");

                var orderedPlanets = planet.Value.OrderBy(x => x);
                foreach (var target in orderedPlanets)
                {
                    Console.WriteLine($"-> {target}");
                }
            }
        }
    }
}

namespace P03_NetherRealms
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var demons = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string healthPattern = @"([^0-9+\-*\/.])";
            string damagePattern = @"([+-]?\d+(\.\d+)?)";
            string calculationPattern = @"([\/*])";

            var demonStats = new List<Demon>();

            foreach (var demon in demons)
            {
                int health = 0;
                decimal damage = 0.0m;

                MatchCollection matchedSymbols = Regex.Matches(demon, healthPattern);

                foreach (Match match in matchedSymbols)
                {
                    health += Convert.ToChar(match.Value);
                }

                MatchCollection matchedNumbers = Regex.Matches(demon, damagePattern);

                foreach (Match match in matchedNumbers)
                {
                    damage += Convert.ToDecimal(match.Value);
                }

                MatchCollection matchedSigns = Regex.Matches(demon, calculationPattern);

                foreach (Match match in matchedSigns)
                {
                    if (match.Value == "*")
                    {
                        damage *= 2;
                    }

                    else if (match.Value == "/")
                    {
                        damage /= 2;
                    }
                }

                Demon currentDemon = new Demon(demon, health, damage);
                demonStats.Add(currentDemon);
            }

            var result = demonStats.OrderBy(d => d.Name);

            foreach (var demon in result)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }
    }

    public class Demon
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public decimal Damage { get; set; }

        public Demon(string demon, int health, decimal damage)
        {
            Name = demon;
            Health = health;
            Damage = damage;
        }
    }
}

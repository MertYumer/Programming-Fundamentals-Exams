namespace P03_HornetAssault
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var beehives = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var hornets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();


            for (int i = 0; i < beehives.Count; i++)
            {
                if (hornets.Count == 0)
                {
                    break;
                }

                long beehivesCount = beehives[i];
                long hornetPower = hornets.Sum();

                beehives[i] -= hornetPower;

                if (beehivesCount >= hornetPower)
                {
                    hornets.RemoveAt(0);
                }
            }

            for (int i = 0; i < beehives.Count; i++)
            {
                if (beehives[i] <= 0)
                {
                    beehives.RemoveAt(i);
                    i--;
                }
            }

            if (beehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }

            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}

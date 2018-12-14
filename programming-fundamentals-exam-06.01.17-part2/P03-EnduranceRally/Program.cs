namespace P03_EnduranceRally
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split();
            var track = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var checkpoints = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var participant in participants)
            {
                double startingFuel = participant[0];

                for (int i = 0; i < track.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        startingFuel += track[i];
                    }

                    else
                    {
                        startingFuel -= track[i];
                    }

                    if (startingFuel <= 0)
                    {
                        Console.WriteLine($"{participant} - reached {i}");
                        break;
                    }
                }

                if (startingFuel > 0)
                {
                    Console.WriteLine($"{participant} - fuel left {startingFuel:F2}");
                }
            }
        }
    }
}

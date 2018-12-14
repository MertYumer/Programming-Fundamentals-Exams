using System;
using System.Linq;
using System.Collections.Generic;

namespace P01_IronGirder
{
    public class Program
    {
        public static void Main()
        {
            var townsAndTime = new Dictionary<string, List<int>>();
            var passengers = new Dictionary<string, int>();

            while (true)
            {
                var currentTrip = Console.ReadLine()
                    .Split(new string[] {":", "->"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (currentTrip.Length == 1)
                {
                    var result = townsAndTime
                        .OrderBy(x => x.Value.Min())
                        .ThenBy(x => x.Key);

                    foreach (var trip in result)
                    {
                        foreach (var people in passengers)
                        {
                            if (trip.Key == people.Key && trip.Value.Min() != 0
                                && people.Value > 0)
                            {
                                Console.WriteLine($"{trip.Key} -> Time: {trip.Value.Min()} ->" +
                                $" Passengers: {people.Value}");
                            }
                        }
                    }
                    break;
                }

                string currentTown = currentTrip[0];
                int currentPassengers = int.Parse(currentTrip[2]);
                int time;

                if (int.TryParse(currentTrip[1], out time))
                {
                    time = int.Parse(currentTrip[1]);

                    if (!townsAndTime.ContainsKey(currentTown))
                    {
                        townsAndTime[currentTown] = new List<int>();
                        passengers[currentTown] = 0;
                    }
                    townsAndTime[currentTown].Add(time);
                    passengers[currentTown] += currentPassengers;
                }

                else
                {
                    if (townsAndTime.ContainsKey(currentTown))
                    {
                        townsAndTime[currentTown].Select(x => x >= 0 || x < 0);
                        townsAndTime[currentTown].Add(0);
                        passengers[currentTown] -= currentPassengers;
                    }
                }
            }
        }
    }
}

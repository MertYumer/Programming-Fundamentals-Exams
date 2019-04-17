namespace P02_IronGirder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var towns = new List<Town>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Slide rule")
                {
                    var result = towns.OrderBy(x => x.Time).ThenBy(x => x.Name);

                    foreach (var town in result)
                    {
                        if (town.Time > 0 && town.Passengers > 0)
                        {
                            Console.WriteLine($"{town.Name} -> Time: {town.Time} -> Passengers: {town.Passengers}");
                        }
                    }
                    break;
                }

                var trip = input
                .Split(new string[] { ":", "->" }, StringSplitOptions.RemoveEmptyEntries);

                string townName = trip[0];
                int passengers = int.Parse(trip[2]);

                if (trip[1] == "ambush")
                {
                    int index = towns.FindIndex(x => x.Name == townName);

                    if (index != -1)
                    {
                        towns[index].Time = 0;
                        towns[index].Passengers -= passengers;
                    }
                }

                else
                {
                    int currentTime = int.Parse(trip[1]);
                    int index = towns.FindIndex(x => x.Name == townName);
                    var currentTown = new Town(townName, currentTime, passengers);

                    if (index == -1)
                    {
                        towns.Add(currentTown);
                    }

                    else
                    {
                        if (towns[index].Time > currentTown.Time || towns[index].Time == 0)
                        {
                            towns[index].Time = currentTown.Time;
                        }

                        towns[index].Passengers += passengers;
                    }
                }
            }
        }
    }

    public class Town
    {
        public string Name { get; set; }

        public int Time { get; set; }

        public int Passengers { get; set; }

        public Town(string townName, int currentTime, int passengers)
        {
            Name = townName;
            Time = currentTime;
            Passengers = passengers;
        }
    }
}

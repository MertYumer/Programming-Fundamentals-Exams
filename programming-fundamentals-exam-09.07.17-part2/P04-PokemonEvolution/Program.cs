
namespace P04_PokemonEvolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var pokemons = new Dictionary<string, List<Evolution>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "wubbalubbadubdub")
                {
                    foreach (var pokemon in pokemons)
                    {
                        Console.WriteLine($"# {pokemon.Key}");

                        var result = pokemon.Value
                            .OrderByDescending(e => e.Index);

                        foreach (var pair in result)
                        {
                            Console.WriteLine($"{pair.Type} <-> {pair.Index}");
                        }
                    }

                    break;
                }

                string name = input[0];

                if (input.Length > 1)
                {
                    string type = input[1];
                    long index = long.Parse(input[2]);
                    var evolution = new Evolution(type, index);

                    if (!pokemons.ContainsKey(name))
                    {
                        pokemons[name] = new List<Evolution>();
                    }

                    pokemons[name].Add(evolution);
                }

                else if (input.Length == 1 && pokemons.ContainsKey(name))
                {
                    Console.WriteLine($"# {name}");

                    foreach (var pair in pokemons[name])
                    {
                        Console.WriteLine($"{pair.Type} <-> {pair.Index}");
                    }
                }
            }
        }
    }

    public class Evolution
    {
        public string Type { get; set; }

        public long Index { get; set; }

        public Evolution(string type, long index)
        {
            Type = type;
            Index = index;
        }
    }
}

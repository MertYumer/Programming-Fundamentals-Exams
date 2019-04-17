using System;
using System.Linq;
using System.Collections.Generic;

namespace P04_MOBAChallenger
{
    public class Program
    {
        public static void Main()
        {
            var playersAndPositions = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var command = Console.ReadLine()
                    .Split(" -> ")
                    .ToArray();

                if (command[0] == "Season end")
                {
                    

                    PrintStandings(playersAndPositions);
                    
                    break;
                }

                if (command.Length > 1)
                {
                    string currentPlayer = command[0];
                    string currentPosition = command[1];
                    int currentSkills = int.Parse(command[2]);

                    if (!playersAndPositions.ContainsKey(currentPlayer))
                    {
                        playersAndPositions[currentPlayer] = new Dictionary<string, int>();
                    }

                    if (playersAndPositions[currentPlayer].ContainsKey(currentPosition))
                    {
                        foreach (var position in playersAndPositions[currentPlayer])
                        {
                            if (position.Value < currentSkills)
                            {
                                playersAndPositions[currentPlayer].Remove(currentPosition);
                                playersAndPositions[currentPlayer].Add(currentPosition, currentSkills);
                                break;
                            }
                        }
                    }

                    else
                    {
                        playersAndPositions[currentPlayer].Add(currentPosition, currentSkills);
                    }
                }

                else
                {
                    var duel = command[0].Split().ToArray();
                    string firstPlayer = duel[0];
                    string secondPlayer = duel[2];

                    var firstDictionary = new Dictionary<string, int>();
                    var secondDictionary = new Dictionary<string, int>();

                    if (playersAndPositions.ContainsKey(firstPlayer))
                    {
                        firstDictionary = playersAndPositions[firstPlayer];
                    }

                    if (playersAndPositions.ContainsKey(secondPlayer))
                    {
                        secondDictionary = playersAndPositions[secondPlayer];
                    }

                    if (firstDictionary == new Dictionary<string, int>() ||
                        secondDictionary == new Dictionary<string, int>())
                    {
                        continue;
                    }

                    var pair = SearchMatches(firstDictionary, secondDictionary);
                    string firstPosition = pair.Item1;
                    string secondPosition = pair.Item2;
                    if (firstPosition != "" && secondPosition != "")
                    {
                        int firstValue = 0;
                        int secondValue = 0;

                        foreach (var position in playersAndPositions[firstPlayer])
                        {
                            if (position.Key == firstPosition)
                            {
                                firstValue = position.Value;
                            }
                        }

                        foreach (var position in playersAndPositions[secondPlayer])
                        {
                            if (position.Key == secondPosition)
                            {
                                secondValue = position.Value;
                            }
                        }

                        if (firstValue > secondValue)
                        {
                            playersAndPositions.Remove(secondPlayer);
                        }

                        else if (firstValue < secondValue)
                        {
                            playersAndPositions.Remove(firstPlayer);
                        }
                    }
                }
            }
        }

        public static Tuple<string, string> SearchMatches(Dictionary<string, int> firstDictionary,
            Dictionary<string, int> secondDictionary)
        {
            var result = new Tuple<string, string>("", "");
            foreach (var firstPosition in firstDictionary)
            {
                foreach (var secondPosition in secondDictionary)
                {
                    if (firstPosition.Key == secondPosition.Key)
                    {
                        result = new Tuple<string, string>(firstPosition.Key, secondPosition.Key);
                        return result;
                    }
                }
            }
            return result;
        }

        public static void PrintStandings(Dictionary<string,
            Dictionary<string, int>> playersAndPositions)
        {
            var result = playersAndPositions
                        .OrderByDescending(x => x.Value.Values.Sum())
                        .ThenBy(x => x.Key);

            foreach (var player in result)
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                var positionsAndSkills = playersAndPositions[player.Key]
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key);

                foreach (var position in positionsAndSkills)
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}

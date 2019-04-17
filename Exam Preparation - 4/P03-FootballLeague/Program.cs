
namespace P03_FootballLeague
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string key = Console.ReadLine();
            key = Regex.Escape(key);
            string teamsPattern = $@"{key}(?<teamOne>.*?){key}.+?{key}(?<teamTwo>.*?){key}.+?(?<teamOneGoals>\d+):(?<teamTwoGoals>\d+)";
            var teams = new List<Team>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "final")
                {
                    var result = teams
                        .OrderByDescending(t => t.Points)
                        .ThenBy(t => t.Name)
                        .ToList();

                    Console.WriteLine("League standings:");

                    for (int i = 0; i < result.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {result[i].Name} {result[i].Points}");
                    }

                    result = teams
                        .OrderByDescending(t => t.Goals)
                        .ThenBy(t => t.Name)
                        .Take(3)
                        .ToList();

                    Console.WriteLine("Top 3 scored goals:");
                    foreach (var competitor in result)
                    {
                        Console.WriteLine($"- {competitor.Name} -> {competitor.Goals}");
                    }

                    break;
                }

                MatchCollection matchedTeams = Regex.Matches(input, teamsPattern);

                foreach (Match match in matchedTeams)
                {

                    var firstTeam = new string(match.Groups["teamOne"].Value.Reverse().ToArray()).ToUpper();
                    var secondTeam = new string(match.Groups["teamTwo"].Value.Reverse().ToArray()).ToUpper();
                    var firstTeamGoals = int.Parse(match.Groups["teamOneGoals"].Value);
                    var secondTeamGoals = int.Parse(match.Groups["teamTwoGoals"].Value);
                    Team teamOne = new Team();
                    teamOne.Name = firstTeam;
                    teamOne.Goals = 0;
                    teamOne.Points = 0;

                    int index = teams.FindIndex(t => t.Name == teamOne.Name);
                    if (index == -1)
                    {
                        teams.Add(teamOne);
                    }

                    index = teams.FindIndex(t => t.Name == teamOne.Name);
                    teams[index].Goals += firstTeamGoals;

                    if (firstTeamGoals > secondTeamGoals)
                    {
                        teams[index].Points += 3;
                    }

                    else if (firstTeamGoals == secondTeamGoals)
                    {
                        teams[index].Points += 1;
                    }

                    Team teamTwo = new Team();
                    teamTwo.Name = secondTeam;
                    teamTwo.Goals = 0;
                    teamTwo.Points = 0;

                    index = teams.FindIndex(t => t.Name == teamTwo.Name);
                    if (index == -1)
                    {
                        teams.Add(teamTwo);
                    }

                    index = teams.FindIndex(t => t.Name == teamTwo.Name);
                    teams[index].Goals += secondTeamGoals;

                    if (firstTeamGoals < secondTeamGoals)
                    {
                        teams[index].Points += 3;
                    }

                    else if (firstTeamGoals == secondTeamGoals)
                    {
                        teams[index].Points += 1;
                    }
                }
            }
        }

        public class Team
        {
            public string Name { get; set; }

            public int Points { get; set; }

            public int Goals { get; set; }
        }
    }
}

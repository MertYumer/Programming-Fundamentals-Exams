namespace P04_Roli_TheCoder
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var events = new List<Event>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Time for Code")
                {
                    var result = events
                        .OrderByDescending(e => e.Participants.Count)
                        .ThenBy(e => e.Name);

                    foreach (var party in result)
                    {
                        var sortedParticipants = party.Participants.OrderBy(p => p).ToList();
                        Console.WriteLine($"{party.Name} - {sortedParticipants.Count}");

                        foreach (var person in sortedParticipants)
                        {
                            Console.WriteLine($"{person}");
                        }
                    }

                    break;
                }

                var input = command
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(input[0]);
                string name = input[1];

                if (name[0] != '#')
                {
                    continue;
                }

                string finalName = name.Substring(1);
                name = finalName;

                var currentEvent = new Event(id, name);

                int index = events.FindIndex(e => e.Id == currentEvent.Id);

                string pattern = @"@[A-Za-z\d'-]+";
                MatchCollection matchedPeople = Regex.Matches(command, pattern);

                if (index > -1)
                {
                    if (events[index].Name == currentEvent.Name)
                    {
                        foreach (Match match in matchedPeople)
                        {
                            if (!events[index].Participants.Contains(match.Value))
                            {
                                events[index].Participants.Add(match.Value);
                            }
                        }
                    }
                }

                else
                {
                    events.Add(currentEvent);
                    foreach (Match match in matchedPeople)
                    {
                        if (!events[events.Count - 1].Participants.Contains(match.Value))
                        {
                            events[events.Count - 1].Participants.Add(match.Value);
                        }
                    }
                }
            }
        }
    }

    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Participants { get; set; }

        public Event(int id, string name)
        {
            Id = id;
            Name = name;
            Participants = new List<string>();
        }
    }
}

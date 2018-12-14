namespace P04_WinningTicket
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string pattern = @"[@]{6,}|[#]{6,}|[$]{6,}|[\^]{6,}";

            var tickets = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    string firstPart = ticket.Substring(0, ticket.Length / 2);
                    Match firstHalf = Regex.Match(firstPart, pattern);

                    string secondPart = ticket.Substring(ticket.Length / 2);
                    Match secondHalf = Regex.Match(secondPart, pattern);

                    if (firstHalf.Success && secondHalf.Success)
                    {
                        if (firstHalf.Value[0] == secondHalf.Value[0])
                        {
                            if (firstHalf.Length == secondHalf.Length && firstHalf.Length == 10)
                            {
                                Console.WriteLine($"ticket \"{ticket}\" - 10{firstHalf.Value[0]} Jackpot!");
                                continue;
                            }

                            else
                            {
                                int length = Math.Min(firstHalf.Length, secondHalf.Length);
                                Console.WriteLine($"ticket \"{ticket}\" - {length}{firstHalf.Value[0]}");
                                continue;
                            }
                        }
                    }

                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }

                else
                {
                    Console.WriteLine("invalid ticket");
                }
            }
        }
    }
}

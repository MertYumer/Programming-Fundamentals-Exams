using System;
using System.Text.RegularExpressions;

namespace P01_ChoreWars
{
    public class Program
    {
        public static void Main()
        {
            string pattern = @"<([a-z0-9]+)>|\[([A-Z0-9]+)\]|{([\w\d\s\W\D\S]+)}";
            Match matchedChore;
            MatchCollection matchedNumbers;
            int totalMinutes = 0;
            int timeForDishes = 0;
            int timeForCleaning = 0;
            int timeForLaundry = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "wife is happy")
                {
                    Console.WriteLine($"Doing the dishes - {timeForDishes} min.");
                    Console.WriteLine($"Cleaning the house - {timeForCleaning} min.");
                    Console.WriteLine($"Doing the laundry - {timeForLaundry} min.");
                    Console.WriteLine($"Total - {totalMinutes} min.");
                    break;
                }

                matchedChore = Regex.Match(command, pattern);

                if (matchedChore.Groups.Count == 1)
                {
                    continue;
                }

                else if (matchedChore.Groups[1].Value != string.Empty)
                {
                    string encryptedMessage = matchedChore.Groups[1].Value;
                    matchedNumbers = Regex.Matches(encryptedMessage, @"\d");

                    foreach (var number in matchedNumbers)
                    {
                        timeForDishes += int.Parse(string.Format($"{number}"));
                        totalMinutes += int.Parse(string.Format($"{number}"));
                    }
                }

                else if (matchedChore.Groups[2].Value != string.Empty)
                {
                    string encryptedMessage = matchedChore.Groups[2].Value;
                    matchedNumbers = Regex.Matches(encryptedMessage, @"\d");

                    foreach (var number in matchedNumbers)
                    {
                        timeForCleaning += int.Parse(string.Format($"{number}"));
                        totalMinutes += int.Parse(string.Format($"{number}"));
                    }
                }

                else if (matchedChore.Groups[3].Value != string.Empty)
                {
                    string encryptedMessage = matchedChore.Groups[3].Value;
                    matchedNumbers = Regex.Matches(encryptedMessage, @"\d");

                    foreach (var number in matchedNumbers)
                    {
                        timeForLaundry += int.Parse(string.Format($"{number}"));
                        totalMinutes += int.Parse(string.Format($"{number}"));
                    }
                }
            }
        }
    }
}

namespace P03_Regexmon
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string bojoPattern = @"([A-Za-z]+-[A-Za-z]+)";
            string didiPattern = @"([^A-Za-z-]+)";
            string currentPattern = string.Empty;
            int counter = 0;

            string input = Console.ReadLine();

            while (true)
            {
                counter++;

                if (counter % 2 == 1)
                {
                    currentPattern = didiPattern;
                }

                else
                {
                    currentPattern = bojoPattern;
                }

                Match match = Regex.Match(input, currentPattern);

                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                    int index = input.IndexOf(match.Value);
                    string editedInput = input.Substring(index);
                    input = editedInput;
                }

                else
                {
                    return;
                }
            }
        }
    }
}

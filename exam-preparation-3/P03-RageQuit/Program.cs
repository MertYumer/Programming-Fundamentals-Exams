namespace P03_RageQuit
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            StringBuilder result = new StringBuilder();
            var uniqueSymbols = new List<char>();

            string input = Console.ReadLine();

            string lettersPattern = @"[^\d]+";
            string countPattern = @"[\d]+";

            MatchCollection matchedStrings = Regex.Matches(input, lettersPattern);
            MatchCollection matchedCounts = Regex.Matches(input, countPattern);
            
            for(int i = 0; i < matchedStrings.Count; i++)
            {
                string text = matchedStrings[i].Value.ToUpper();
                int count = int.Parse(matchedCounts[i].Value);

                for (int j = 0; j < count; j++)
                {
                    result.Append(text);
                }

                if (count > 0)
                {
                    foreach (var character in text)
                    {
                        if (!uniqueSymbols.Contains(character))
                        {
                            uniqueSymbols.Add(character);
                        }
                    }
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(result);
        }
    }
}

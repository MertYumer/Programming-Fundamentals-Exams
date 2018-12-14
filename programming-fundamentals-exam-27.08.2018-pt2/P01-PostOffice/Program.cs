using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_PostOffice
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split("|");

            string firstPart = input[0];
            string secondPart = input[1];
            var thirdPart = input[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstPattern = @"([\$\#\*\%\&])([A-Z]+)(\1)";
            string secondPattern = @"([0-9]{2}):([0-9]{2})";

            Match matchedLetters = Regex.Match(firstPart, firstPattern);
            string symbols = matchedLetters.Groups[2].Value.ToString();
            char[] result = symbols.ToCharArray();

            MatchCollection matchedLengths = Regex.Matches(secondPart, secondPattern);

            var pairs = new Dictionary<char, int>();

            foreach (var letter in result)
            {
                foreach (Match match in matchedLengths)
                {
                    int letterCode = int.Parse(match.Groups[1].Value);
                    int wordLength = int.Parse(match.Groups[2].Value);
                    if (letterCode == letter && !pairs.ContainsKey((char)letter) &&
                        wordLength >= 1 && wordLength <= 20)
                    {
                        pairs.Add(letter, wordLength);
                    }
                }
            }

            foreach (var pair in pairs)
            {
                foreach (var word in thirdPart)
                {
                    if (word[0] == pair.Key && word.Length == pair.Value + 1)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}

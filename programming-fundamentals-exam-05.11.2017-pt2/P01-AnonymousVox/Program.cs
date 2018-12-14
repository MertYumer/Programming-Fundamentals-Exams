namespace P01_AnonymousVox
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string pattern = @"([A-Za-z]+)([\w\d\s\W\D\S]+)\1";

            string input = Console.ReadLine();
            MatchCollection matchedPlaceholders = Regex.Matches(input, pattern);
            var placeholders = new List<string>();

            foreach (Match placeholder in matchedPlaceholders)
            {
                placeholders.Add(placeholder.Groups[2].Value);
            }

            var values = Console.ReadLine()
                .Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            int length = Math.Min(placeholders.Count, values.Length);
            string replacedInput = input;

            for (int i = 0; i < length; i++)
            {
                var regex = new Regex(Regex.Escape(placeholders[i]));
                replacedInput = regex.Replace(input, values[i], 1);
                input = replacedInput;
            }

            Console.WriteLine(input);
        }
    }
}

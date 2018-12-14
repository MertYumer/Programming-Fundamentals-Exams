namespace P03_Snowflake
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            bool validSnowflake = true;
            string surfacePattern = @"([^A-Za-z\d]+)$";
            string mantlePattern = @"([_\d]+)$";
            string midPattern = @"([^A-Za-z\d]+)([_\d]+)([A-Za-z]+)([_\d]+)([^A-Za-z\d]+)$";
            int coreLength = 0;
            Match matchedElement;

            for (int i = 1; i <= 5; i++)
            {
                string input = Console.ReadLine();

                if (i == 1 || i == 5)
                {
                    matchedElement = Regex.Match(input, surfacePattern);
                }

                else if (i == 2 || i == 4)
                {
                    matchedElement = Regex.Match(input, mantlePattern);
                }

                else
                {
                    matchedElement = Regex.Match(input, midPattern);
                    coreLength = matchedElement.Groups[3].Length;
                }

                if (matchedElement.Groups.Count == 1)
                {
                    validSnowflake = false;
                }
            }

            if (validSnowflake)
            {
                Console.WriteLine("Valid");
                Console.WriteLine(coreLength);
            }

            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}

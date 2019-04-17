namespace P04_CubicMessages
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string pattern = @"^(\d+)([A-Za-z]+)([^A-Za-z]+)*$";

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Over!")
                {
                    break;
                }

                int messageLength = int.Parse(Console.ReadLine());

                Match matchedMessage = Regex.Match(input, pattern);

                if (matchedMessage.Success && matchedMessage.Groups[2].Length == messageLength)
                {
                    string message = matchedMessage.Groups[2].Value;
                    StringBuilder verificationCode = new StringBuilder();

                    string indexes = matchedMessage.Groups[1].Value + matchedMessage.Groups[3].Value;

                    for (int i = 0; i < indexes.Length; i++)
                    {
                        int index = (int)char.GetNumericValue(indexes[i]);

                        if (index != -1)
                        {
                            if (index >= 0 && index < message.Length)
                            {
                                verificationCode.Append(message[index]);
                            }

                            else
                            {
                                verificationCode.Append(" ");
                            }
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");
                }
            }
        }
    }
}

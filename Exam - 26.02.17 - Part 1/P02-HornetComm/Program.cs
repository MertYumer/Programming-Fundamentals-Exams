namespace P02_HornetComm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            string messagePattern = @"^(?<code>\d+) <-> (?<message>[0-9A-Za-z]+|[A-Za-z]+)$";
            string broadcastPattern = @"^(?<message>[^\d]+) <-> (?<frequency>[0-9A-Za-z]+|[A-Za-z]+)$";

            var messages = new List<Message>();
            var broadcasts = new List<Broadcast>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Hornet is Green")
                {
                    Console.WriteLine("Broadcasts:");
                    foreach (var broadcast in broadcasts)
                    {
                        Console.WriteLine($"{broadcast.Frequency} -> {broadcast.FirstMessage}");
                    }

                    if (broadcasts.Count == 0)
                    {
                        Console.WriteLine("None");
                    }

                    Console.WriteLine("Messages:");
                    
                    foreach (var message in messages)
                    {
                        Console.WriteLine($"{message.Code} -> {message.SecondMessage}");
                    }

                    if (messages.Count == 0)
                    {
                        Console.WriteLine("None");
                    }

                    break;
                }

                Match matchedMessage = Regex.Match(input, messagePattern);
                Match matchedBroadcast = Regex.Match(input, broadcastPattern);

                if (matchedMessage.Groups.Count == 3)
                {
                    char[] firstInput = matchedMessage.Groups["code"].Value.ToCharArray();
                    Array.Reverse(firstInput);

                    string code = new string(firstInput);
                    string message = matchedMessage.Groups["message"].Value;

                    var currentMessage = new Message(code, message);
                    messages.Add(currentMessage);
                }

                else if (matchedBroadcast.Groups.Count == 3)
                {
                    string message = matchedBroadcast.Groups["message"].Value;

                    char[] secondInput = matchedBroadcast.Groups["frequency"].Value.ToCharArray();

                    for (int i = 0; i < secondInput.Length; i++)
                    {
                        if (char.IsLower(secondInput[i]))
                        {
                            secondInput[i] = Convert.ToChar(secondInput[i].ToString().ToUpper());
                        }

                        else if (char.IsUpper(secondInput[i]))
                        {
                            secondInput[i] = Convert.ToChar(secondInput[i].ToString().ToLower());
                        }
                    }

                    string frequency = new string(secondInput);
                    var currentMessage = new Broadcast(frequency, message);
                    broadcasts.Add(currentMessage);
                }
            }
        }
    }

    public class Broadcast
    {
        public string Frequency { get; set; }

        public string FirstMessage { get; set; }

        public Broadcast(string frequency, string message)
        {
            Frequency = frequency;
            FirstMessage = message;
        }
    }

    public class Message
    {
        public string Code { get; set; }

        public string SecondMessage { get; set; }

        public Message(string code, string message)
        {
            Code = code;
            SecondMessage = message;
        }
    }
}

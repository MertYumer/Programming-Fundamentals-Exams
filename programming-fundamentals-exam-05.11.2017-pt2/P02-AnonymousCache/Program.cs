namespace P02_AnonymousCache
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var dataSets = new Dictionary<string, Dictionary<string, long>>();
            var dataCaches = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { '-', '>', '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "thetinggoesskrra")
                {
                    if (dataSets.Count > 0)
                    {
                        var result = dataSets.OrderByDescending(x => x.Value.Values.Sum()).First();
                        Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Values.Sum()}");

                        foreach (var data in result.Value)
                        {
                            Console.WriteLine($"$.{data.Key}");
                        }
                    }

                    break;
                }

                if (input.Length == 1)
                {
                    string currentName = input[0];

                    if (!dataSets.ContainsKey(currentName))
                    {
                        dataSets.Add(currentName, new Dictionary<string, long>());

                        if (dataCaches.ContainsKey(currentName))
                        {
                            dataSets[currentName] = new Dictionary<string, long>(dataCaches[currentName]);
                            dataCaches.Remove(currentName);
                        }
                    }
                }

                else
                {
                    string currentKey = input[0];
                    long currentSize = long.Parse(input[1]);
                    string currentName = input[2];

                    if (!dataSets.ContainsKey(currentName))
                    {
                        if (!dataCaches.ContainsKey(currentName))
                        {
                            dataCaches.Add(currentName, new Dictionary<string, long>());
                        }
                        dataCaches[currentName].Add(currentKey, currentSize);
                    }

                    else
                    {
                        dataSets[currentName].Add(currentKey, currentSize);
                    }
                }
            }
        }
    }
}

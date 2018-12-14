using System;
using System.Text.RegularExpressions;

namespace P04_SoftUniBarIncome
{
    public class Program
    {
        public static void Main()
        {
            string regex = @"\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*?\<(?<product>\w+)\>[^|$%.]*?\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";
            decimal totalIncome = 0.0m;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of shift")
                {
                    Console.WriteLine($"Total income: {totalIncome:F2}");
                    break;
                }

                Match matchedPurchase = Regex.Match(input, regex);

                if (matchedPurchase.Groups.Count == 1)
                {
                    continue;
                }

                string customer = matchedPurchase.Groups["customer"].Value;
                string product = matchedPurchase.Groups["product"].Value;
                int quantity = int.Parse(matchedPurchase.Groups["quantity"].Value);
                decimal price = decimal.Parse(matchedPurchase.Groups["price"].Value);

                Console.WriteLine($"{customer}: {product} - {(quantity * price):F2}");
                totalIncome += (quantity * price);
            }
        }
    }
}


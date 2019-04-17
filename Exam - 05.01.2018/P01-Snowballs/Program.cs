using System;
using System.Numerics;

namespace P01_Snowballs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            BigInteger bestValue = 0;
            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;

            for (int i = 0; i < snowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentValue = BigInteger.Pow((snowballSnow / snowballTime),
                    snowballQuality);
                if (currentValue > bestValue)
                {
                    bestValue = currentValue;
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestSnowballQuality = snowballQuality;
                }
            }
            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} =" +
                $" {bestValue} ({bestSnowballQuality})");
        }
    }
}

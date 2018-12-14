using System;
using System.Linq;
using System.Collections.Generic;

namespace P02_KaminoFactory
{
    public class Program
    {
        public static void Main()
        {
            int dnaLength = int.Parse(Console.ReadLine());

            var bestSample = new List<int>();
            int longestSequence = 1;
            int leftmostIndex = int.MaxValue;
            int biggestSum = 0;
            int sampleIndex = -1;
            int currentIndex = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    Console.WriteLine($"Best DNA sample {sampleIndex} with sum: {biggestSum}.");
                    Console.WriteLine(string.Join(" ", bestSample));
                    break;
                }

                var dna = input
                    .Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                currentIndex++;

                int currentSequence = 1;
                int bestSequence = 1;
                int startIndex = -1;
                int currentSum = 0;

                for (int i = 0; i < dna.Count; i++)
                {
                    if (i < dna.Count - 1 && 
                        dna[i] == 1 && 
                        dna[i] == dna[i + 1])
                    {
                        currentSequence++;
                        startIndex = i;
                    }

                    else if (currentSequence > bestSequence)
                    {
                        bestSequence = currentSequence;
                        currentSequence = 1;
                    }
                    currentSum += dna[i];
                }

                if (bestSequence > longestSequence)
                {
                    bestSample = dna;
                    longestSequence = bestSequence;
                    leftmostIndex = startIndex;
                    biggestSum = bestSample.Sum();
                    sampleIndex = currentIndex;
                }

                else if (bestSequence == longestSequence &&
                    startIndex < leftmostIndex)
                {
                    bestSample = dna;
                    longestSequence = bestSequence;
                    leftmostIndex = startIndex;
                    biggestSum = bestSample.Sum();
                    sampleIndex = currentIndex;
                }

                else if (startIndex == leftmostIndex &&
                    currentSum > biggestSum)
                {
                    bestSample = dna;
                    longestSequence = bestSequence;
                    leftmostIndex = startIndex;
                    biggestSum = bestSample.Sum();
                    sampleIndex = currentIndex;
                }
            }
        }
    }
}

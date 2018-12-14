using System;

namespace P01_Hogswatch
{
    public class Program
    {
        public static void Main()
        {
            int homesToVisit = int.Parse(Console.ReadLine());
            int initialPresents = int.Parse(Console.ReadLine());

            int visitedHomes = 0;
            int remainingHomes = 0;
            int remainingPresents = initialPresents;
            int timesBack = 0;
            int additionalPresents = 0;

            for (int i = 1; i <= homesToVisit; i++)
            {
                int presents = int.Parse(Console.ReadLine());
                visitedHomes++;
                remainingHomes = homesToVisit - visitedHomes;

                if (presents > remainingPresents)
                {
                    timesBack++;
                    additionalPresents += ((initialPresents / visitedHomes)
                        * remainingHomes + (presents - remainingPresents));

                    remainingPresents += ((initialPresents / visitedHomes)
                        * remainingHomes + (presents - remainingPresents));
                }

                remainingPresents -= presents;
            }

            if (timesBack > 0)
            {
                Console.WriteLine(timesBack);
                Console.WriteLine(additionalPresents);
            }

            else
            {
                Console.WriteLine(remainingPresents);
            }
        }
    }
}

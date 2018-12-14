using System;

namespace P01_SoftUniReception
{
    public class Program
    {
        public static void Main()
        {
            int firstEmployer = int.Parse(Console.ReadLine());
            int secondEmployer = int.Parse(Console.ReadLine());
            int thirdEmployer = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());

            int studentsPerHour = firstEmployer + secondEmployer + thirdEmployer;
            int hours = 0;
            int answeredStudents = 0;
            while (answeredStudents < students)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }
                answeredStudents += studentsPerHour;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}

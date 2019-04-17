using System;

namespace P01_PadawanEquipment
{
    public class Program
    {
        public static void Main()
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal lightsaberPrice = decimal.Parse(Console.ReadLine());
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());
            decimal totalPrice = 0.0m;

            totalPrice += (lightsaberPrice * (students + Math.Ceiling(students * 0.1m)));
            totalPrice += (robePrice * students);
            totalPrice += (beltPrice * (students - (students / 6)));

            if (totalPrice <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:F2}lv.");
            }

            else
            {
                Console.WriteLine($"Ivan Cho will need {(totalPrice - budget):F2}lv more.");
            }
        }
    }
}

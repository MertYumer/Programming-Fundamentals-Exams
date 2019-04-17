using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_SoftUniCoursePlanning
{
    public class Program
    {
        public static void Main()
        {
            var courses = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "course start")
                {
                    for (int i = 0; i < courses.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{courses[i]}");
                    }
                    break;
                }

                var command = input.Split(":").ToArray();
                string lesson = command[1];
                switch (command[0])
                {
                    case "Add":
                        if (!courses.Contains(lesson))
                        {
                            courses.Add(lesson);
                        }
                        break;

                    case "Insert":
                        int index = int.Parse(command[2]);
                        courses = InsertLesson(courses, index, lesson);
                        break;

                    case "Remove":
                        courses.RemoveAll(course => course == lesson || course == $"{lesson}-Exercise");
                        break;

                    case "Swap":
                        string secondLesson = command[2];
                        courses = SwapLessons(courses, lesson, secondLesson);
                        break;

                    case "Exercise":
                        courses = AddExercise(courses, lesson);
                        break;
                }
            }
        }

        public static List<string> InsertLesson(List<string> courses, int index, string lesson)
        {
            if (index >= 0 && index < courses.Count && !courses.Contains(lesson))
            {
                courses.Insert(index, lesson);
            }
            return courses;
        }

        public static List<string> SwapLessons(List<string> courses, string lesson, string secondLesson)
        {
            int firstIndex = courses.IndexOf(lesson);
            int secondIndex = courses.IndexOf(secondLesson);

            if (courses.Contains(lesson) && courses.Contains(secondLesson))
            {
                courses[firstIndex] = secondLesson;
                courses[secondIndex] = lesson;

                if (courses.Contains($"{lesson}-Exercise") && firstIndex + 1 < courses.Count)
                {
                    courses.RemoveAt(firstIndex + 1);
                    firstIndex = courses.IndexOf(lesson);
                    courses.Insert(firstIndex + 1, $"{lesson}-Exercise");
                }

                if (courses.Contains($"{secondLesson}-Exercise") && secondIndex + 1 < courses.Count)
                {
                    courses.RemoveAt(secondIndex + 1);
                    secondIndex = courses.IndexOf(secondLesson);
                    courses.Insert(secondIndex + 1, $"{secondLesson}-Exercise");
                }
            }
            return courses;
        }

        public static List<string> AddExercise(List<string> courses, string lesson)
        {
            int index = courses.IndexOf(lesson);
            if (courses.Contains(lesson) && !courses.Contains($"{lesson}-Exercise"))
            {
                courses.Insert(index + 1, $"{lesson}-Exercise");
            }

            else if (!courses.Contains(lesson))
            {
                courses.Add(lesson);
                courses.Add($"{lesson}-Exercise");
            }
            return courses;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;


namespace P02_SoftUniExamResults
{
    public class Program
    {
        public static void Main()
        {
            var users = new Dictionary<string, int>();
            var languages = new Dictionary<string, int>();

            while (true)
            {
                var submission = Console.ReadLine().Split("-");

                if (submission.Length == 1)
                {
                    PrintUsersResults(users);

                    PrintLanguagesStats(languages);

                    break;
                }

                string currentUser = submission[0];

                if (submission.Length == 2)
                {
                    users.Remove(currentUser);
                }

                else
                {
                    string currentLanguage = submission[1];
                    int currentPoints = int.Parse(submission[2]);

                    UsersResults(users, currentUser, currentPoints);

                    LanguagesStats(languages, currentLanguage);
                }
            }
        }

        public static void UsersResults(Dictionary<string, int> users,
            string currentUser, int currentPoints)
        {
            if (!users.ContainsKey(currentUser))
            {
                users[currentUser] = currentPoints;
            }

            else if (currentPoints > users[currentUser])
            {
                users[currentUser] = currentPoints;
            }
        }

        public static void LanguagesStats(Dictionary<string, int> languages,
            string currentLanguage)
        {
            if (!languages.ContainsKey(currentLanguage))
            {
                languages[currentLanguage] = 0;
            }

            languages[currentLanguage]++;
        }

        public static void PrintUsersResults(Dictionary<string, int> users)
        {
            var pointsResult = users
                        .OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key);

            Console.WriteLine("Results:");

            foreach (var user in pointsResult)
            {
                Console.WriteLine(user.Key + " | " + user.Value);
            }
        }

        public static void PrintLanguagesStats(Dictionary<string, int> languages)
        {
            var submissions = languages
                        .OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key);

            Console.WriteLine("Submissions:");

            foreach (var language in submissions)
            {
                Console.WriteLine(language.Key + " - " + language.Value);
            }
        }
    }
}


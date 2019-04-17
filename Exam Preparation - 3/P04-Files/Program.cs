namespace P04_Files
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var files = new List<File>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('\\');
                var fileData = input.Last().Split(';');
                File file = new File
                {
                    Location = input[0],
                    FileName = fileData[0],
                    FileSize = long.Parse(fileData.Last())
                };

                files.Add(file);
            }

            var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string wantedExtension = command[0];
            string wantedLocation = command[2];

            var wantedFiles = new Dictionary<string, long>();

            foreach (var file in files)
            {
                if (file.Location == wantedLocation && file.FileName.EndsWith(wantedExtension))
                {
                    wantedFiles[file.FileName] = file.FileSize;
                }
            }

            if (wantedFiles.Count == 0)
            {
                Console.WriteLine("No");
            }

            var result = wantedFiles
                .OrderByDescending(f => f.Value)
                .ThenBy(f => f.Key);

            foreach (var file in result)
            {
                Console.WriteLine($"{file.Key} - {file.Value} KB");
            }
        }

        public class File
        {
            public string Location { get; set; }

            public string FileName { get; set; }

            public long FileSize { get; set; }
        }
    }
}

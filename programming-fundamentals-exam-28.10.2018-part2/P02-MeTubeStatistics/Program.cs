using System;
using System.Linq;
using System.Collections.Generic;

namespace P02_MeTubeStatistics
{
    public class Program
    {
        public static void Main()
        {
            var videos = new List<Video>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stats time")
                {
                    break;
                }

                var command = input.Split(new char[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] != "like" && command[0] != "dislike")
                {
                    string name = command[0];
                    int views = int.Parse(command[1]);

                    var video = new Video(name, views);

                    if (!videos.Exists(x => x.Name == video.Name))
                    {
                        videos.Add(video);
                    }

                    else
                    {
                        int index = videos.FindIndex(x => x.Name == video.Name);
                        videos[index].Views += video.Views;
                    }
                }

                else
                {
                    string name = command[1];

                    if (!videos.Exists(x => x.Name == name))
                    {
                        continue;
                    }

                    int index = videos.FindIndex(x => x.Name == name);

                    if (command[0] == "like")
                    {
                        videos[index].Likes += 1;
                    }

                    else if (command[0] == "dislike")
                    {
                        videos[index].Likes -= 1;
                    }
                }
            }

            string order = Console.ReadLine();

            if (order == "by views")
            {
                var result = videos.OrderByDescending(x => x.Views);

                foreach (var video in result)
                {
                    Console.WriteLine($"{video.Name} - {video.Views} views - {video.Likes} likes");
                }
            }

            if (order == "by likes")
            {
                var result = videos.OrderByDescending(x => x.Likes);

                foreach (var video in result)
                {
                    Console.WriteLine($"{video.Name} - {video.Views} views - {video.Likes} likes");
                }
            }
        }
    }

    public class Video
    {
        public string Name { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public Video(string name, int views)
        {
            Name = name;
            Views = views;
            Likes = 0;
        }
    }
}

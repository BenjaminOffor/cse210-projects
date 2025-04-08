// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("Exploring the Mountains", "Nature Travels", 600);
        video1.AddComment(new Comment("Alice", "Beautiful scenery!"));
        video1.AddComment(new Comment("Bob", "I want to visit there someday."));
        video1.AddComment(new Comment("Charlie", "Amazing video quality."));
        videos.Add(video1);

        // Create Video 2
        Video video2 = new Video("Cooking Pasta Perfectly", "Chef Antonio", 480);
        video2.AddComment(new Comment("Diana", "Tried this recipe, delicious!"));
        video2.AddComment(new Comment("Ethan", "Great tips, thanks!"));
        video2.AddComment(new Comment("Fiona", "My pasta turned out perfect!"));
        videos.Add(video2);

        // Create Video 3
        Video video3 = new Video("Understanding Space", "Science Explained", 720);
        video3.AddComment(new Comment("George", "Mind-blowing facts!"));
        video3.AddComment(new Comment("Hannah", "Explained so well."));
        video3.AddComment(new Comment("Ian", "Space is truly fascinating."));
        videos.Add(video3);

        // Display video details
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine(); // Add a blank line between videos
        }
    }
}

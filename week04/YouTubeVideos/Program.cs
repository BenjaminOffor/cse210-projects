using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video { Title = "Exploring the Amazon Rainforest", Author = "Nature Docs", Length = 600 };
        Video video2 = new Video { Title = "Guitar Lessons for Beginners", Author = "Music Pro", Length = 450 };
        Video video3 = new Video { Title = "Cooking Perfect Pasta", Author = "Chef Bella", Length = 300 };

        // Add comments to video 1
        video1.AddComment(new Comment { CommenterName = "John", Text = "Amazing footage!" });
        video1.AddComment(new Comment { CommenterName = "Lucy", Text = "I love the sounds of nature." });
        video1.AddComment(new Comment { CommenterName = "Mark", Text = "Very educational, thanks!" });

        // Add comments to video 2
        video2.AddComment(new Comment { CommenterName = "Sarah", Text = "This helped me a lot!" });
        video2.AddComment(new Comment { CommenterName = "Tom", Text = "Great teaching style." });
        video2.AddComment(new Comment { CommenterName = "Emily", Text = "More lessons, please!" });

        // Add comments to video 3
        video3.AddComment(new Comment { CommenterName = "Anna", Text = "Delicious recipe!" });
        video3.AddComment(new Comment { CommenterName = "Chris", Text = "I'm going to try this today." });
        video3.AddComment(new Comment { CommenterName = "Nina", Text = "Love the presentation." });

        // Store videos in list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> comments = new List<Comment>();

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine();
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public void DisplayComment()
    {
        Console.WriteLine($"{CommenterName}: {Text}");
    }
}

// Video.cs
using System;
using System.Collections.Generic;

public class Video
{
    // Private member variables
    private string _title;
    private string _author;
    private int _length; // Length in seconds
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Public method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Public method to display the video details
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {_comments.Count}");
        Console.WriteLine("Comments:");

        foreach (var comment in _comments)
        {
            comment.DisplayComment();
        }
    }
}

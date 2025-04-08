// Comment.cs
using System;

public class Comment
{
    // Private member variables
    private string _name;
    private string _text;

    // Constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // Public method to display the comment details
    public void DisplayComment()
    {
        Console.WriteLine($"- {_name}: \"{_text}\"");
    }
}

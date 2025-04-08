using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List as many things as you can that make you smile.",
        "List as many people as you can who have influenced you positively.",
        "List as many achievements you're proud of."
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on positive aspects of your life by listing as many items as you can.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Start listing your items! Press Enter after each item.");

        List<string> responses = new List<string>();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    responses.Add(input);
                }
            }
        }

        Console.WriteLine($"You listed {responses.Count} items!");
        DisplayEndingMessage();
    }
}

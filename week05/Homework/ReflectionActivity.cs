using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you overcame a challenge.",
        "Think of a time when you helped someone in need."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How can you apply this in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times of strength and resilience.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine(prompt);
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(question);
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}

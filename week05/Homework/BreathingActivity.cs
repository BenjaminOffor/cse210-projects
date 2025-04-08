using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);

            Console.WriteLine("Now breathe out...");
            ShowCountdown(6);
        }

        DisplayEndingMessage();
    }
}

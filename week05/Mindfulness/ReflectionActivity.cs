using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class ReflectionActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you did something truly difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you pushed through a tough challenge."
        };

        private List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "What did you learn about yourself?",
            "How did you feel when it was complete?",
            "What is your favorite thing about this experience?"
        };

        public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
        {
        }

        protected override void PerformActivity()
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"\nConsider the following prompt:\n--- {prompt} ---");
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder each of the following questions:");
            ShowSpinner(2);

            int interval = GetDuration() / questions.Count;

            foreach (string question in questions)
            {
                Console.WriteLine($"> {question}");
                ShowSpinner(interval);
            }
        }
    }
}

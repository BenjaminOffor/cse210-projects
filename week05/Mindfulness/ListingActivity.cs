using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> prompts = new List<string>
        {
            "List as many things as you can that you are grateful for.",
            "List as many personal strengths as you can.",
            "List as many things as you can that help you relax."
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the positive aspects of your life by listing as many items as you can.")
        {
        }

        protected override void PerformActivity()
        {
            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"\nList prompt:\n--- {prompt} ---");
            Console.WriteLine("You will have a moment to think, then start listing. Press Enter when you are ready.");
            Console.ReadLine();

            Console.WriteLine("Start listing items! (Press Enter after each item)");
            ShowSpinner(2);

            int duration = GetDuration();
            DateTime endTime = DateTime.Now.AddSeconds(duration);
            List<string> items = new List<string>();

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                items.Add(item);
            }

            Console.WriteLine($"\nYou listed {items.Count} items!");
        }
    }
}

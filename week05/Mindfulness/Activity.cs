using System;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        private string name;
        private string description;
        private int duration;

        public Activity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public void StartActivity()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {name}.");
            Console.WriteLine(description);
            Console.Write("Enter the duration in seconds: ");
            duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);

            PerformActivity();

            EndActivity();
        }

        protected abstract void PerformActivity();

        protected void EndActivity()
        {
            Console.WriteLine("\nWell done!");
            Console.WriteLine($"You have completed {duration} seconds of the {name}.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds * 2; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public int GetDuration()
        {
            return duration;
        }
    }
}

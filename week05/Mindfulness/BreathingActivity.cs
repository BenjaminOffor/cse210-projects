using System;
using System.Threading;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity()
        {
            int cycles = GetDuration() / 8;

            for (int i = 0; i < cycles; i++)
            {
                Console.WriteLine("\nBreathe in...");
                Countdown(4);
                Console.WriteLine("Now breathe out...");
                Countdown(4);
            }
        }
    }
}

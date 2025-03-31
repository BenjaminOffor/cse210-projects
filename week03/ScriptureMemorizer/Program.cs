using System;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all your heart and lean not on your own understanding; " +
            "in all your ways submit to him, and he will make your paths straight."
        );

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Press any key to exit.");
        Console.ReadKey();
    }
}

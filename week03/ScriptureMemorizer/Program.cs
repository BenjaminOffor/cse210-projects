using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Initialize scripture
        Scripture scripture = new Scripture(new Reference("Proverbs", 3, 5, 6), 
            "Trust in the Lord with all your heart and lean not on your own understanding; " +
            "in all your ways submit to him, and he will make your paths straight.");

        // Game loop
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(3); // Hide 3 words at a time
        }

        // Final display before exiting
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Press any key to exit.");
        Console.ReadKey();
    }
}

// Class to represent the scripture reference (e.g., "Proverbs 3:5-6")
class Reference
{
    public string Book { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }
    public int Chapter { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = (endVerse == -1) ? startVerse : endVerse;
    }

    public override string ToString()
    {
        return EndVerse == StartVerse 
            ? $"{Book} {Chapter}:{StartVerse}" 
            : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

// Class to represent a single word
class Word
{
    public string Text { get; }
    private bool isHidden;

    public Word(string text)
    {
        Text = text;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public string GetDisplayText()
    {
        return isHidden ? new string('_', Text.Length) : Text;
    }

    public bool IsHidden()
    {
        return isHidden;
    }
}

// Class to represent the scripture
class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = words.Where(w => !w.IsHidden()).ToList();

        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Remove to prevent rehiding
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{reference}\n" + string.Join(" ", words.Select(w => w.GetDisplayText()));
    }
}

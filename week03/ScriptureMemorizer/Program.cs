using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture(new Reference("Proverbs", 3, 5, 6), 
            "Trust in the Lord with all your heart and lean not on your own understanding; " +
            "in all your ways submit to him, and he will make your paths straight.");

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Press any key to exit.");
        Console.ReadKey();
    }
}

class Reference
{
    private string Book { get; }
    private int StartVerse { get; }
    private int EndVerse { get; }
    private int Chapter { get; }

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

class Word
{
    private string Text { get; }
    private bool isHidden;

    public Word(string text)
    {
        Text = text;
        isHidden = false;
    }

    public void Hide() => isHidden = true;

    public string GetDisplayText() => isHidden ? new string('_', Text.Length) : Text;

    public bool IsHidden() => isHidden;
}

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
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden() => words.All(w => w.IsHidden());

    public string GetDisplayText() => $"{reference}\n" + string.Join(" ", words.Select(w => w.GetDisplayText()));
}

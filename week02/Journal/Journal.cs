// Journal.cs (Handles journal operations)
using System;
using System.Collections.Generic;
using System.IO;

public class Journal : IJournal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rnd = new Random();
        string prompt = _prompts[rnd.Next(_prompts.Count)];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        _entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }
        
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }

        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            _entries.Add(Entry.FromFileFormat(line));
        }
        
        Console.WriteLine("Journal loaded successfully!\n");
    }
}
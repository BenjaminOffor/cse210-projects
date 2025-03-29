using System;
using System.Collections.Generic;
using System.IO;

// Abstraction: Defines an interface for entries in the journal
public interface IEntry
{
    void Display();
    string ToFileFormat();
}

// Concrete implementation of IEntry
public class Entry : IEntry
{
    public string Date { get; private set; }
    public string Prompt { get; private set; }
    public string Response { get; private set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n");
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length < 3) throw new FormatException("Invalid file format.");
        return new Entry(parts[1], parts[2]) { Date = parts[0] };
    }
}

// Abstraction: Defines an interface for journal operations
public interface IJournal
{
    void AddEntry();
    void DisplayEntries();
    void SaveToFile();
    void LoadFromFile();
}

// Concrete implementation of IJournal
public class Journal : IJournal
{
    private List<IEntry> _entries = new List<IEntry>();
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

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToFileFormat());
                }
            }
            Console.WriteLine("Journal saved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
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

        try
        {
            _entries.Clear();
            foreach (string line in File.ReadAllLines(filename))
            {
                _entries.Add(Entry.FromFileFormat(line));
            }
            Console.WriteLine("Journal loaded successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        IJournal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save to File");
            Console.WriteLine("4. Load from File");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
        }
    }
}

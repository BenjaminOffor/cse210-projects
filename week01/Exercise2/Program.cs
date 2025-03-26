using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Entry> entries = new List<Entry>();

        string[] lines = System.IO.File.ReadAllLines("entries.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[0], parts[1], parts[2])); // ✅ Fixed
            }
        }

        foreach (Entry entry in entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt} - {entry.Response}");
        }
    }
}

public class Entry
{
    public string Date { get; }  // Read-only property
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
}

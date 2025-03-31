using System;
using System.Collections.Generic;
using System.Linq;

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
        if (visibleWords.Count == 0)
            return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
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

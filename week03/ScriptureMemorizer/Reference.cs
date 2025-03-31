class Reference
{
    private string Book { get; }
    private int Chapter { get; }
    private int StartVerse { get; }
    private int EndVerse { get; }

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

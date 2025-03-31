class Word
{
    private string Text { get; }
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

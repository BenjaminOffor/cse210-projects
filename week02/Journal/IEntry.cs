// IEntry.cs (Interface for Entry abstraction)
public interface IEntry
{
    string Date { get; set; }
    string Prompt { get; set; }
    string Response { get; set; }
    void Display();
    string ToFileFormat();
}

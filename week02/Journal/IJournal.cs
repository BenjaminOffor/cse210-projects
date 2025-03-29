// IJournal.cs (Interface for Journal abstraction)
using System.Collections.Generic;

public interface IJournal
{
    void AddEntry();
    void DisplayEntries();
    void SaveToFile();
    void LoadFromFile();
}
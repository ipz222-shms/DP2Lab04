namespace MementoLibrary;

public class TextEditor : IOriginator
{
    private TextDocument _current = new();
    private readonly List<DocumentSnapshot> _history = [];

    public void Write(string text) => _current.Content += text;
    public void WriteLine(string text) => _current.Content += $"{text}\n";
    public void Purge() => _current.Content = string.Empty;
    public string ReadAll() => _current.Content;
    
    public DocumentSnapshot Save()
    {
        var snapshot = _current.CreateSnapshot();
        _history.Add(snapshot);
        return snapshot;
    }

    public void Restore()
        => _current = new TextDocument(_history.Last());

    public void Restore(int index)
        => _current = new TextDocument(_history[index]);

    public void Restore(DocumentSnapshot snapshot)
        => _current = new TextDocument(snapshot);
}

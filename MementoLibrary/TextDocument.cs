namespace MementoLibrary;

public class TextDocument : ISnapshot
{
    private int _flags = 0;
    private DateTime _lastEdit = DateTime.Now;
    private string _filename = "New Document.txt";
    private string _content = string.Empty;

    public string Filename
    {
        get => _filename;
        set
        {
            _filename = value;
            _lastEdit = DateTime.Now;
        }
    }
    public string Content
    {
        get => _content;
        set
        {
            _content = value;
            _lastEdit = DateTime.Now;
        }
    }
    public DateTime LastEdit => _lastEdit;
    
    public TextDocument() { }

    public TextDocument(DocumentSnapshot snapshot)
    {
        _flags = snapshot.Flags;
        _lastEdit = snapshot.LastEdit;
        _filename = snapshot.Filename;
        _content = snapshot.Content;
    }
    
    public DocumentSnapshot CreateSnapshot() => new(this, _flags);
}

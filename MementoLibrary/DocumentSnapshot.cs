namespace MementoLibrary;

public class DocumentSnapshot(TextDocument document, int flags)
{
    public int Flags { get; } = flags;
    public DateTime LastEdit { get; } = document.LastEdit;
    public string Filename { get; } = document.Filename;
    public string Content { get; } = document.Content;
    public DateTime SnapshotTime { get; } = DateTime.Now;
}

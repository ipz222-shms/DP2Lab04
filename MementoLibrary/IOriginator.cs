namespace MementoLibrary;

public interface IOriginator
{
    public void Restore();
    public void Restore(int index);
    public void Restore(DocumentSnapshot snapshot);
}

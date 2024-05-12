namespace MediatorLibrary;

public class Aircraft : CommandCentreComponent
{
    public string Name { get; }
    public int Size { get; }
    public Runway? CurrentRunway { get; set; }
    public bool IsTakingOff { get; set; }
    
    public Aircraft(string name, int size)
    {
        Name = name;
        Size = size;
    }
    
    public void Land(Runway runway)
        => _notifyCC(this, runway, AircraftEvent.Land);
    
    public void TakeOff(Runway runway)
        => _notifyCC(this, runway, AircraftEvent.TakeOff);
}

namespace MediatorLibrary;

public class Runway : CommandCentreComponent
{
    public readonly Guid Id = Guid.NewGuid();
    public Aircraft? IsBusyWithAircraft;

    public void HighLightRed()
        => _notifyCC(this, RunwayEvent.HighLightRed);

    public void HighLightGreen()
        => _notifyCC(this, RunwayEvent.HighLightGreen);
}

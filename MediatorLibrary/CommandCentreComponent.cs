namespace MediatorLibrary;

public abstract class CommandCentreComponent
{
    public CommandCentre? Centre { protected get; set; }

    protected void _notifyCC(Aircraft aircraft, Runway runway, AircraftEvent aircraftEvent)
        => Centre?.Notify(aircraft, runway, aircraftEvent);
    
    protected void _notifyCC(Runway runway, RunwayEvent runwayEvent)
        => Centre?.Notify(runway, runwayEvent);
}

namespace MediatorLibrary;

public class CommandCentre
{
    private readonly List<Runway> _runways = [];
    private readonly List<Aircraft> _aircrafts = [];

    public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
    {
        _runways.AddRange(runways.Select(r => { r.Centre = this; return r; }));
        _aircrafts.AddRange(aircrafts.Select(a => { a.Centre = this; return a; }));
    }
    
    public bool CheckIsActive(Runway runway)
    {
        var result = false;
        if (runway.IsBusyWithAircraft != null)
            result = runway.IsBusyWithAircraft.IsTakingOff;
        return result;
    }

    internal void Notify(Aircraft aircraft, Runway runway, AircraftEvent aircraftEvent)
    {
        if (!CheckForAircraft(aircraft) || !CheckForRunway(runway))
            return;
        
        switch (aircraftEvent)
        {
            case AircraftEvent.Land:
                Console.WriteLine($"Aircraft {aircraft.Name} is landing.");
                Console.WriteLine("Checking runway.");
                if (runway.IsBusyWithAircraft == null)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} has landed.");
                    runway.IsBusyWithAircraft = aircraft;
                    runway.HighLightRed();
                    aircraft.CurrentRunway = runway;
                }
                else
                    Console.WriteLine("Could not land, the runway is busy.");
                break;
            case AircraftEvent.TakeOff:
                Console.WriteLine($"Aircraft {aircraft.Name} is taking off.");
                runway.IsBusyWithAircraft = null;
                aircraft.CurrentRunway = null;
                runway.HighLightGreen();
                Console.WriteLine($"Aircraft {aircraft.Name} has took off.");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(aircraftEvent), aircraftEvent, null);
        }
    }
    
    internal void Notify(Runway runway, RunwayEvent runwayEvent)
    {
        if (!CheckForRunway(runway))
            return;
        
        switch (runwayEvent)
        {
            case RunwayEvent.HighLightRed:
                Console.WriteLine($"Runway {runway.Id} is busy!");
                break;
            case RunwayEvent.HighLightGreen:
                Console.WriteLine($"Runway {runway.Id} is free!");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(runwayEvent), runwayEvent, null);
        }
    }
    
    private bool CheckForRunway(Runway runway)
    {
        if (_runways.Contains(runway))
            return true;
        Console.WriteLine("This Command Centre doesn't serve this Runway!");
        return false;
    }
    
    private bool CheckForAircraft(Aircraft aircraft)
    {
        if (_aircrafts.Contains(aircraft))
            return true;
        Console.WriteLine("This Command Centre doesn't serve this Aircraft!");
        return false;
    }
}

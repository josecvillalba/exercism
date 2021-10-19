public interface ITelemetry
{
    void Calibrate();
    bool SelfTest();
    void ShowSponsor(string sponsorName);
    void SetSpeed(decimal amount, string unitsString);
}

public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    public ITelemetry Telemetry { get; }
    
    private Speed _currentSpeed;

    public RemoteControlCar()
    {
        Telemetry = new RccTelemetry(this);
    }

    private class RccTelemetry: ITelemetry
    {
        private readonly RemoteControlCar _parent;
        
        public RccTelemetry(RemoteControlCar parent)
        {
            this._parent = parent;     
        }
        
        public void Calibrate()
        {

        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            _parent.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            _parent.SetSpeed(new Speed(amount, speedUnits));
        }
        
    }
    

    public string GetSpeed()
    {
        return _currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        _currentSpeed = speed;
    }


    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private readonly struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
    
    
    
}


using System;

class RemoteControlCar
{

    private int distance;
    private int battery;
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public RemoteControlCar()
    {
        distance = 0;
        battery = 100;
    }
    
    public string DistanceDisplay()
    {
        return $"Driven {distance} meters";
    }

    public string BatteryDisplay()
    {
        if (battery == 0)
        {
            return "Battery empty";
        }
        return $"Battery at {battery}%";
    }

    public void Drive()
    {
        if (battery == 0) return;
        battery -= 1;
        distance += 20;

    }
}

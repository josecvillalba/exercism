using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    public int DistanceTravelled { get; }
    public void Drive();
}

public class ProductionRemoteControlCar: IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar obj) => NumberOfVictories - obj.NumberOfVictories;
}

public class ExperimentalRemoteControlCar: IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var result = new List<ProductionRemoteControlCar>
        {
            prc1,
            prc2
        };
        result.Sort();
        return result;
    }
}

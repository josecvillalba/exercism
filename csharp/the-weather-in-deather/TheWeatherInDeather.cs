using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Xunit.Sdk;

public class WeatherStation
{
    private Reading _reading;
    private List<DateTime> _recordDates = new();
    private List<decimal> _temperatures = new();

    public void AcceptReading(Reading reading)
    {
        _reading = reading;
        _recordDates.Add(DateTime.Now);
        _temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        _reading = new Reading();
        _recordDates.Clear();
        _temperatures.Clear();
    }

    public decimal LatestTemperature => _reading.Temperature;

    public decimal LatestPressure => _reading.Pressure;

    public decimal LatestRainfall => _reading.Rainfall;

    public bool HasHistory => _recordDates.Count > 1;

    public Outlook ShortTermOutlook
    {
        get
        {
            if (_reading.Equals(new Reading()))
            {
                throw new ArgumentException();
            }

            return (_reading.Temperature, _reading.Pressure) switch
            {
                (< 30, < 10) => Outlook.Cool,
                (> 50, _) => Outlook.Good,
                _ => Outlook.Warm,
            };
        }
    }

    public Outlook LongTermOutlook => _reading.WindDirection switch
    {
        WindDirection.Easterly => _reading.Temperature > 20 ? Outlook.Good : Outlook.Warm,
        WindDirection.Westerly => Outlook.Rainy,
        WindDirection.Northerly => Outlook.Cool,
        WindDirection.Southerly => Outlook.Good,
        _ => throw new ArgumentException()
    };

    public State RunSelfTest() => _reading.Equals(new Reading()) ? State.Bad : State.Good;

}

/*** Please do not modify this struct ***/
public struct Reading
{
    public decimal Temperature { get; }
    public decimal Pressure { get; }
    public decimal Rainfall { get; }
    public WindDirection WindDirection { get; }

    public Reading(decimal temperature, decimal pressure,
        decimal rainfall, WindDirection windDirection)
    {
        Temperature = temperature;
        Pressure = pressure;
        Rainfall = rainfall;
        WindDirection = windDirection;
    }
}

/*** Please do not modify this enum ***/
public enum State
{
    Good,
    Bad
}

/*** Please do not modify this enum ***/
public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}

/*** Please do not modify this enum ***/
public enum WindDirection
{
    Unknown = 0,    // default
    Northerly,
    Easterly,
    Southerly,
    Westerly
}

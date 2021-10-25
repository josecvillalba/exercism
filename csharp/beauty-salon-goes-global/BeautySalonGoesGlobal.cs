using System;
using System.Globalization;
using System.Runtime.InteropServices;


public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{

    private static bool IsWindows => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();
   
    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var dateTime = DateTime.Parse(appointmentDateDescription);

        var timeZoneInfo = GetTimeZoneInfo(location);
        
        return TimeZoneInfo.ConvertTimeToUtc(dateTime,timeZoneInfo);

    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.Subtract(new TimeSpan(1, 0, 0, 0)),
            AlertLevel.Standard => appointment.Subtract(new TimeSpan(1, 45, 0)),
            AlertLevel.Late => appointment.Subtract(new TimeSpan(0, 30, 0)),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel), alertLevel, null)
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZoneInfo = GetTimeZoneInfo(location);
        var sevenDaysAgo = dt.Subtract(new TimeSpan(7, 0, 0, 0));

        return (timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(sevenDaysAgo));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var cultureInfo = GetLocationCultureInfo(location);

        try
        {
            return DateTime.Parse(dtStr,cultureInfo);
        }
        catch
        {
            return DateTime.MinValue;
        }
    }


    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        var timeZoneId = GetTimeZoneId(location);

        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }

    private static string GetTimeZoneId(Location location) => location switch
    {
        Location.London => IsWindows ? "GMT Standard Time" : "Europe/London",
        Location.NewYork => IsWindows ? "Eastern Standard Time" : "America/New_York",
        Location.Paris => IsWindows ? "W. Europe Standard Time" : "Europe/Paris",
        _ => throw new ArgumentOutOfRangeException()
    };

    private static CultureInfo GetLocationCultureInfo(Location location) => location switch
    {
        Location.London => CultureInfo.GetCultureInfo("en-GB"),
        Location.NewYork => CultureInfo.GetCultureInfo("en-US"),
        Location.Paris => CultureInfo.GetCultureInfo("fr-FR"),
        _ => throw new ArgumentOutOfRangeException($"location: {location} not found")
    };

}

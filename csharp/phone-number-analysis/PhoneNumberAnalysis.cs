using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var number = phoneNumber.Split('-');
        var isNewYork = number[0] == "212";
        var isFake = number[1] == "555";
        var localNumber = number[2];

        return (isNewYork, isFake, localNumber);

    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}

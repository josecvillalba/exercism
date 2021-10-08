using System;
using System.Globalization;
using System.Linq.Expressions;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {

        try
        {
            checked
            {
                return (multiplier * @base).ToString();
            }
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }

    }

    public static string DisplayGDP(float @base, float multiplier)
    {

        Single gdp = 0f;
        
        checked
        {
            gdp = (multiplier * @base);

        }

        if (double.IsInfinity(gdp))
        {
            return "*** Too Big ***";
        }

        return gdp.ToString(CultureInfo.InvariantCulture);

    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        string result = "";

        try
        {
            checked
            {
                result = (salaryBase * multiplier).ToString(CultureInfo.InvariantCulture);
            }

        }

        catch
        {
            result = "*** Much Too Big ***";
        }

        return result;
    }
}

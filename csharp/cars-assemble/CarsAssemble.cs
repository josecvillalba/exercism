using System;

static class AssemblyLine
{

    public static double SuccessRate(int speed)
    {

        if (speed>4 && speed<9)
        {
            return 0.9;
        }
        else if (speed == 9)
        {
            return 0.8;
        }
        else if (speed == 10)
        {
            return 0.77;
        }

        return 1;
        
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        double prod = speed * 221;

        return SuccessRate(speed)*prod;
        
    }

    public static int WorkingItemsPerMinute(int speed)
    {
      
        return (int)(ProductionRatePerHour(speed)/60);
        
    }
}

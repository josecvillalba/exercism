using System;
using System.Linq;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return birdsPerDay[6];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[6]++;
    }

    public bool HasDayWithoutBirds()
    {
        return birdsPerDay.Any(x => x == 0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        var count = 0;
        
        for (int i = 0; i < numberOfDays; i++)
        {
            count += birdsPerDay[i];
        }

        return count;
    }

    public int BusyDays()
    {
        int result = 0;
        
        foreach (var views in birdsPerDay)
        {
            if (views >= 5)
            {
                result++;
            }
        }

        return result;
    }
}

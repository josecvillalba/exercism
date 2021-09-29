using System;

public static class Darts
{

    public static double Radius(double x, double y) => Math.Sqrt(Math.Pow(x, 2d) + Math.Pow(y, 2d));

    public static int Score(double x, double y)
    {
        double radius = Radius(x, y);

        return radius switch
        {
            <= 1 => 10,
            <= 5 => 5,
            <= 10 => 1,
            _ => 0
        };
    }
}

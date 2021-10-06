using System;

public class Player
{

    private readonly Random _rd = new System.Random();

    public int RollDie()
    {
        return _rd.Next(1,18);
    }

    public double GenerateSpellStrength()
    {
        return _rd.NextDouble() * 100;
    }
}

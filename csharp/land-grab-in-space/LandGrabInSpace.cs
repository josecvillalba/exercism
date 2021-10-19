using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static PlotCoords;

public enum PlotCoords { A, B, C, D}

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
    
    public double Length(Coord that) => Sqrt(Pow(Abs(that.Y - this.Y), 2) + Pow(Abs(that.X - this.X), 2));
}

public struct Plot: IEquatable<Plot>
{
    private readonly Dictionary<PlotCoords,Coord> _coords;

    public readonly double LongestSideLength => new[]
    {
        _coords[A].Length(_coords[B]),
        _coords[B].Length(_coords[C]),
        _coords[C].Length(_coords[D]),
        _coords[D].Length(_coords[A])
    }.Max();
    
    public Plot(Coord a, Coord b, Coord c, Coord d)
    {
        _coords = new Dictionary<PlotCoords, Coord>
        {
            {A, a},
            {B, b},
            {C, c},
            {D, d}
        };
    }

    public bool Equals(Plot other) => _coords.SequenceEqual(other._coords);

    public override int GetHashCode()
    {
        return HashCode.Combine(_coords[A],_coords[B],_coords[C],_coords[D]);
    }
}


public class ClaimsHandler
{

    private readonly List<Plot> _claims;

    public ClaimsHandler()
    {
        _claims = new List<Plot>();
    }
    
    public void StakeClaim(Plot plot)
    {
        _claims.Add(plot);
    }

    public bool IsClaimStaked(Plot plot) => _claims.Contains(plot);

    public bool IsLastClaim(Plot plot)
    {
        return _claims.Last().Equals(plot);
    }

    public Plot GetClaimWithLongestSide() => _claims.OrderBy(c => c.LongestSideLength).Last();
}

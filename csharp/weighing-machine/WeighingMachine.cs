using System;

enum Unit
{
    Pounds,
    Kilograms
}

class WeighingMachine
{
    private decimal _inputWeight;

    public decimal InputWeight
    {
        get => _inputWeight;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _inputWeight = value;
        }
    }

    public decimal DisplayWeight => InputWeight - TareAdjustment;

    public USWeight USDisplayWeight => new(InputWeight, Unit);

    public decimal TareAdjustment { private get; set; }

    public Unit Unit { get; set; } = Unit.Kilograms;
}

struct USWeight
{

    private const decimal PoundsPerKilogram = 2.2046m;
    private const int OuncesPerPound = 16;

    public USWeight(decimal weightInPounds, Unit unit)
    {
        var transformWeight = unit switch
        {
            Unit.Kilograms => weightInPounds * PoundsPerKilogram,
            _ => weightInPounds
        };

        Pounds = Math.Floor(transformWeight);
        Ounces = Math.Floor((transformWeight - Pounds) * OuncesPerPound);

    }

    public decimal Pounds { get; }

    public decimal Ounces { get; }
}

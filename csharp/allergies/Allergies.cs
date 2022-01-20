using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{

    private readonly BitArray _b;

    public Allergies(int mask) => _b = new BitArray(new int[] { mask });

    public bool IsAllergicTo(Allergen allergen) => _b[((int)allergen)];

    public Allergen[] List()
    {
        List<Allergen> result = new List<Allergen>();

        foreach (Allergen allergen in (Allergen[]) Enum.GetValues(typeof(Allergen)))
        {
            if (IsAllergicTo(allergen))
            {
                result.Add(allergen);
            }
        }

        return result.ToArray<Allergen>();
    }
}
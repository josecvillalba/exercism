using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount l, CurrencyAmount r)
    {
        if (l.currency.Equals(r.currency)) return l.amount == r.amount;

        throw new ArgumentException("The two currency amount structs do not have the same currency");
    }

    public static bool operator !=(CurrencyAmount l, CurrencyAmount r)
    {
        return !(l == r);
    }

    public static bool operator >(CurrencyAmount l, CurrencyAmount r)
    {
        if (l.currency.Equals(r.currency)) return l.amount > r.amount;

        throw new ArgumentException("The two currency amount structs do not have the same currency");
        
    }

    public static bool operator <(CurrencyAmount l, CurrencyAmount r)
    {
        if (l.currency.Equals(r.currency)) return l.amount < r.amount;

        throw new ArgumentException("The two currency amount structs do not have the same currency");
        
    }

    public static decimal operator +(CurrencyAmount l, CurrencyAmount r)
    {
        if (l.currency.Equals(r.currency)) return l.amount + r.amount;

        throw new ArgumentException("The two currency amount structs do not have the same currency");
        
    }

    public static decimal operator -(CurrencyAmount l, CurrencyAmount r)
    {
        if (l.currency.Equals(r.currency)) return l.amount - r.amount;

        throw new ArgumentException("The two currency amount structs do not have the same currency");
        
    }
    
    public static decimal operator *(CurrencyAmount l, CurrencyAmount r)
    {
        if (l.currency.Equals(r.currency)) return l.amount * r.amount;

        throw new ArgumentException("The two currency amount structs do not have the same currency");
        
    }
    
    public static decimal operator /(CurrencyAmount l, CurrencyAmount r)
    {
        if (l.currency.Equals(r.currency)) return l.amount / r.amount;

        throw new ArgumentException("The two currency amount structs do not have the same currency");
        
    }

    public static explicit operator double(CurrencyAmount l)
    {
        return (double) l.amount;
    }

    public static implicit operator decimal(CurrencyAmount l)
    {
        return l.amount;
    }
    
}

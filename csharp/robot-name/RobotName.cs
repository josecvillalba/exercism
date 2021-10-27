using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    
    private static readonly Random Random = new Random();

    private static readonly HashSet<string> SavedNames = new HashSet<string>();

    public Robot() => Name = GetNewName();

    private static string GetNewName()
    {
        var newName = RandomAlphaString(2) + RandomNumberString(3);
        
        while (SavedNames.Contains(newName))
        {
            newName = RandomAlphaString(2) + RandomNumberString(3);            
        }

        SavedNames.Add(newName);
        return newName;
    }

    private static string RandomAlphaString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    private static string RandomNumberString(int length)
    {
        const string chars = "0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }
    
    public string Name { get; private set; }

    public void Reset()
    {
        SavedNames.Remove(Name);
        Name = GetNewName();
    }
}
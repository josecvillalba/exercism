using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public static class Languages
{

    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        var myList = NewList();
    
        myList.Add("C#");
        myList.Add("Clojure");
        myList.Add("Elm");

        return myList;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);

        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        
        languages.Reverse();
        
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        return ((languages.Count > 0) && (languages[0] == "C#")) 
               || 
               ((languages.Count is >= 2 and <= 3) && (languages[1] == "C#"));
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        bool dup = false;
        languages.Sort();

        int i = 0;
        while (!dup && (i < languages.Count-1))
        {
            dup = languages[i] == languages[i + 1];
            i++;
        }

        return !dup;
    }
}

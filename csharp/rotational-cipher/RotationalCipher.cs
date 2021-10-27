using System;
using System.Linq;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {

        char Rotate(char c)
        {
            if (!char.IsLetter(c))
                return c;
            char d = char.IsUpper(c) ? 'A' : 'a'; 
            return (char)((((c + shiftKey) - d) % 26) + d);
        }
        
        return string.Concat(text.Select(Rotate));  
        
    }
}
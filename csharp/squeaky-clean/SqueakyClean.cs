using System.Text;

public static class Identifier
{
    private static bool IsLowerGreek(char c)
    {
        // Lower alpha UTF-16 945
        // lower omega UTF-16 969
        return (int)c is >= 945 and <= 969;
    }
    
    public static string Clean(string identifier)
    {

        var sb = new StringBuilder();
        var isAfterDash = false;

        foreach (var c in identifier)
        {
            sb.Append(c switch
            {
                _ when IsLowerGreek(c) => default,
                _ when isAfterDash => char.ToUpper(c),
                _ when char.IsWhiteSpace(c) => '_',
                _ when char.IsControl(c) => "CTRL",
                _ when char.IsLetter(c) => c,
                _ => default,
            });

            isAfterDash = c.Equals('-');
        }
        

        return sb.ToString();
    }
}

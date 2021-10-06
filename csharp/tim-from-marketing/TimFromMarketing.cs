using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var idPrefix = string.Empty;
        
        if (id != null)
        {
            idPrefix = $"[{id}] - ";
        }

        var dpt = "OWNER";
        if (department != null)
        {
            dpt = department.ToUpper();
        }
        
        return $"{idPrefix}{name} - {dpt}";
    }
}

using System;

static class Badge
{

    private const string DefaultDepartment = "OWNER";

    public static string Print(int? id, string name, string? department)
    {

        department = (department ?? DefaultDepartment).ToUpper();

        return id.HasValue switch
        {
            true => $"[{id}] - {name} - {department}",
            false => $"{name} - {department}"
        };
    }
}

using System;
using System.Runtime.InteropServices.ComTypes;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1: return "goalie";
            case 2: return "left back";
            case <=4: return "center back";
            case 5: return "right back";
            case <=8: return "midfielder";
            case 9: return "left wing";
            case 10: return "striker";
            case 11: return "right wing";
            default: throw new ArgumentOutOfRangeException();
        }
    }

    public static string AnalyzeOffField(object report)
    {

        return report switch
        {
            int supporters => $"There are {supporters} supporters at the match.",
            string text => text,
            Injury injury => $"Oh no! {injury.GetDescription()} Medics are on the field.",
            Incident incident => incident.GetDescription(),
            Manager {Club: null} manager => $"{manager.Name}",
            Manager manager => $"{manager.Name} ({manager.Club})",
            _ => throw new ArgumentException()
        };

    }
}


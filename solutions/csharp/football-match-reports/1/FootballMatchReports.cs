public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch(shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5: 
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
                default:
                return "UNKNOWN";
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int number when number > 0:
                return $"There are {number} supporters at the match.";
            case string text when !string.IsNullOrEmpty(text):
                return text;
            case Manager manager when manager.Club == null:
                return manager.Name;
            case Manager manager when manager.Club != null:
                return $"{manager.Name} ({manager.Club})";
            case Injury injury when injury != null:
                var phrase = injury.GetDescription();
                return $"Oh no! {phrase} Medics are on the field.";
            case Incident incident when incident != null:
                return incident.GetDescription();
            default:
                return "";
        }
    }
}

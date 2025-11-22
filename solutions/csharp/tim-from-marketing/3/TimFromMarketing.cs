using System;

static class Badge
{
    //  didnt use ??
    public static string Print(int? id, string name, string? department)
    {    
        // function variables
               
        department = department ?? "Owner";            // if null then = Owner
        
        string ID = id != null ? $"[{id}] - " : "";           // if id != null return frame to ID else return "" to ID
        
       return $"{ID}{name} - {department.ToUpper() ?? ""}";
    }
}
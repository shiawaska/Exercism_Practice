using System;

static class Badge
{
    //  didnt use ??
    public static string Print(int? id, string name, string? department)
    {    
        // function variables
               
        department = department ?? "Owner";            // if null then = Owner
        
        string ID = id?.ToString() ?? "";                // if null ID "" to ID else  ID = id
        if (ID != "")                                    
            ID = $"[{id}] - ";                   // if id was not null then frame id as desired     
        
       return $"{ID}{name} - {department.ToUpper() ?? ""}";
    }
}
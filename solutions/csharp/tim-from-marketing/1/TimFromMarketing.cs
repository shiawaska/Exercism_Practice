using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {    
        // function variables
        string idString = "";
        string departmentString = "";
        
        if (department != null)                       // check department for null
            departmentString = department.ToUpper();
        else 
            departmentString = "owner";                  // this is a poor idea
        if (id != null)                               // check id for null
        {
            idString = id.ToString();
            idString = $"[{idString}] - ";
        }
        else 
            idString = ""; 
        
       return $"{idString}{name} - {departmentString.ToUpper() ?? ""}";
    }
}
static class GameMaster
{
    public static string Describe(Character character)
    {
      // "You're a level <LEVEL> <CLASS> with <HIT_POINTS> hit points."
      return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
       // "You've arrived at <NAME>, which has <INHABITANTS> inhabitants."
         return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        // "You're traveling to your destination by walking."
        //"You're traveling to your destination on horseback."
        return travelMethod == TravelMethod.Walking ? "You're traveling to your destination by walking." : "You're traveling to your destination on horseback.";
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
        // "You're a level 4 Wizard with 28 hit points. You're traveling to your destination on horseback. You've arrived at Muros, which has 732 inhabitants."
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points. You're traveling to your destination {(travelMethod == TravelMethod.Walking ? "by walking." : "on horseback.")} You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(Character character, Destination destination)
    {
        // "You're a level 4 Wizard with 28 hit points. You're traveling to your destination by walking. You've arrived at Muros, which has 732 inhabitants."
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points. You're traveling to your destination by walking. You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }
}

class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}

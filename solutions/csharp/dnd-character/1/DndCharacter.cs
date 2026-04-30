public class DndCharacter
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int Hitpoints { get; set; }

    public static int Modifier(int score)
    {
       return score / 2 - 5;
    }

    public static int Ability() 
    {
         var rolls = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            rolls.Add(RollD6());
        }
        return rolls.Sum() - rolls.Min();
    }

    public static DndCharacter Generate()
    {
        var character = new DndCharacter();
        character.Strength = Ability();
        character.Dexterity = Ability();
        character.Constitution = Ability();
        character.Intelligence = Ability();
        character.Wisdom = Ability();
        character.Charisma = Ability();
        character.Hitpoints = 10 + Modifier(character.Constitution);

        return character;
    }
    
    

    private static int RollD6() => Random.Shared.Next(1,7);
    
        
    
}

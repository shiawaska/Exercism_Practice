using System;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        /* throw new NotImplementedException("Please implement the (static) QuestLogic.CanFastAttack() method"); */
        if (knightIsAwake == true)
        {
            return false;            
        }
        else {
            return true;
        }
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        /* throw new NotImplementedException("Please implement the (static) QuestLogic.CanSpy() method"); */ 
        if (knightIsAwake || archerIsAwake || prisonerIsAwake == true)
        {
        return true;    
        }
        else{
            
        return false;
        }
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        // throw new NotImplementedException("Please implement the (static) QuestLogic.CanSignalPrisoner() method");
        if (prisonerIsAwake && !archerIsAwake == true)
        {
            return true;
        }
        else {
            return false;
        }
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        // throw new NotImplementedException("Please implement the (static) QuestLogic.CanFreePrisoner() method");
        
        if (petDogIsPresent == false)
        {
            if (prisonerIsAwake == true)
            {
                if (!knightIsAwake && archerIsAwake == false)
                {                    
                    return true;
                }
                else
                {                    
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
        else
        {
            if (archerIsAwake == false)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}

using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        // throw new NotImplementedException($"Please implement the (static) PhoneNumber.Analyze() method");
        string NewYorkCheck = phoneNumber.Remove(3 );
        bool IsNewYork;    
        if (NewYorkCheck == "212"){
                IsNewYork = true;
            }
            else { 
                 IsNewYork = false;
            }
        string FakeCheck = phoneNumber.Remove(0,4);
        
        bool IsFake;
        FakeCheck = FakeCheck.Remove(3);
            if (FakeCheck == "555"){
                 IsFake = true;
            }
            else {
                 IsFake = false;
            }
        string LocalNumber = phoneNumber.Remove(0,8);
       (bool,bool,string) answer = (IsNewYork,IsFake,LocalNumber);
        return answer;
    }
    

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        // throw new NotImplementedException($"Please implement the (static) PhoneNumber.IsFake() method");
        return phoneNumberInfo.IsFake;
    }
}

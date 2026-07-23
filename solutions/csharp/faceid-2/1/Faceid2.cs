public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    public bool Equals(FacialFeatures other)
    {
        return EyeColor == other.EyeColor && PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    public bool Equals(Identity other)
    {
        return Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{
    private readonly Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    
    private  List<Identity> registeredIdentities = new List<Identity>();
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
      return identity.Equals(admin);
    }

    public bool Register(Identity identity)
    {
        if (registeredIdentities.Any(x => x.Equals(identity)))
            return false;
        
        registeredIdentities.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity)
    {
        return registeredIdentities.Any(x => x.Equals(identity));
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        var set = new HashSet<Identity>();
        set.Add(identityA);
        set.Add(identityB);
        return set.Count == 1;
    }
}

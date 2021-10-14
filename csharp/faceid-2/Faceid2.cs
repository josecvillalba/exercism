using System;
using System.Collections.Generic;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    
    public override bool Equals(object obj) => this.Equals(obj as FacialFeatures);

    public bool Equals(FacialFeatures f)
    {
        if (f is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (Object.ReferenceEquals(this, f))
        {
            return true;
        }

        // If run-time types are not exactly the same, return false.
        if (this.GetType() != f.GetType())
        {
            return false;
        }

        // Return true if the fields match.
        // Note that the base class is not invoked because it is
        // System.Object, which defines Equals as reference equality.
        return (EyeColor.Equals(f.EyeColor)) && (PhiltrumWidth.Equals(f.PhiltrumWidth));        
    }

    public override int GetHashCode() => HashCode.Combine(EyeColor,PhiltrumWidth);
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
    
    public override bool Equals(object obj) => this.Equals(obj as Identity);

    public bool Equals(Identity f)
    {
        if (f is null)
        {
            return false;
        }

        // Optimization for a common success case.
        if (Object.ReferenceEquals(this, f))
        {
            return true;
        }

        // If run-time types are not exactly the same, return false.
        if (this.GetType() != f.GetType())
        {
            return false;
        }

        // Return true if the fields match.
        // Note that the base class is not invoked because it is
        // System.Object, which defines Equals as reference equality.
        return (Email.Equals(f.Email)) && (FacialFeatures.Equals(f.FacialFeatures));        
    }

    public override int GetHashCode() => HashCode.Combine(Email,FacialFeatures);
    
}

public class Authenticator
{
    private readonly HashSet<Identity> identities = new HashSet<Identity>();
    private readonly Identity admin = new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return Equals(faceA, faceB);
    }

    public bool IsAdmin(Identity identity) => identity.Equals(admin);
    
    public bool Register(Identity identity) => identities.Add(identity);

    public bool IsRegistered(Identity identity) => identities.Contains(identity);

    public static bool AreSameObject(Identity identityA, Identity identityB) => identityA == identityB;

}

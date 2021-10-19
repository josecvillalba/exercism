using System.Collections.Generic;

public class Authenticator
{
    private class EyeColor
    {
        public string Blue = "blue";
        public string Green = "green";
        public string Brown = "brown";
        public string Hazel = "hazel";
        public string Brey = "grey";
    }

    private readonly Identity _admin;

    public Authenticator(Identity admin)
    {
        this._admin = admin;
    }

    private readonly IDictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };

    public Identity Admin => _admin;
    
    public IDictionary<string, Identity> GetDevelopers()
    {
        return developers;
    }
}

public struct Identity
{
    public string Email { get; init; }

    public string EyeColor { get; init; }
}

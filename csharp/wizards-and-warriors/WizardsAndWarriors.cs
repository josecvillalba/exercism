using System;

abstract class Character
{

    protected string CharacterType;
    
    protected Character(string characterType)
    {
        CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {CharacterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("TODO")
    {
        CharacterType = "Warrior";
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{

    private bool _spellPrepared = false;
    
    public Wizard() : base("TODO")
    {
        CharacterType = "Wizard";
    }

    public override int DamagePoints(Character target)
    {
        if (_spellPrepared)
        {
            return 12;
        }
        return 3;
    }
  
    public void PrepareSpell()
    {
        _spellPrepared = true;
    }
    
    public override bool Vulnerable()
    {
        return !_spellPrepared;
    }

}

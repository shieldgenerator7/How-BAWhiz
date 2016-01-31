using UnityEngine;
using System.Collections;

public class Spell
{
    public enum SpellType
    {
        Wand = 0,
        Potion = 1,
        Summon = 2
    }

    public enum SpellStatus
    {
        New,
        Physical,
        Verbal,
        Complete
    }

    private PhysicalComponent _Physical;

    public PhysicalComponent Physical
    {
        get
        {
            return _Physical;
        }
        set
        {
            _Physical = value;
        }
    }

    public VerbalComponent Verbal { get; set; }
    public SomaticComponent Somatic { get; set; }

    public SpellStatus Status
    {
        get
        {
            if (Physical == null)
            {
                return SpellStatus.New;
            }
            if (Verbal == null)
            {
                return SpellStatus.Physical;
            }
            if (Somatic == null)
            {
                return SpellStatus.Verbal;
            }
            return SpellStatus.Complete;
        }
    }

    public SpellType Type { get; set; }

    public void AddPhysicalComponent(PhysicalComponent phys)
    {
        Physical = phys;
    }

    public void AddVerbalComponent(VerbalComponent verbal)
    {
        Verbal = verbal;
    }

    public void AddSomaticComponent(SomaticComponent somatic)
    {
        Somatic = somatic;
    }
}
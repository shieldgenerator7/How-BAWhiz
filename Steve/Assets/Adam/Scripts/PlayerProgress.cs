
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerProgress
{

    private Spell _InProgressSpell;
    public Spell InProgressSpell
    {
        get { return _InProgressSpell ?? (_InProgressSpell = new Spell()); }
        set
        {
            _InProgressSpell = value;
        }
    }

    public List<Spell> CompletedSpells { get; set; }

    private PlayerProgress()
    {
        CompletedSpells = new List<Spell>();
    }

    private static PlayerProgress _Instance;
    public static PlayerProgress Instance
    {
        get { return _Instance ?? (_Instance = new PlayerProgress()); }
    }

    public void CompletePhysical(PhysicalComponent physComp)
    {
        InProgressSpell.Physical = physComp;
    }

    public void CompleteVerbal(VerbalComponent verbalComp)
    {
        InProgressSpell.Verbal = verbalComp;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SomaticStatus : ComponentStatus
	{
    public void Show()
    {
        GameObject sprite;
        switch (PlayerProgress.Instance.InProgressSpell.Status)
        {
            case Spell.SpellStatus.New:
            case Spell.SpellStatus.Physical:
                sprite = LockedSprite;
                break;

            case Spell.SpellStatus.Verbal:
                sprite = BeginSprite;
                break;

            default:
            case Spell.SpellStatus.Complete:
                sprite = ResultSprite;
                break;
        }
        Instantiate(sprite, transform.position, Quaternion.identity);
    }

    public override GameObject ResultSprite
    {
        get { throw new NotImplementedException(); }
    }
	}


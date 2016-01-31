using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PhysicalStatus : ComponentStatus
{
    public void Show()
    {
        GameObject sprite;
        switch (PlayerProgress.Instance.InProgressSpell.Status)
        {
            default:
                case Spell.SpellStatus.Physical:
                case Spell.SpellStatus.Verbal:
                case Spell.SpellStatus.Complete:
                sprite = ResultSprite;
                break;

            case Spell.SpellStatus.New:
                sprite = BeginSprite;
                break;
        }
        Instantiate(sprite, transform.position, Quaternion.identity);
    }

    public override GameObject ResultSprite
    {
        get { return PlayerProgress.Instance.InProgressSpell.Physical.Prefab; }
    }
}


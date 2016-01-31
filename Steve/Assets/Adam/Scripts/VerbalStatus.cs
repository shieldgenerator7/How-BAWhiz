
using UnityEngine;

public class VerbalStatus : ComponentStatus
{

    public void Show()
    {
        GameObject sprite;
        switch (PlayerProgress.Instance.InProgressSpell.Status)
        {
            case Spell.SpellStatus.New:
                sprite = LockedSprite;
                break;

            case Spell.SpellStatus.Physical:
                sprite = BeginSprite;
                break;
            
            default:
            case Spell.SpellStatus.Verbal:
            case Spell.SpellStatus.Complete:
                sprite = ResultSprite;
                break;
        }
        Instantiate(sprite, transform.position, Quaternion.identity);
    }

    public override GameObject ResultSprite
    {
        get { return PlayerProgress.Instance.InProgressSpell.Verbal.gameObject; }
    }
}

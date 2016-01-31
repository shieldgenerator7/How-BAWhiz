using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLessonScript : MonoBehaviour
{

    public Text TextArea;

	// Use this for initialization
	void Start ()
	{
	    loadText();
	}

    private void loadText()
    {
        string text;
        Spell.SpellType type = PlayerProgress.Instance.InProgressSpell.Type;
        switch (PlayerProgress.Instance.InProgressSpell.Status)
        {
            case Spell.SpellStatus.Physical:
                text = getVerbalText(type);
                break;

            case Spell.SpellStatus.Verbal:
                text = getSomaticText(type);
                break;

            case Spell.SpellStatus.Complete:
                text = getCompleteText(type);
                break;

            default:
                case Spell.SpellStatus.New:
                text = getNewText(type);
                break;
        }

        TextArea.text = text;
    }

    private string getNewText(Spell.SpellType type)
    {
        return "To make a wand, you will need a straight object and some magic dust.";
    }

    private string getCompleteText(Spell.SpellType type)
    {
        switch (type)
        {
            case Spell.SpellType.Wand:
                return "Somehow, you have managed to create a wand.";

            case Spell.SpellType.Potion:
                return "Err... I guess that would work. You drink it first.";

                case Spell.SpellType.Summon:
                return "Still alive? You are not a total failure after all!";
            default:
                return string.Empty;
        }
    }

    private string getSomaticText(Spell.SpellType type)
    {
        switch (type)
        {
            case Spell.SpellType.Wand:
                return "Now move your wand through the air, avoiding the hazardous magic energies but connecting with the centers of power.";

            case Spell.SpellType.Potion:
                return "Use your wand to magic that up a bit.";

            case Spell.SpellType.Summon:
                return "With your trusty wand, weave the spell to complete the summoning.";
            default:
                return string.Empty;
        }
    }

    private string getVerbalText(Spell.SpellType type)
    {
        switch (type)
        {
            case Spell.SpellType.Wand:
                return "Somehow, you have managed to create a wand. Now, choose three runes to empower it.";

            case Spell.SpellType.Potion:
                return "Eugh. Well, try adding some runes and see if that helps.";

            case Spell.SpellType.Summon:
                return "Where did you get that thing? Better run it by some runes just to be safe.";
            default:
                return string.Empty;
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}

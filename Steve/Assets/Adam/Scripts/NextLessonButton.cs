using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class NextLessonButton : MonoBehaviour {

    void OnMouseDown()
    {
        string levelToLoad;
        switch (PlayerProgress.Instance.InProgressSpell.Status)
        {
            case Spell.SpellStatus.New:
            default:
                /*PlayerProgress.Instance.InProgressSpell.Physical = gameObject.AddComponent<PhysicalComponent>();
                DontDestroyOnLoad(PlayerProgress.Instance.InProgressSpell.Physical);
                Debug.Log("Pretending to send to the cupboard");*/
                levelToLoad = "cupboard";
                break;

            case Spell.SpellStatus.Physical:
                levelToLoad = "Verbal";
                break;
                
                case Spell.SpellStatus.Verbal:
                levelToLoad = "Somatic";
                break;

                case Spell.SpellStatus.Complete:
                levelToLoad = "cupboard";
                Spell.SpellType completedSpell = PlayerProgress.Instance.InProgressSpell.Type;
                PlayerProgress.Instance.CompletedSpells.Add(PlayerProgress.Instance.InProgressSpell);
                if (completedSpell != Spell.SpellType.Summon)
                {
                    PlayerProgress.Instance.InProgressSpell = new Spell();
                    PlayerProgress.Instance.InProgressSpell.Type = (Spell.SpellType) ((int) completedSpell + 1);
                }
                else
                {
                    levelToLoad = "Final";
                }
                break;

        }

        SceneManager.LoadScene(levelToLoad);
    }
	
}

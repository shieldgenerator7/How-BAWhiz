
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VerbalComponent : MonoBehaviour
{
    public List<Rune> Runes;
    private List<RuneSlot> Slots; 

    void Start()
    {
        Slots = GetComponentsInChildren<RuneSlot>().ToList();
        foreach (var rune in Runes)
        {
            var runeObject = Instantiate(rune);
            var slot = Slots[Runes.IndexOf(rune)];
            runeObject.MoveTo(slot);
        }
    }
}
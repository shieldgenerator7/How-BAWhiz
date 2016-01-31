using UnityEngine;
using System.Collections;

public class RuneSlot : MonoBehaviour
{

    public bool IsSelected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeRune(Rune rune)
    {
        Rune = rune;
        rune.Slot = this;
    }

    public void RemoveRune()
    {
        Rune = null;
    }

    public Rune Rune { get; set; }
}

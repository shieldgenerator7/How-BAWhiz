using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class RuneGrid : MonoBehaviour
{
    public RuneInventory Inventory;
    private List<RuneSlot> Slots;
    private List<Rune> Runes;

	// Use this for initialization
	void Start () {
        Slots = GetComponentsInChildren<RuneSlot>().ToList();
	    Runes = GetComponentsInChildren<Rune>().ToList();
	    foreach (var rune in Runes)
	    {
	        rune.Grid = this;
	        rune.Inventory = Inventory;
            rune.MoveTo(Slots[Runes.IndexOf(rune)]);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReturnRune(Rune rune)
    {
        int index = Runes.IndexOf(rune);
        var gridSpot = Slots[index];

        rune.MoveTo(gridSpot);
    }
}

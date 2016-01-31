using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;
using System.Collections;

public class RuneInventory : MonoBehaviour
{
    public int Capacity = 3;
    private List<RuneSlot> Slots;

    public GameObject CompleteButton { get; set; }

    public VerbalComponent Verbal;

    // Use this for initialization
    void Start()
    {
        //Verbal = GetComponentInChildren<VerbalComponent>();
        Slots = GetComponentsInChildren<RuneSlot>().OrderBy(rs => rs.transform.position.x).ToList();
        foreach (var slot in Slots)
        {
            slot.IsSelected = true;
        }
        CompleteButton = GetComponentInChildren<EndVerbalButton>().gameObject;
        CompleteButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public bool AddRune(Rune rune)
    {
        var slot = Slots.FirstOrDefault(s => s.Rune == null);
        if (slot == null)
        {
            return false;
        }
        rune.MoveTo(slot);
        if (Slots.All(s => s.Rune != null))
        {
            CompleteButton.gameObject.SetActive(true);
            Verbal.Runes = Slots.Select(s => s.Rune).ToList();
            CompleteButton.GetComponent<EndVerbalButton>().Verbal = Verbal;
        }
        else
        {
            CompleteButton.gameObject.SetActive(false);
        }
        return true;
    }
}

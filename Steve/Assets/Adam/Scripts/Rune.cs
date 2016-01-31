using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Rune : MonoBehaviour
{
    public GameObject Prefab;

    public RuneSlot Slot;
    public RuneInventory Inventory;

    private bool Selected
    {
        get { return Slot.IsSelected; }
    }

    public RuneGrid Grid;

	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MoveTo(RuneSlot targetSlot)
    {
        this.transform.position = new Vector3(targetSlot.transform.position.x, targetSlot.transform.position.y, transform.position.z);
        if(Slot != null) Slot.RemoveRune();
        targetSlot.TakeRune(this);
    }

    void OnMouseDown()
    {
        if (!Selected)
        {
            Inventory.AddRune(this);
        }
        else
        {
            Grid.ReturnRune(this);
        }
    }
}

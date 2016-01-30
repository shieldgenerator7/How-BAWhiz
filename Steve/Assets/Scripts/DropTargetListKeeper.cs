using UnityEngine;
using System.Collections;

public class DropTargetListKeeper : MonoBehaviour {


    private ArrayList places = new ArrayList();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void addPlace(GameObject place)
    {
        places.Add(place);
    }
    public void removePlace(GameObject place)
    {
        places.Remove(place);
    }
    public GameObject canDropHere(Vector2 pos)
    {
        foreach (GameObject place in places)
        {
            if (place.GetComponent<DropTarget>().collides(pos))
            {
                return place;
            }
        }
        return null;
    }
    
}

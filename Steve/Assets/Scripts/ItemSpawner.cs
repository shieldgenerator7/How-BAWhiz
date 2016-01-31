using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {

    public ArrayList placesLeft;

	// Use this for initialization
	void Start () {
        DropTargetListKeeper dtlk = GetComponent<DropTargetListKeeper>();
        placesLeft = (ArrayList)dtlk.places.Clone();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject getRandomLocation()
    {
        int index = Random.Range(0, placesLeft.Count - 1);
        GameObject loc = (GameObject)placesLeft[index];
        placesLeft.RemoveAt(index);
        return loc;
    }
}

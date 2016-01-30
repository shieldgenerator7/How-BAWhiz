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

    public Vector3 getRandomPosition()
    {
        int index = Random.Range(0, placesLeft.Count - 1);
        Vector3 pos = ((GameObject)placesLeft[index]).transform.position;
        placesLeft.RemoveAt(index);
        return pos;
    }
}

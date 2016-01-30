using UnityEngine;
using System.Collections;

public class DropTarget : MonoBehaviour {

    public bool isSpawnPoint = true;
    public bool isDropTarget = true;

    private GameObject spawnPoint;
    private GameObject dropList;

    private SpriteRenderer sr;
    private BoxCollider2D bc;

	// Use this for initialization
	void Start ()
    {
        if (isSpawnPoint)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("SpawnPointList");
            spawnPoint.GetComponent<DropTargetListKeeper>().addPlace(this.gameObject);
        }
        if (isDropTarget)
        {
            dropList = GameObject.FindGameObjectWithTag("DropTargetList");
            dropList.GetComponent<DropTargetListKeeper>().addPlace(this.gameObject);
        }
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void accept(GameObject item)
    {
        item.transform.position = this.transform.position;
    }
    public bool collides(Vector2 pos)
    {
        Bounds bounds;
        if (sr != null)
        {
            bounds = sr.bounds;
        }
        else if (bc != null)
        {
            bounds = bc.bounds;
        }
        else
        {
            bounds = new Bounds();
            Debug.Log("DropTarget " + gameObject + " has no SpriteRenderer or BoxCollider!");
            return false;
        }
        if (pos.x > bounds.min.x && pos.x < bounds.max.x)
        {
            if (pos.y > bounds.min.y && pos.y < bounds.max.y)
            {
                return true;
            }
        }
        return false;
    }
}

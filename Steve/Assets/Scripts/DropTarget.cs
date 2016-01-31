using UnityEngine;
using System.Collections;

public class DropTarget : MonoBehaviour {

    public bool isSpawnPoint = true;
    public bool isDropTarget = true;
    public string itemRequirement1;
    public string itemRequirement2;

    ArrayList items = new ArrayList();

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
        items.Add(item);
        if (itemRequirement1 != null || itemRequirement2 != null)
        {
            checkItems();
        }
    }
    public void removeItem(GameObject item)
    {
        items.Remove(item);
    }
    private void checkItems()
    {
        if (items.Count >= 2)
        {
            bool fulfill1 = false;
            GameObject item1 = null;
            if (itemRequirement1 != null)
            {
                foreach (GameObject item in items)
                {
                    if (item.tag.Equals(itemRequirement1))
                    {
                        fulfill1 = true;
                        item1 = item;
                        break;//as long as one fulfills it, it's a go
                    }
                }
            }
            else
            {
                fulfill1 = true;
            }

            bool fulfill2 = false;
            GameObject item2 = null;
            if (itemRequirement2 != null)
            {
                foreach (GameObject item in items)
                {
                    if (item.tag.Equals(itemRequirement2))
                    {
                        fulfill2 = true;
                        item2 = item;
                        break;//as long as one fulfills it, it's a go
                    }
                }
            }
            else
            {
                fulfill2 = true;
            }

            if (fulfill1 && fulfill2)
            {
                craftObject(item1, item2);
            }
            else
            {
                craftingFailed();
            }
        }
        else if (itemRequirement2.Equals("self"))//is this drop target a pet
        {
            GameObject item = (GameObject)items[0];
            if (item.tag.Equals("item_potion"))
            {
                GameObject.Destroy(item);
                GameObject.FindGameObjectWithTag("popup_smiley").GetComponent<PopUpDisplayer>().popup(this.gameObject);
            }
            else
            {
                item.GetComponent<ItemManipulator>().eject();
            }
        }

    }
    private void craftObject(GameObject item, GameObject catalyst)
    {
        GetComponent<ItemCrafter>().craftItem(items, item, catalyst);
        items = new ArrayList();
    }
    private void craftingFailed()
    {
        //for(int i = items.Count - 1; i >= 0; i--) 
        //{
        //while (items.Count > 0)
        //{
        //   // ((GameObject)items[0]).GetComponent<ItemManipulator>().eject();
        //}
        //}
        GameObject.FindGameObjectWithTag("popup_noreaction").GetComponent<PopUpDisplayer>().popup(this.gameObject);
    }
    public bool collides(GameObject item, Vector2 pos)
    {
        if (item.Equals(this.gameObject))
        {
            return false;
        }
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

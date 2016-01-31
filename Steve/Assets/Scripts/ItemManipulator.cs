using UnityEngine;
using System.Collections;

public class ItemManipulator : MonoBehaviour {

    public GameObject inventoryBox;
    public GameObject upgradeObject;
    public bool isStartingItem = true;
    public bool alwaysInHand = false;

    private bool inInventory = false;
    private bool inHand = false;
    private Vector2 origMousePosition;
    private GameObject location;//which drop target they are in

	// Use this for initialization
	void Start () {
        if (isStartingItem)
        {
            ItemSpawner spawnList = GameObject.FindGameObjectWithTag("SpawnPointList").GetComponent<ItemSpawner>();
            location = spawnList.getRandomLocation();
            transform.position = location.transform.position;
            DropTarget dt = location.GetComponent<DropTarget>();
            if (dt != null)
            {
                dt.accept(this.gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            if ( ! alwaysInHand)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (collides(this.gameObject, mousePosition))
                {
                    inHand = true;
                    origMousePosition = mousePosition;
                    //if (!inInventory)
                    //{
                    //    inInventory = true;
                    //    inventoryBox.GetComponent<InventoryManager>().addItem(this.gameObject);
                    //}
                    //else
                    //{
                    //    inHand = true;
                    //}
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            if (!alwaysInHand)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //    if (collides(this.gameObject, mousePosition))
                //    {
                if (inHand)
                {
                    if (Vector2.Distance(origMousePosition, mousePosition) < 0.5f)
                    {
                        inHand = false;
                        detach();
                        inventoryBox.GetComponent<InventoryManager>().addItem(this.gameObject);
                        inInventory = true;
                    }
                    else {
                        GameObject target = inventoryBox.GetComponent<InventoryManager>().dropList.GetComponent<DropTargetListKeeper>().canDropHere(this.gameObject,mousePosition);
                        Debug.Log("target: " + target);
                        if (target != null)
                        {
                            detach();
                            target.GetComponent<DropTarget>().accept(this.gameObject);
                            location = target;
                            inHand = false;
                            inInventory = false;
                            inventoryBox.GetComponent<InventoryManager>().removeItem(this.gameObject);
                        }
                        else
                        {
                            detach();
                            inHand = false;
                            inventoryBox.GetComponent<InventoryManager>().addItem(this.gameObject);
                            inInventory = true;
                        }
                    }
                    //}
                }
                //GetComponent<SpriteRenderer>().flipX = ! GetComponent<SpriteRenderer>().flipX;
                //open = !open;
                //animator.SetBool("Open", open);
                //GetComponent<Rigidbody2D>().gravityScale = 1;
                //GetComponent<Rigidbody2D>().angularVelocity += rotation;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (inHand)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePosition.x, mousePosition.y);
                
            }
        }
        if (alwaysInHand)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y);

        }
    }

    /**
    * Tells its current place that it's no longer there
    */
    private void detach()
    {
        if (location != null)
        {
            DropTarget dt = location.GetComponent<DropTarget>();
            if (dt != null)
            {
                dt.removeItem(this.gameObject);
            }
            InventoryManager im = location.GetComponent<InventoryManager>();
            if (im != null)
            {
                im.removeItem(this.gameObject);
            }
        }
    }

    /**
    * Called when a drop target throws this item out
    */
    public void eject()
    {
        inHand = false;
        detach();
        inventoryBox.GetComponent<InventoryManager>().addItem(this.gameObject);
        inInventory = true;
    }

    public static bool collides(GameObject go, Vector2 pos)
    {
        Bounds bounds = go.GetComponent<SpriteRenderer>().bounds;
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

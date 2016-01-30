using UnityEngine;
using System.Collections;

public class ItemManipulator : MonoBehaviour {

    public GameObject inventoryBox;

    private bool inInventory = false;
    private bool inHand = false;

	// Use this for initialization
	void Start () {
        Canvas.
        DropTargetListKeeper spawnList = GameObject.FindGameObjectWithTag("SpawnPointList").GetComponent<DropTargetListKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (collides(this.gameObject, mousePosition))
            {
                if (!inInventory)
                {
                    inInventory = true;
                    inventoryBox.GetComponent<InventoryManager>().addItem(this.gameObject);
                }
                else
                {
                    inHand = true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (collides(this.gameObject, mousePosition))
            {
                if (inHand)
                {
                    GameObject target = inventoryBox.GetComponent<InventoryManager>().dropList.GetComponent<DropTargetListKeeper>().canDropHere(mousePosition);
                    if (target != null)
                    {
                        target.GetComponent<DropTarget>().accept(this.gameObject);
                        inHand = false;
                        inInventory = false;
                        inventoryBox.GetComponent<InventoryManager>().removeItem(this.gameObject);
                    }
                    else
                    {
                        inHand = false;
                        inventoryBox.GetComponent<InventoryManager>().organizeItems();
                        inInventory = true;
                    }
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

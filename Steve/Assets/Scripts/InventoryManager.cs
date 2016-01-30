using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    public GameObject dropList;

    private float buffer = 0.9f;
    private ArrayList items = new ArrayList();
    private SpriteRenderer spriteRer;
    private float nextX = -1;

	// Use this for initialization
	void Start () {
        spriteRer = GetComponent<SpriteRenderer>();
        Bounds bounds = spriteRer.bounds;
        nextX =  bounds.min.x + buffer;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public  void addItem(GameObject item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
        }
        Bounds bounds = spriteRer.bounds;
        float posx = nextX;
        float posy = transform.position.y;
        item.transform.position = new Vector3(posx, posy);
        SpriteRenderer itemRenderer = item.GetComponent<SpriteRenderer>();
        nextX += buffer + (itemRenderer.bounds.extents.x * 2);
        itemRenderer.sortingLayerName = "inUI";
        organizeItems();
    }
    public void removeItem(GameObject item)
    {
        items.Remove(item);
        SpriteRenderer itemRenderer = item.GetComponent<SpriteRenderer>();
        itemRenderer.sortingLayerName = "Default";
        organizeItems();
    }
    public void organizeItems()
    {
        float width = spriteRer.bounds.extents.x * 2;
        float collectiveWidth = 0;
        int limiter = 0;
        do
        {
            collectiveWidth = 0;
            int i = 0;
            foreach (GameObject item in items)
            {
                i++;
                if (i >= limiter)
                {
                    SpriteRenderer itemRenderer = item.GetComponent<SpriteRenderer>();
                    collectiveWidth += (itemRenderer.bounds.extents.x * 2);
                }
            }
            if (collectiveWidth > width)
            {
                limiter++;
            }
        }
        while (collectiveWidth > width);

        float buffer = (width - collectiveWidth) / (items.Count - limiter + 1);
        if (buffer > 1)
        {
            buffer = 1;
        }

        Bounds bounds = spriteRer.bounds;
        nextX = bounds.min.x + buffer;
        int j = 0;
        float posy = transform.position.y;
        foreach (GameObject item in items)
        {
            j++;
            if (j >= limiter)
            {
                SpriteRenderer itemRenderer = item.GetComponent<SpriteRenderer>();
                item.transform.position = new Vector3(nextX, posy);
                nextX += buffer + (itemRenderer.bounds.extents.x * 2);
            }
        }

    }
}

using UnityEngine;
using System.Collections;

public class ItemCrafter : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() { 
	}
    public void craftItem(ArrayList items)
    {
        GameObject result = null;
        foreach(GameObject item in items)
        {
            ItemManipulator im = item.GetComponent<ItemManipulator>();
            if (im != null)
            {
                if (im.upgradeObject != null)
                {
                    result = im.upgradeObject;
                    break;
                }
            }
        }
        result.transform.position = new Vector3(0, 0);
        result.GetComponent<ItemManipulator>().alwaysInHand = true;
        foreach (GameObject item in items)
        {
            GameObject.Destroy(item);
        }

    }
}

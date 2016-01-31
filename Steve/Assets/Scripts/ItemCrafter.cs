using UnityEngine;
using System.Collections;

public class ItemCrafter : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() { 
	}
    public void craftItem(ArrayList items, GameObject baseItem, GameObject catalyst, bool advanceScene)
    {
        GameObject result = null;
        //foreach(GameObject item in items)
        //{
        ItemManipulator im = baseItem.GetComponent<ItemManipulator>();
        if (im != null)
        {
            if (im.upgradeObject != null)
            {
                result = im.upgradeObject;
            }
            else
            {
                foreach (GameObject item in items)
                {
                    im = item.GetComponent<ItemManipulator>();
                    if (im != null)
                    {
                        if (im.upgradeObject != null)
                        {
                            result = im.upgradeObject;
                            break;
                        }
                    }
                }
            }
        }
        //}
        if (advanceScene)
        {
            if (result.tag.Equals("item_wand"))
            {
                result.transform.position = new Vector3(0, 0);
                result.GetComponent<ItemManipulator>().alwaysInHand = true;
                Cursor.visible = false;
            }
            else
            {
                result.transform.position = ((GameObject)items[0]).transform.position;
            }
            result.GetComponent<PhysicalComponent>().activateNextScene();
        }
        else
        {
            result.transform.position = ((GameObject)items[0]).transform.position;
        }
        GameObject.Destroy(baseItem);
        GameObject.Destroy(catalyst);

    }
}

using UnityEngine;
using System.Collections;

public class TargetSpawn : MonoBehaviour
{

    public Target TargetPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateTarget()
    {
        Instantiate(TargetPrefab, this.transform.position, Quaternion.identity);
    }
}

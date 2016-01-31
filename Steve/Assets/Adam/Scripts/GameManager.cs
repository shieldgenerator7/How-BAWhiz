using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject StartButton;
    public Wand Wand;

    public List<TargetSpawn> TargetSpawns;
    public List<HazardSpawn> HazardSpawns; 

	// Use this for initialization
	void Start ()
	{
	    TargetSpawns = GetComponentsInChildren<TargetSpawn>().ToList();
	    HazardSpawns = GetComponentsInChildren<HazardSpawn>().ToList();

        StartButton.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGestureGame()
    {  
        StartButton.SetActive(false);
        var wand = Instantiate(Wand);

        wand.transform.position = Camera.main.ScreenToWorldPoint(StartButton.transform.position);

        SpawnTargets();
        SpawnHazards();
    }

    private void SpawnTargets()
    {
        foreach (var spawn in TargetSpawns)
        {
            spawn.CreateTarget();
        }
    }

    private void SpawnHazards()
    {
        foreach (var spawn in HazardSpawns)
        {
            spawn.SpawnActivated = true;
        }
    }
}

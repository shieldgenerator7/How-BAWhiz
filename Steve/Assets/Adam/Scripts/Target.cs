using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{

    private TargetManager _Manager;

	// Use this for initialization
	void Start ()
	{
        _Manager = FindObjectOfType<TargetManager>();
        _Manager.RegisterTarget(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Score()
    {
        _Manager.SendMessage("ScoreTarget", this);
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour
{
    private List<Target> _Targets = new List<Target>();
    private Wand _Wand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RegisterWand(Wand wand)
    {
        _Wand = wand;
    }

    public void RegisterTarget(Target target)
    {
        _Targets.Add(target);
    }

    public void ScoreTarget(Target target)
    {
        _Targets.Remove(target);

        Destroy(target.gameObject);

        if (!_Targets.Any())
        {
            _Wand.End();
        }
    }
}

using UnityEngine;
using System.Collections;

public class doorAnimation : MonoBehaviour {

    public Animator animator;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("left"))
        {
            animator.SetTrigger("doorOpenTrigger");
        }
        if (Input.GetKeyDown("right"))
        {
            animator.SetTrigger("doorClosedTrigger");
        }

    }
}

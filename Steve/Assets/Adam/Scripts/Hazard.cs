using System;
using System.Security.Policy;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Hazard : MonoBehaviour
{

    public float TransverseVelocity = 80.0f;
    public float TransverseCycle = 1.0f;
    public float ForceVariance = 10.0f;

    private float lastForceChange = 0f;

    private Rigidbody2D _RigidBody;
    private Rigidbody2D RigidBody
    {
        get { return _RigidBody ?? (_RigidBody =  GetComponent<Rigidbody2D>()); }
        set { _RigidBody = value; }
    }

    private Vector2 HorizontalForce;

	// Use this for initialization
	void Start ()
	{
        HorizontalForce = new Vector2(TransverseVelocity, 0) + new Vector2(Random.value * ForceVariance, 0);
        RigidBody.AddForce(HorizontalForce * 0.5f);
        TransverseCycle = TransverseCycle + (Random.value * TransverseCycle);
        lastForceChange = Random.value * TransverseCycle;

        Destroy(this.gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	    lastForceChange += Time.deltaTime;

	    if (lastForceChange > TransverseCycle)
	    {
            HorizontalForce = new Vector2(HorizontalForce.x * -1, HorizontalForce.y);
	        RigidBody.AddForceAtPosition(HorizontalForce, transform.position);
	        lastForceChange = 0f;
	    }

	}
}

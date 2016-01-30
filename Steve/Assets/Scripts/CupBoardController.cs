using UnityEngine;
using System.Collections;

public class CupBoardController : MonoBehaviour {

    public Animator animator;
    public bool open = false;
    //public Camera camera;
    public float rotation;

	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
        }
        else if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (collides(this.gameObject, mousePosition))
            {
                //GetComponent<SpriteRenderer>().flipX = ! GetComponent<SpriteRenderer>().flipX;
                open = ! open;
                animator.SetBool("Open", open);
                Debug.Log(animator.GetBool("Open"));
                //Debug.Log(animator.stat);
                GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Rigidbody2D>().angularVelocity += rotation;
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

using UnityEngine;
using System.Collections;

public class PopUpDisplayer : MonoBehaviour {

    public float fadeInTime = 1f;
    public float showTime = 1f;
    public float fadeOutTime = 1f;

    private int stage = 0;
    private float tick = 0;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	if (stage == 1)
        {
            float sofar = Time.time - tick;
            float alpha = 255 * sofar / fadeInTime;
            //Debug.Log("Fading in: " + alpha);
            sr.color = new Color(alpha, alpha, alpha, alpha);
            if (sofar >= fadeInTime)
            {
                tick = 0;
                stage = 2;
            }
        }
    else if (stage == 2)
        {
            float sofar = Time.time - tick;
            if (sofar >= showTime)
            {
                tick = 0;
                stage = 3;
            }
        }
    else if (stage == 3)
        {
            float sofar = Time.time - tick;
            float alpha = 255 - (255 * sofar / fadeOutTime);
            //Debug.Log("Fading out: " + alpha);
            sr.color = new Color(alpha, alpha, alpha, alpha);
            if (sofar >= fadeOutTime)
            {
                tick = 0;
                stage = 0;
            }
        }
    }
    public void popup(GameObject client)
    {
        this.transform.position = client.transform.position;
        tick = Time.time;
        stage = 1;//fading in
    }
}

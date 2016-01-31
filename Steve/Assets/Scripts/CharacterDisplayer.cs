using UnityEngine;
using System.Collections;

public class CharacterDisplayer : MonoBehaviour {

    public GameObject icon;
    public GameObject nameTag;
    public string scriptName;

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}

    public void highlight(bool active)
    {
        float alpha = (active) ? 1.0f : 0.25f;
        icon.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
        nameTag.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, alpha);
    }
}

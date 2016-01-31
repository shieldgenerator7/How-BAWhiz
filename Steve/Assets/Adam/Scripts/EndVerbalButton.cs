
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class EndVerbalButton : MonoBehaviour
{

    public VerbalComponent Verbal;

    void OnMouseDown()
    {
        DontDestroyOnLoad(Verbal);
        foreach (var rune in Verbal.Runes)
        {
            DontDestroyOnLoad(rune);
        }

        PlayerProgress.Instance.CompleteVerbal(Verbal);
        SceneManager.LoadScene("LessonStatus");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Navigate(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Navigate(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }

    public void Quit()
    {
        Application.Quit();
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

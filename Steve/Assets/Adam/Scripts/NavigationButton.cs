using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class NavigationButton : MonoBehaviour
{
    public string SceneToLoad;

    void OnMouseDown()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class PhysicalComponent : MonoBehaviour
{
    public GameObject Prefab;

    void Start()
    {
        //var prefab = //Create();
        //prefab.transform.position = transform.position;
        
    }

    //public GameObject Create()
    //{
    //    return Instantiate(Prefab);
    //}

    public void activateNextScene()
    {
        this.gameObject.transform.SetParent(null);
        DontDestroyOnLoad(this);
        PlayerProgress.Instance.CompletePhysical(this);
        //GameObject.FindGameObjectWithTag("SceneContainer").SetActive(false);
        SceneManager.LoadScene("LessonStatus");
    }
}
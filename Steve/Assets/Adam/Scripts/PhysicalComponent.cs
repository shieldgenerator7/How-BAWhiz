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
        DontDestroyOnLoad(this);
        PlayerProgress.Instance.CompletePhysical(GetComponent<PhysicalComponent>());
        GameObject.FindGameObjectWithTag("SceneContainer").SetActive(false);
        SceneManager.LoadScene("LessonStatus", LoadSceneMode.Additive);
    }
}
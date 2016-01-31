using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class PhysicalComponent : MonoBehaviour
{
    public GameObject Prefab;

    void Start()
    {
        var prefab = Create();
        prefab.transform.position = transform.position;
    }

    public GameObject Create()
    {
        return Instantiate(Prefab);
    }

    void OnMouseDown()
    {
        DontDestroyOnLoad(this);
        PlayerProgress.Instance.CompletePhysical(GetComponent<PhysicalComponent>());
        SceneManager.LoadScene("LessonStatus", LoadSceneMode.Additive);
    }
}
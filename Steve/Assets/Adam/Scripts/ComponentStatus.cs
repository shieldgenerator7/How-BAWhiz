using UnityEngine;

public abstract class ComponentStatus : MonoBehaviour
{
    public GameObject BeginSprite;
    public abstract GameObject ResultSprite { get; }
    public GameObject LockedSprite;

    
}
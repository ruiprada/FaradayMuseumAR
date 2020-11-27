using UnityEngine;

public abstract class GUIControl : MonoBehaviour
{
    public abstract string Name { get; }

    void Awake()
    {
        GUIManager.Register(this);
    }

    void OnDestroy()
    {
        GUIManager.Unregister(this);
    }

    public virtual void OnShow()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnHide()
    {
        gameObject.SetActive(false);
    }
}
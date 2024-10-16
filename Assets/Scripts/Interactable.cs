using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private Outline outline;
    public string message;

    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public virtual void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        if (outline != null)
            outline.enabled = false;
    }

    public void EnableOutline()
    {   if (outline != null)
            outline.enabled = true;
    }
}

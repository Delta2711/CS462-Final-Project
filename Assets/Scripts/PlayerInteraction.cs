using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{   
    public float playerReach = 3f;
    Interactable currentInteractable = null;

    // Update is called once per frame
    void Update()
    {
        CheckInteraction();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach)) // check if the ray reaches the object.
        {
            if (hit.collider.tag == "Interactable") // make sure that the object being looked at is interactable.
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable) // check to make sure there are not two overlapping interactable items.
                {
                    DisableCurrentInteractable();
                }

                if (newInteractable.enabled) // check if the item interaction is enabled.
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HUDController.instance.EanableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {   
        HUDController.instance.DisableInteractionText();
        if (currentInteractable != null)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
        
    }
}

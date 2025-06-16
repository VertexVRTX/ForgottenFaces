using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float markerDuration = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractableUI[] interactables = FindObjectsOfType<InteractableUI>();

            foreach (var obj in interactables)
            {
                obj.ShowMarkerTemporarily(markerDuration);
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                InteractableUI interactable = hit.collider.GetComponent<InteractableUI>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}

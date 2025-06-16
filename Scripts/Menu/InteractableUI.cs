using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    public GameObject marker;
    private bool hasBeenInteracted = false;

    private void OnMouseDown()
    {
        if (UIManager.Instance != null && UIManager.Instance.IsPanelOpen)
            return;

        Interact();
    }

    public void ShowMarkerTemporarily(float duration)
    {
        if (hasBeenInteracted || marker == null)
            return;

        StartCoroutine(ShowMarkerCoroutine(duration));
    }

    private IEnumerator ShowMarkerCoroutine(float duration)
    {
        marker.SetActive(true);
        yield return new WaitForSeconds(duration);
        marker.SetActive(false);
    }

    public void Interact()
    {
        if (UIManager.Instance != null && UIManager.Instance.IsPanelOpen)
            return;

        if (!hasBeenInteracted)
        {
            hasBeenInteracted = true;
            if (marker != null)
                marker.SetActive(false);

            Debug.Log("Object Interacted: " + gameObject.name);
        }
    }

    public bool HasBeenInteracted()
    {
        return hasBeenInteracted;
    }
}

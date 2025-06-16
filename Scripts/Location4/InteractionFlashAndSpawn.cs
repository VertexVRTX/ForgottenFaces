using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFlashAndSpawn : MonoBehaviour
{
    public GameObject flashObject;
    public Animator flashAnimator;
    public string flashTriggerName = "FlashTrigger";
    
    public GameObject hiddenObject;

    public float flashDuration = 0.5f;

    private bool hasBeenClicked = false;

    void OnMouseDown()
    {
        if (hasBeenClicked) return;

        hasBeenClicked = true;
        
        if (flashObject != null)
        {
            flashObject.SetActive(true);
        }
        
        if (flashAnimator != null)
        {
            flashAnimator.SetTrigger(flashTriggerName);
        }
        
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(true);
        }
    }
}

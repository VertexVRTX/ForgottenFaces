using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagramSequenceManager : MonoBehaviour
{
     [Header("Objekt Pentagram")]
    public List<GameObject> pentagramObjects; 

    [Header("Player")]
    public MonoBehaviour playerMovementScript; 

    [Header("Dialog")]
    public DialogMan dialogMan;
    public string dialogueLine;

    [Header("Animacija")]
    public Animator flashAnimator; 
    public string flashTrigger = "Flash";

    [Header("Final Objekt")]
    public GameObject finalObject;

    private bool sequenceStarted = false;

    void Update()
    {
        if (!sequenceStarted && AllObjectsActive())
        {
            sequenceStarted = true;
            StartSequence();
        }
    }

    bool AllObjectsActive()
    {
        foreach (GameObject obj in pentagramObjects)
        {
            if (!obj.activeInHierarchy)
                return false;
        }
        return true;
    }

    void StartSequence()
    {
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }
        
        dialogMan.OnDialogueComplete += OnDialogueComplete;
        dialogMan.StartDialogue(dialogueLine);
    }

    void OnDialogueComplete()
    {
        dialogMan.OnDialogueComplete -= OnDialogueComplete;
        
        if (flashAnimator != null && !string.IsNullOrEmpty(flashTrigger))
        {
            flashAnimator.SetTrigger(flashTrigger);
        }

        StartCoroutine(WaitForFlashAndReveal());
    }

    IEnumerator WaitForFlashAndReveal()
    {
        yield return new WaitForSeconds(1.5f);
        
        if (finalObject != null)
        {
            finalObject.SetActive(true);
        }

        playerMovementScript.enabled = true;
    }
}

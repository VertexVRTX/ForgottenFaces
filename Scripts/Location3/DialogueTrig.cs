using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrig : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    private bool dialogueStarted = false;

    void OnMouseDown()
    {
        if (!dialogueStarted)
        {
            dialogueSystem.StartDialogue();
            dialogueStarted = true;
        }
    }
}

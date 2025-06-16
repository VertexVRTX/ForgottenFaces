using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogTri : MonoBehaviour
{
    public DialogMan dialogMan;
    public Button triggerButton;
    public string dialogueLine = "...";

    void Start()
    {
        if (triggerButton != null)
        {
            triggerButton.onClick.AddListener(TriggerDialogue);
        }
    }

    void TriggerDialogue()
    {
        if (dialogMan != null)
        {
            dialogMan.StartDialogue(dialogueLine);
        }

        if (triggerButton != null)
        {
            triggerButton.gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IntObject : MonoBehaviour
{
    [Header("UI & Dependencies")]
    public DialogMan dialogMan;
    public GameObject requiredItemUI;
    public GameObject hiddenIconUI;
    public GameObject replacementObject;
    public GameObject thisObjectToHide;

    [Header("Dialogue")]
    [TextArea] public string defaultDialogue;
    [TextArea] public string afterItemUsedDialogue;

    private bool itemUsed = false;

    private void OnMouseDown()
    {
        if (itemUsed)
        {
            dialogMan.StartDialogue(afterItemUsedDialogue);
            return;
        }

        if (requiredItemUI != null && requiredItemUI.activeSelf)
        {
            if (thisObjectToHide != null)
                thisObjectToHide.SetActive(false);

            if (replacementObject != null)
                replacementObject.SetActive(true);

            if (hiddenIconUI != null)
                hiddenIconUI.SetActive(true);

            if (requiredItemUI != null)
                requiredItemUI.SetActive(false);

            itemUsed = true;

            dialogMan.StartDialogue(afterItemUsedDialogue);
        }
        else
        {
            dialogMan.StartDialogue(defaultDialogue);
        }
    }
}

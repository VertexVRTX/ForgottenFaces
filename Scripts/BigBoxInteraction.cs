using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigBoxInteraction : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject closedBoxImage;
    public GameObject openBoxImage;

    public void OnBoxClick()
    {
        if (Inventory.hasKey)
        {
            if (closedBoxImage != null) closedBoxImage.SetActive(false);
            if (openBoxImage != null) openBoxImage.SetActive(true);

            if (dialogueText != null)
                dialogueText.gameObject.SetActive(false);
        }
        else
        {
            if (dialogueText != null)
            {
                dialogueText.text = "Closed.";
                dialogueText.gameObject.SetActive(true);
                CancelInvoke();
                Invoke("HideDialogue", 2f);
            }
        }
    }

    void HideDialogue()
    {
        if (dialogueText != null)
            dialogueText.gameObject.SetActive(false);
    }
}

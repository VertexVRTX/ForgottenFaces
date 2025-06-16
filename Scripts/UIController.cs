using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ComputerScreenUIController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject computerScreenUI;
    public string messageText;

    public void OnCheckButtonClick()
    {
        if (dialogueText != null)
        {
            dialogueText.text = messageText;
            dialogueText.gameObject.SetActive(true);
        }
    }

    public void OnCloseButtonClick()
    {
        if (computerScreenUI != null)
            computerScreenUI.SetActive(false);

        if (dialogueText != null)
        {
            dialogueText.text = "";
            dialogueText.gameObject.SetActive(false);
        }

        InteractionBlocker.IsUIOpen = false;
    }

    public void OpenWindow()
    {
        if (computerScreenUI != null)
        {
            computerScreenUI.SetActive(true);
            InteractionBlocker.IsUIOpen = true;
        }
    }
}

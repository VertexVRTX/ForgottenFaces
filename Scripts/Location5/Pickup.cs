using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Pickup : MonoBehaviour, IPointerClickHandler
{
    public GameObject IconUI;
    public string dialogueMessage = "...";
    public GameObject blockingPanel;

    private DialogMan dialogueManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogMan>();
        if (blockingPanel == null)
        {
            blockingPanel = GameObject.FindWithTag("BlockingPanelTag");
        }
    }

    private void OnMouseDown()
    {
        HandleClick();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HandleClick();
    }

    private void HandleClick()
    {
        if (blockingPanel != null && blockingPanel.activeSelf)
        {
            return;
        }

        Inventory.hasKey = true;

        if (IconUI != null)
            IconUI.SetActive(true);

        if (dialogueManager != null)
            dialogueManager.StartDialogue(dialogueMessage);

        Destroy(gameObject);
    }
}

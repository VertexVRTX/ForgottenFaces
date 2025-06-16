using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;
    public string dialogueMessage;

    private bool isDialogueActive = false;
    private bool explored = false;

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if (isDialogueActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);

                if (hitCollider == null || hitCollider.gameObject != gameObject)
                {
                    CloseDialogue();
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (InteractionBlocker.IsUIOpen)
            return;

        if (!explored)
        {
            explored = true;
            ExplorationManager.Instance.ObjectExplored();
        }
        
        OpenDialogue();
    }

    void OpenDialogue()
    {
        dialogueText.text = dialogueMessage;
        dialogueUI.SetActive(true);
        isDialogueActive = true;
    }

    void CloseDialogue()
    {
        dialogueUI.SetActive(false);
        isDialogueActive = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PictureInteraction : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject dialogImage;
    public TextMeshProUGUI dialogueText;

    [Header("Object to Activate")]
    public GameObject keyObject;

    [Header("Dialogue Settings")]
    [TextArea(2, 5)]
    public string[] dialogueLines;

    private int currentLineIndex = 0;
    private bool interactionFinished = false;

    private void OnMouseDown()
    {
        if (interactionFinished)
            return;

        if (dialogImage != null)
            dialogImage.SetActive(true);

        if (dialogueLines != null && dialogueLines.Length > 0)
        {
            if (currentLineIndex < dialogueLines.Length)
            {
                if (dialogueText != null)
                    dialogueText.text = dialogueLines[currentLineIndex];

                currentLineIndex++;
            }
            else
            {
                if (keyObject != null)
                    keyObject.SetActive(true);

                if (dialogueText != null)
                    dialogueText.text = "";

                if (dialogImage != null)
                    dialogImage.SetActive(false);

                gameObject.SetActive(false);
                interactionFinished = true;
            }
        }
    }
}

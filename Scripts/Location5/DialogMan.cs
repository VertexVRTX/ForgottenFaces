using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogMan : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    public float typingSpeed = 0.05f;
    public float displayDuration = 5f;

    public Action OnDialogueComplete;

    private Coroutine currentTypingCoroutine;
    private Coroutine hideCoroutine;

    public void StartDialogue(string line)
    {
        if (dialoguePanel == null || dialogueText == null)
            return;

        if (currentTypingCoroutine != null)
            StopCoroutine(currentTypingCoroutine);
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        dialoguePanel.SetActive(true);
        currentTypingCoroutine = StartCoroutine(TypeSentence(line));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }

        hideCoroutine = StartCoroutine(HideDialogueAfterDelay());
    }

    private IEnumerator HideDialogueAfterDelay()
    {
        yield return new WaitForSecondsRealtime(displayDuration);

        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        OnDialogueComplete?.Invoke();
    }
}

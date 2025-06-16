using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffectLoc4 : MonoBehaviour
{
    public TMP_Text dialogueText;
    public float typingSpeed = 0.05f;
    public float displayTime = 5f;

    private Coroutine typingCoroutine;

    public void StartTyping(string message)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        gameObject.SetActive(true);
        typingCoroutine = StartCoroutine(TypeText(message));
    }

    private IEnumerator TypeText(string message)
    {
        dialogueText.text = "";
        foreach (char letter in message)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}

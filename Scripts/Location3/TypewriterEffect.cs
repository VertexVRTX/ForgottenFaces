using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text targetText;
    public float typeSpeed = 0.05f;

    private Coroutine typingCoroutine;

    public void StartTyping(string fullText)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(fullText));
    }

    private IEnumerator TypeText(string textToType)
    {
        targetText.text = "";

        foreach (char c in textToType)
        {
            targetText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }
}

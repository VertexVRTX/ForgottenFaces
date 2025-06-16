using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    public TMP_Text outputTextName;
    public TMP_Text outputTextPassword;
    public float typingSpeed = 0.04f;
    public GameObject continueButton;

    private Coroutine typingCoroutine;

    public void StartTyping(string target, string text)
    {
        TMP_Text targetText = null;

        if (target == "name") targetText = outputTextName;
        else if (target == "password") targetText = outputTextPassword;

        if (targetText != null)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeText(targetText, text));
        }
        else
        {
            Debug.LogWarning("Target text is null or invalid target: " + target);
        }
    }

    private IEnumerator TypeText(TMP_Text textComponent, string fullText)
    {
        textComponent.text = "";
        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (continueButton != null)
            continueButton.SetActive(true);
    }
}

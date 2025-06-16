using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerLoc4 : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string dialogueString = "There is something behind the objects. We should try to push them apart.";
    public float typingSpeed = 0.05f;
    public float displayTime = 5f;

    private Coroutine typingCoroutine;

    public void ShowDialogue()
    {
        gameObject.SetActive(true);
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeSentence());
    }

    private IEnumerator TypeSentence()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueString)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(displayTime);
        gameObject.SetActive(false);
    }
}

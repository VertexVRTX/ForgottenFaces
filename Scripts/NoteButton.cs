using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteButton : MonoBehaviour
{
    public string textToShow;
    public string targetField;

    private bool alreadyUsed = false;
    private TypingEffect typingEffect;

    void Start()
    {
        typingEffect = FindObjectOfType<TypingEffect>();

        if (typingEffect == null)
        {
            Debug.LogError("TypingEffect not found in scene!");
            return;
        }

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (alreadyUsed || typingEffect == null) return;

        typingEffect.StartTyping(targetField, textToShow);
        alreadyUsed = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public TMP_Text dialogText; 
    public Button dialogButton;
    public string fullText; 
    public float typingSpeed = 0.05f; 

    private Coroutine typingCoroutine;
    private bool hasShownDialog = false;

    void Start()
    {
        dialogText.text = "";
        dialogText.gameObject.SetActive(false);

        dialogButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        if (hasShownDialog) return;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(ShowDialog());
    }

    IEnumerator ShowDialog()
    {
        hasShownDialog = true;
        dialogButton.gameObject.SetActive(false);
        dialogText.gameObject.SetActive(true);
        dialogText.text = "";

        foreach (char c in fullText)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(4f);

        dialogText.gameObject.SetActive(false);
    }
}

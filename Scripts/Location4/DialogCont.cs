using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogCont : MonoBehaviour
{
    
    [Header("UI References")]
    public GameObject dialogPanel; 
    public TMP_Text dialogText;
    public string fullText;
    public float typingSpeed = 0.05f;
    public float dialogDuration = 4f;

    private bool isDialogActive = false;

    void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void ShowDialog()
    {
        if (isDialogActive) return;
        StartCoroutine(ShowDialogCoroutine());
    }

    IEnumerator ShowDialogCoroutine()
    {
        isDialogActive = true;
        dialogPanel.SetActive(true);
        dialogText.text = "";
        
        foreach (char c in fullText)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        
        float typingTime = fullText.Length * typingSpeed;
        float remainingTime = Mathf.Max(0f, dialogDuration - typingTime);
        yield return new WaitForSeconds(remainingTime);

        dialogPanel.SetActive(false);
        isDialogActive = false;
    }
}

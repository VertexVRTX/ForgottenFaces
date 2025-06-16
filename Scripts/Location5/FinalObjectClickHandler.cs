using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalObjectClickHandler : MonoBehaviour
{
    [Header("FinalPanel")]
    public GameObject canvasPanel;

    [Header("ScarryPanel")]
    public GameObject screamerPanel;

    [Header("Settings")]
    public float screamerDuration = 2f;

    private bool clicked = false;

    private void OnMouseDown()
    {
        if (clicked) return;
        clicked = true;

        StartCoroutine(ShowScreamerThenPanel());
    }

    private IEnumerator ShowScreamerThenPanel()
    {
        if (screamerPanel != null)
            screamerPanel.SetActive(true);
        
        yield return new WaitForSeconds(screamerDuration);
        
        if (screamerPanel != null)
            screamerPanel.SetActive(false);
        
        if (canvasPanel != null)
            canvasPanel.SetActive(true);
    }
}

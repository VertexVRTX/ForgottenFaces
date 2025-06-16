using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogM : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogTextUI;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private float displayTime = 4f;

    [SerializeField] private TypewriterEffectLoc4 typewriterEffect;

    public void ShowDialog(string text)
    {
        if (dialogPanel != null && dialogTextUI != null)
        {
            dialogPanel.SetActive(true);
            typewriterEffect.StartTyping(text);

            StopAllCoroutines();
            StartCoroutine(HideDialogAfterDelay());
        }
    }

    private IEnumerator HideDialogAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        dialogPanel.SetActive(false);
    }
}

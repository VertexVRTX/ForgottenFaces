using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CanvasPentagramPair
{
    public GameObject canvasIcon;
    public GameObject pentagramEffect;
}

public class PentagramClickHandler : MonoBehaviour
{
    [Header("Dialogue")]
    public DialogMan dialogMan;
    public string dialogueLine;

    [Header("UI")]
    public List<CanvasPentagramPair> iconEffectPairs;
    
    [Header("Panel")]
    public List<GameObject> blockingPanels;

    private bool firstClickDone = false;
    private bool isDialogPlaying = false;

    private void OnMouseDown()
    {
        if (IsBlockedByPanel()) return;

        if (!firstClickDone && !isDialogPlaying)
        {
            isDialogPlaying = true;
            dialogMan.OnDialogueComplete += OnDialogueComplete;
            dialogMan.StartDialogue(dialogueLine);
        }
        else if (firstClickDone)
        {
            foreach (CanvasPentagramPair pair in iconEffectPairs)
            {
                if (pair.canvasIcon != null && pair.canvasIcon.activeSelf)
                {
                    pair.canvasIcon.SetActive(false);

                    if (pair.pentagramEffect != null)
                    {
                        pair.pentagramEffect.SetActive(true);
                    }

                    break;
                }
            }
        }
    }

    private bool IsBlockedByPanel()
    {
        foreach (GameObject panel in blockingPanels)
        {
            if (panel != null && panel.activeInHierarchy)
                return true;
        }
        return false;
    }

    private void OnDialogueComplete()
    {
        dialogMan.OnDialogueComplete -= OnDialogueComplete;
        firstClickDone = true;
        isDialogPlaying = false;
    }
}

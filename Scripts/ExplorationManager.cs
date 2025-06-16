using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExplorationManager : MonoBehaviour
{
    public static ExplorationManager Instance;
    public int totalObjectsToExplore = 4;

    private int explored = 0;
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    public void ObjectExplored()
    {
        explored++;

        if (AllExplored())
        {
            ShowDialogue("It looks like I found everything I needed and I can go back to the computer.");
        }
    }

    public bool AllExplored()
    {
        return explored >= totalObjectsToExplore;
    }

    private void ShowDialogue(string message)
    {
        if (dialoguePanel != null && dialogueText != null)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = message;
            StartCoroutine(HideDialogueAfterDelay(2f));
        }
        else
        {
            Debug.Log(message);
        }
    }

    private IEnumerator HideDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerNotesController : MonoBehaviour
{
    public GameObject computerScreenUI;
    
    public GameObject notesPanel;

    private bool isUIOpen = false;

    private void OnEnable()
    {
        UpdateNotesVisibility();
    }

    public void OpenComputerWindow()
    {
        computerScreenUI.SetActive(true);
        isUIOpen = true;
        UpdateNotesVisibility();
    }

    public void CloseComputerWindow()
    {
        computerScreenUI.SetActive(false);
        isUIOpen = false;
        notesPanel.SetActive(false);
    }

    private void UpdateNotesVisibility()
    {
        if (ExplorationManager.Instance != null && ExplorationManager.Instance.AllExplored())
        {
            notesPanel.SetActive(true);
        }
        else
        {
            notesPanel.SetActive(false);
        }
    }
}

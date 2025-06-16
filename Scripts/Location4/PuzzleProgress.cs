using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleProgress : MonoBehaviour
{
    [SerializeField] private int requiredCount = 6;
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DialogM dialogManager;
    [TextArea] public string completionDialogText = "It seems the grate in the fireplace has opened.";

    private int placedCount = 0;
    private bool isCompleted = false;

    public void RegisterFragmentPlaced()
    {
        if (isCompleted) return;

        placedCount++;

        if (placedCount >= requiredCount)
        {
            isCompleted = true;
            CompletePuzzle();
        }
    }

    private void CompletePuzzle()
    {
        if (puzzleWindow != null)
        {
            puzzleWindow.SetActive(false);
        }
        
        if (dialogManager != null)
        {
            dialogManager.ShowDialog(completionDialogText);
        }
        
    }
}

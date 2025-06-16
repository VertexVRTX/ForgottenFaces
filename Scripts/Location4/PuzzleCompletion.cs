using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompletion : MonoBehaviour
{
    public Slot[] slots;
    public GameObject puzzleWindow;
    public DialogM dialogManager;
    public GameObject gridObject;
    public GameObject objectToAppear;
    [TextArea] public string completionDialogText = "It seems the grate in the fireplace has opened.";

    private bool isCompleted = false;
    [SerializeField] private PlayerMovement playerController;

    private void Update()
    {
        if (isCompleted) return;

        bool allFilled = true;
        foreach (Slot slot in slots)
        {
            if (!slot.IsFilled())
            {
                allFilled = false;
                break;
            }
        }

        if (allFilled)
        {
            isCompleted = true;
            CompletePuzzle();
        }
    }

    private void CompletePuzzle()
    {
        if (puzzleWindow != null)
            puzzleWindow.SetActive(false);

        if (gridObject != null)
            gridObject.SetActive(false);

        if (objectToAppear != null)
            objectToAppear.SetActive(true);
        
        if (playerController != null)
            playerController.enabled = true;

        if (dialogManager != null)
            dialogManager.ShowDialog(completionDialogText);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOnClick : MonoBehaviour
{
    [SerializeField] private DialogM dialogManager;
    [SerializeField] private ProgressTracker progressTracker;

    [TextArea] public string dialogText = "...";

    private bool hasBeenClicked = false;

    private void OnMouseDown()
    {
        if (hasBeenClicked) return;

        if (dialogManager != null)
        {
            dialogManager.ShowDialog(dialogText);
            hasBeenClicked = true;

            if (progressTracker != null)
            {
                progressTracker.RegisterExploration();
            }
        }
    }
}

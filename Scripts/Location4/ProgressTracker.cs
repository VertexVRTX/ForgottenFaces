using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    [SerializeField] private int requiredCount = 5;
    [SerializeField] private DialogM dialogManager;
    [TextArea] public string finalDialogText = "I think I found all the fragments.";
    [SerializeField] private GameObject secretObject;

    private int exploredCount = 0;
    private bool isUnlocked = false;

    public void RegisterExploration()
    {
        if (isUnlocked) return;

        exploredCount++;
        Debug.Log("Объект исследован! Всего исследовано: " + exploredCount);

        if (exploredCount >= requiredCount)
        {
            isUnlocked = true;
            if (dialogManager != null)
            {
                dialogManager.ShowDialog(finalDialogText);
            }

            if (secretObject != null)
            {
                secretObject.SetActive(true);
            }
        }
    }
}

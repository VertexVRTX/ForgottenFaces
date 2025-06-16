using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CloseWindow : MonoBehaviour
{
    public GameObject targetWindow;
    public GameObject dialogBox;
    public BoxInt boxScript;
    public TMP_Text dialogText;
    public GameObject boxObject;

    public void Close()
    {
        if (targetWindow != null)
            targetWindow.SetActive(false);

        if (dialogBox != null)
        {
            dialogBox.SetActive(true);
            if (dialogText != null)
                dialogText.text = "The key is in the box by the table...";
            
            if (boxScript != null)
                boxScript.EnableInteraction();
        }
    }
    
    public void OnDialogClicked()
    {
        if (dialogBox != null)
            dialogBox.SetActive(false);

        if (boxObject != null)
            boxObject.SetActive(true);
    }
}

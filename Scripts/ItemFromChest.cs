using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemFromChest : MonoBehaviour
{
    public GameObject openedChest;
    public GameObject emptyChest;
    public GameObject itemUI;
    public GameObject dialogBox; 
    public TMP_Text dialogText;

    private bool itemTaken = false;

    private void OnMouseDown()
    {
        if (itemTaken) return;
        
        if (openedChest != null) openedChest.SetActive(false);
        if (emptyChest != null) emptyChest.SetActive(true);
        
        if (itemUI != null) itemUI.SetActive(true);
        
        if (dialogBox != null)
        {
            dialogBox.SetActive(true);
            if (dialogText != null)
                dialogText.text = "Strange mask. It was described in the computer records. We need to examine it.";
        }

        itemTaken = true;
    }
    
    public void OnDialogClick()
    {
        if (dialogBox != null)
            dialogBox.SetActive(false);
    }
}

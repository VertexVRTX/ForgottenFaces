using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject closedChest;
    public GameObject openedChest;
    public GameObject keyUI;

    private bool isOpened = false;

    private void OnMouseDown()
    {
        if (isOpened) return;

        if (keyUI != null && keyUI.activeSelf)
        {
            if (closedChest != null)
                closedChest.SetActive(false);

            if (openedChest != null)
                openedChest.SetActive(true);
            
            keyUI.SetActive(false);

            isOpened = true;
        }
        else
        {
            
        }
    }
}

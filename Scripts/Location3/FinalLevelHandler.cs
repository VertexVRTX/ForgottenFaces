using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject finalLevelUI;
    public GameObject inventoryPanel; 
    public int finalLevelIndex = 4;

    private bool hasActivated = false;

    void Start()
    {
        if (finalLevelUI != null)
            finalLevelUI.SetActive(false);
    }

    public void OnLevelEntered(int level)
    {
        if (level == finalLevelIndex && !hasActivated)
        {
            hasActivated = true;
            
            if (player != null)
                player.SetActive(false);
            
            if (inventoryPanel != null)
                inventoryPanel.SetActive(false);
            
            if (finalLevelUI != null)
                finalLevelUI.SetActive(true);
        }
    }
}

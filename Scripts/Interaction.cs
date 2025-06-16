using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerInteraction : MonoBehaviour
{
    public ComputerScreenUIController screenController;
    private bool explored = false;

    private void OnMouseDown()
    {
        if (InteractionBlocker.IsUIOpen)
            return;

        if (!explored)
        {
            explored = true;
            ExplorationManager.Instance.ObjectExplored();
        }
        
        if (InteractionBlocker.IsUIOpen)
            return;

        screenController.OpenWindow();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonHandler : MonoBehaviour
{
    public GameObject puzzleWindow;
    public PlayerMovement playerMovement;

    public void CloseWindow()
    {
        if (puzzleWindow != null)
        {
            puzzleWindow.SetActive(false);
        }

        if (playerMovement != null)
        {
            playerMovement.canMove = true;
        }
    }
}

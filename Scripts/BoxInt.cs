using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxInt : MonoBehaviour
{
    public GameObject dialogBox;
    public TMPro.TMP_Text dialogText;
    public GameObject keyUI;

    private bool canInteract = false;
    private bool waitingForClick = false;

    public void EnableInteraction()
    {
        canInteract = true;
    }

    private void OnMouseDown()
    {
        if (!canInteract || waitingForClick) return;

        if (dialogBox != null)
        {
            dialogBox.SetActive(true);
            dialogText.text = "Key. I think it's from the desk drawer.";
            waitingForClick = true;
        }

        gameObject.SetActive(false);
    }

    public void OnDialogClick()
    {
        if (!waitingForClick) return;

        dialogBox.SetActive(false);

        if (keyUI != null)
            keyUI.SetActive(true);

        waitingForClick = false;
    }
}

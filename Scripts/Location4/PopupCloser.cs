using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupCloser : MonoBehaviour
{
    [SerializeField] private GameObject popupWindow;
    [SerializeField] private PlayerMovement playerController;
    [SerializeField] private PopupTrigger popupTrigger;
    [SerializeField] private DialogM dialogManager;

    [TextArea] public string exitDialogText = "...";

    public void ClosePopup()
    {
        if (popupWindow != null)
        {
            popupWindow.SetActive(false);

            if (playerController != null)
                playerController.enabled = true;

            if (popupTrigger != null)
                popupTrigger.MarkAsUsed();
            
            PopupTrigger.ClosePopupForAll();

            if (dialogManager != null)
                dialogManager.ShowDialog(exitDialogText);
        }
    }
}

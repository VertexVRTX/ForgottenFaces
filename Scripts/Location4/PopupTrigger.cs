using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject popupWindow;
    [SerializeField] private PlayerMovement playerController;
    [SerializeField] private DialogM dialogManager;
    [SerializeField] private ProgressTracker progressTracker;

    [TextArea] public string entryDialogText = "...";

    private bool isUsed = false;
    private static bool isPopupOpen = false;

    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    
    private void OnEnable()
    {
        isPopupOpen = false;
    }
    private void Start()
    {
        if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            canvas.worldCamera = Camera.main;
        }

        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerMovement>();
        }
    }

    private void OnMouseDown()
    {
        if (isUsed) return;
        if (isPopupOpen) return;

        if (popupWindow != null)
        {
            popupWindow.SetActive(true);
            isPopupOpen = true;

            if (playerController != null)
                playerController.enabled = false;

            if (dialogManager != null)
                dialogManager.ShowDialog(entryDialogText);

            if (progressTracker != null)
                progressTracker.RegisterExploration();
        }
    }

    public void MarkAsUsed()
    {
        isUsed = true;
    }

    public static void ClosePopupForAll()
    {
        isPopupOpen = false;
    }
}

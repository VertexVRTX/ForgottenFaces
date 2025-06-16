using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BigItemViewer : MonoBehaviour
{
    public GameObject itemWindow;
    public GameObject itemIconButton;
    public GameObject dialogBox;
    public TMP_Text dialogText;

    public Animator fadeAnimator;

    private bool hasShownDialog = false;
    private bool readyForSceneChange = false;

    public void OpenItemWindow()
    {
        if (itemWindow != null)
            itemWindow.SetActive(true);

        if (itemIconButton != null)
            itemIconButton.SetActive(false);
    }

    public void OnBigItemClick()
    {
        if (!hasShownDialog)
        {
            ShowDialog();
        }
        else if (readyForSceneChange)
        {
            StartSceneTransition();
        }
    }

    void ShowDialog()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(true);
            if (dialogText != null)
                dialogText.text = "It gives a strange feeling. The notes say that it should be put on...";
        }

        hasShownDialog = true;
        readyForSceneChange = true;
    }

    public void CloseDialog()
    {
        if (dialogBox != null)
            dialogBox.SetActive(false);
    }

    void StartSceneTransition()
    {
        if (fadeAnimator != null)
            fadeAnimator.SetTrigger("FadeIn");
        
    }

    void LoadNextScene()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public GameObject dialogPanel;
    public TextMeshProUGUI dialogText;

    private bool isDialogActive = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (isDialogActive && Input.GetMouseButtonDown(0))
        {
            HideDialog();
        }
    }

    public void ShowDialog(string message)
    {
        dialogText.text = message;
        dialogPanel.SetActive(true);
        isDialogActive = true;
    }

    public void HideDialog()
    {
        dialogPanel.SetActive(false);
        isDialogActive = false;
    }

    public bool IsDialogActive()
    {
        return isDialogActive;
    }
}

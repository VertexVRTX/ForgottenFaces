using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LocationUIManager : MonoBehaviour
{
    public GameObject enterPanel;
    public Button closePanelButton;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    
    [TextArea(2, 5)]
    [SerializeField] private string dialogueMessage = "I need to explore the office.";

    private bool dialogueActive = false;

    void Start()
    {
        enterPanel.SetActive(true);
        dialoguePanel.SetActive(false);

        closePanelButton.onClick.AddListener(CloseEnterPanel);
    }

    void Update()
    {
        if (dialogueActive && Input.GetMouseButtonDown(0))
        {
            dialoguePanel.SetActive(false);
            dialogueActive = false;
        }
    }

    void CloseEnterPanel()
    {
        enterPanel.SetActive(false);
        ShowDialogue(dialogueMessage);
    }

    void ShowDialogue(string message)
    {
        dialogueText.text = message;
        dialoguePanel.SetActive(true);
        dialogueActive = true;
    }
}

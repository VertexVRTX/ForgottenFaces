using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotesUIController : MonoBehaviour
{
    public TMP_Text nameText;
    public GameObject choicesPanel;
    public TMP_Text selectedChoiceText;
    
    public Button noteButtonPrefab;
    public Transform notesContentParent;

    private string[] notes = new string[] {
        "Note 1: Something important...",
        "Note 2: Other information..."
    };

    private string[] choices = new string[] {
        "2B49S", "MILK", "WATER", "OIL", "CHEESE"
    };

    private void Start()
    {
        nameText.text = "";
        choicesPanel.SetActive(false);

        foreach (var note in notes)
        {
            var btn = Instantiate(noteButtonPrefab, notesContentParent);
            btn.GetComponentInChildren<TMP_Text>().text = note;
            btn.onClick.AddListener(() => OnNoteClicked(note));
        }
    }

    private void OnNoteClicked(string note)
    {
        nameText.text = "Elijah Vance";
        choicesPanel.SetActive(true);
        selectedChoiceText.text = "Select an option:";
    }

    public void OnChoiceClicked(string choice)
    {
        selectedChoiceText.text = $"{choice}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject currentPanel;
    private PlayerMovement player;

    public bool IsPointerOverUI => EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    public bool IsPanelOpen => currentPanel != null;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    void Start()
    {
        TryFindPlayer();
    }

    private void TryFindPlayer()
    {
        if (player == null)
            player = FindObjectOfType<PlayerMovement>();
    }

    public void ShowPanel(GameObject panel)
    {
        if (currentPanel != null || panel == null) return;

        TryFindPlayer();

        currentPanel = panel;
        panel.SetActive(true);

        StartCoroutine(DelayedShowDialogue(panel));

        if (player != null)
            player.canMove = false;

        Time.timeScale = 0f;
    }

    private System.Collections.IEnumerator DelayedShowDialogue(GameObject panel)
    {
        yield return null;

        var dialogue = panel.GetComponent<DialogMan>();
        if (dialogue != null)
            dialogue.StartDialogue("");
    }

    public void ClosePanel()
    {
        if (currentPanel == null) return;

        currentPanel.SetActive(false);
        currentPanel = null;

        if (player != null)
            player.canMove = true;

        Time.timeScale = 1f;
    }

    public void CloseThisPanel()
    {
        ClosePanel();
    }
}

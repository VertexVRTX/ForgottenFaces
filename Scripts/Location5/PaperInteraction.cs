using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteraction : MonoBehaviour
{
    public GameObject paper;
    public GameObject panel; 
    public GameObject table;
    public GameObject[] otherPanels;

    private bool paperUsed = false;

    void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        if (IsAnyOtherPanelOpen()) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                if (!paperUsed && hit.collider.gameObject == paper)
                {
                    paper.SetActive(false);
                    panel.SetActive(true);
                    paperUsed = true;
                }
                else if (paperUsed && hit.collider.gameObject == table)
                {
                    panel.SetActive(true);
                }
            }
        }
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    private bool IsAnyOtherPanelOpen()
    {
        foreach (var p in otherPanels)
        {
            if (p.activeInHierarchy)
                return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour
{
    public GameObject panelToShow;
    private bool panelOpened = false;
    private HoverHighlight hoverHighlight;

    private void Start()
    {
        hoverHighlight = GetComponent<HoverHighlight>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (UIManager.Instance.IsPanelOpen) return;
        if (panelOpened) return;

        panelOpened = true;

        if (panelToShow != null)
        {
            UIManager.Instance.ShowPanel(panelToShow);

            if (hoverHighlight != null)
                hoverHighlight.enabled = false;
        }
    }
}

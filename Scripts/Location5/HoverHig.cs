using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverHig : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color highlightColor = Color.white;

    private bool clicked = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void OnMouseEnter()
    {
        if (!clicked && !UIManager.Instance.IsPanelOpen)
            spriteRenderer.color = highlightColor;
    }

    void OnMouseExit()
    {
        if (!clicked && !UIManager.Instance.IsPanelOpen)
            spriteRenderer.color = originalColor;
    }

    void OnMouseDown()
    {
        if (!UIManager.Instance.IsPanelOpen)
        {
            spriteRenderer.color = originalColor;
            clicked = true;
        }
    }
}

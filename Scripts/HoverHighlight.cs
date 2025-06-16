using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverHighlight : MonoBehaviour
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
        if (!clicked) 
            spriteRenderer.color = highlightColor;
    }

    void OnMouseExit()
    {
        if (!clicked)
            spriteRenderer.color = originalColor;
    }

    void OnMouseDown()
    {
        spriteRenderer.color = originalColor;
        clicked = true;
    }
}

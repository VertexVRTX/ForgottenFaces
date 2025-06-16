using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnMouseOver : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color highlightColor = Color.gray;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

        if (hitCollider != null && hitCollider.gameObject == gameObject)
        {
            spriteRenderer.color = highlightColor;
        }
        else
        {
            spriteRenderer.color = originalColor;
        }
    }
}

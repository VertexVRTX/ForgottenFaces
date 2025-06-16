using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HorizontalMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    private Vector2 offset;
    
    [SerializeField] private RectTransform movementBounds;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out offset);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint))
        {
            Vector2 newAnchoredPos = new Vector2(localPoint.x, rectTransform.anchoredPosition.y);
            
            newAnchoredPos = ClampToBounds(newAnchoredPos);

            rectTransform.anchoredPosition = newAnchoredPos;
        }
    }

    private Vector2 ClampToBounds(Vector2 position)
    {
        if (movementBounds == null)
        {
            return position;
        }
        
        Vector2 minBounds = movementBounds.rect.min;
        Vector2 maxBounds = movementBounds.rect.max;
        
        float halfWidth = rectTransform.rect.width * rectTransform.pivot.x;

        float clampedX = Mathf.Clamp(position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);

        return new Vector2(clampedX, position.y);
    }
}

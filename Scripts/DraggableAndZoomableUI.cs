using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableZoomableNote : MonoBehaviour, IPointerDownHandler, IDragHandler, IScrollHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    
    public float zoomSpeed = 0.05f;
    public float minScale = 0.8f;
    public float maxScale = 1.8f;
    
    public float dragSmoothTime = 0.2f;

    private Vector3 targetScale;
    private Vector2 targetPosition;
    private Vector2 velocity = Vector2.zero;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        targetScale = rectTransform.localScale;
        targetPosition = rectTransform.anchoredPosition;
    }

    private void Update()
    {
        float t = Time.deltaTime * 4f;
        float currentScale = rectTransform.localScale.x;
        float lerpedScale = Mathf.Lerp(currentScale, targetScale.x, t);
        rectTransform.localScale = Vector3.one * lerpedScale;
        
        rectTransform.anchoredPosition = Vector2.SmoothDamp(
            rectTransform.anchoredPosition,
            targetPosition,
            ref velocity,
            dragSmoothTime
        );
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas == null) return;

        Vector2 delta = eventData.delta / (canvas.scaleFactor * 2f);
        targetPosition += delta;
    }

    public void OnScroll(PointerEventData eventData)
    {
        float scroll = eventData.scrollDelta.y;
        float newScale = Mathf.Clamp(targetScale.x + scroll * zoomSpeed, minScale, maxScale);
        targetScale = Vector3.one * newScale;
    }
}


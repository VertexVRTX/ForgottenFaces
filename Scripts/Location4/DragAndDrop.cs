using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;

    [SerializeField] private Slot[] allSlots;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.localPosition;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        
        foreach (Slot slot in allSlots)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(
                    slot.GetComponent<RectTransform>(), 
                    Input.mousePosition, 
                    canvas.worldCamera))
            {
                slot.TryPlaceFragment(GetComponent<Fragment>());
                return;
            }
        }
        
        rectTransform.localPosition = startPosition;
    }
}

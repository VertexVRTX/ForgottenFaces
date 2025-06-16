using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotate : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Camera mainCamera;

    private float angleOffset;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            eventData.position,
            mainCamera,
            out localPoint);

        Vector2 direction = localPoint - rectTransform.anchoredPosition;
        float angleAtClick = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        angleOffset = Mathf.DeltaAngle(rectTransform.localEulerAngles.z, angleAtClick);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            eventData.position,
            mainCamera,
            out localPoint);

        Vector2 direction = localPoint - rectTransform.anchoredPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        
        rectTransform.rotation = Quaternion.Euler(0, 0, angle - angleOffset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollowMouse : MonoBehaviour
{
    public RectTransform pupil;
    public float maxDistance = 10f;
    private RectTransform eyeRect;
    private Canvas canvas;
    private Vector2 pupilInitialPos;

    void Start()
    {
        eyeRect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        pupilInitialPos = pupil.anchoredPosition;
    }

    void Update()
    {
        Vector2 localMousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, Input.mousePosition, 
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out localMousePos);
        
        Vector2 eyeCenter = eyeRect.localPosition;
        Vector2 direction = localMousePos - (Vector2)eyeRect.localPosition;
        
        if (direction.magnitude > maxDistance)
            direction = direction.normalized * maxDistance;

        pupil.anchoredPosition = pupilInitialPos + direction;
    }
}

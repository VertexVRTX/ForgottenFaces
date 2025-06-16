using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISetupManager : MonoBehaviour
{
    private void Awake()
    {
        SetupCanvas();
        SetupEventSystem();
    }

    private void SetupCanvas()
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();

        Camera mainCam = Camera.main;
        if (mainCam == null)
        {
            
        }

        foreach (Canvas canvas in canvases)
        {
            if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                canvas.worldCamera = mainCam;
            }
        }
    }

    private void SetupEventSystem()
    {
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            GameObject esObj = new GameObject("EventSystem");
            esObj.AddComponent<EventSystem>();
            esObj.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }
    }
}

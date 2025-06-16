using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;
    public GameObject cornerObject;

    public void ClosePanel()
    {
        panel.SetActive(false);
        cornerObject.SetActive(true);
    }
}

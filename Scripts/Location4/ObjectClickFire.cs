using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClickFire : MonoBehaviour
{
    public GameObject panel;
    private bool isPanelOpened = false;

    private void OnMouseDown()
    {
        if (!isPanelOpened)
        {
            panel.SetActive(true);
            isPanelOpened = true;
            
            gameObject.SetActive(false);
        }
    }
}

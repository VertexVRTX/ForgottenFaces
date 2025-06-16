using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    public GameObject bigBoxPanel;

    private void OnMouseDown()
    {
        if (bigBoxPanel != null)
            bigBoxPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScrollWindow : MonoBehaviour
{
    public GameObject scrollWindow;

    public void Open()
    {
        if (scrollWindow != null)
        {
            scrollWindow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

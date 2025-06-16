using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public GameObject imageToShow;

    void OnMouseDown()
    {
        imageToShow.SetActive(true);
    }
    
    public void HideImage()
    {
        imageToShow.SetActive(false);
    }

}

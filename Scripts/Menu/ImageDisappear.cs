using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDisappear : MonoBehaviour
{
    public GameObject imageToHide;

    private void Start()
    {
        StartCoroutine(HideImageAfterDelay(3f));
    }

    IEnumerator HideImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        imageToHide.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PaperUIManager : MonoBehaviour
{
    public GameObject bigPaper;
    public Button paperIcon;

    private bool canClose = false;

    void Start()
    {
        bigPaper.SetActive(false);
        paperIcon.onClick.AddListener(OpenBigPaper);
    }

    void OpenBigPaper()
    {
        bigPaper.SetActive(true);
        canClose = false;
        Invoke(nameof(EnableClose), 0.1f); 
    }

    void EnableClose()
    {
        canClose = true;
    }

    void Update()
    {
        if (bigPaper.activeSelf && canClose && Input.GetMouseButtonDown(0))
        {
            bigPaper.SetActive(false);
        }
    }
}

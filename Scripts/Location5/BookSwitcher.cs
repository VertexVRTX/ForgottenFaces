using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BookSwitcher : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;

    public Button nextButton;
    public Button previousButton;

    void Start()
    {
        ShowImage1();
    }
    
    public void ShowImage1()
    {
        image1.SetActive(true);
        image2.SetActive(false);

        nextButton.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(false);
    }
    
    public void ShowImage2()
    {
        image1.SetActive(false);
        image2.SetActive(true);

        nextButton.gameObject.SetActive(false);
        previousButton.gameObject.SetActive(true);
    }
}

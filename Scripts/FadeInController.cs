using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInController : MonoBehaviour
{
    public float fadeDuration = 3f;
    private Image fadeImage;

    private void Awake()
    {
        fadeImage = GetComponent<Image>();
        if (fadeImage == null)
        {
            
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        
        color.a = 0f;
        fadeImage.color = color;
        
        gameObject.SetActive(false);
    }
}

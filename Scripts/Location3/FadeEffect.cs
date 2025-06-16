using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour
{
    public static FadeEffect Instance;

    public Image fadeImage;
    public float fadeDuration = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator FadeOut()
    {
        yield return Fade(0f, 1f);
    }

    public IEnumerator FadeIn()
    {
        yield return Fade(1.5f, 0f);
    }

    private IEnumerator Fade(float fromAlpha, float toAlpha)
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            color.a = Mathf.Lerp(fromAlpha, toAlpha, t);
            fadeImage.color = color;
            time += Time.deltaTime;
            yield return null;
        }

        color.a = toAlpha;
        fadeImage.color = color;
    }
}

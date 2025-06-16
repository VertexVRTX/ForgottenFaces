using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public float fadeDuration = 1f;
    public string nextSceneName;

    private bool isFading = false;

    private void Start()
    {
        SetupCanvasCamera();
    }

    private void SetupCanvasCamera()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            canvas.worldCamera = Camera.main;
        }
    }

    public void StartSceneTransition()
    {
        if (!isFading)
        {
            StartCoroutine(FadeAndLoadScene());
        }
    }

    private IEnumerator FadeAndLoadScene()
    {
        isFading = true;
        
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            fadePanel.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }
        fadePanel.alpha = 1f;
        
        Time.timeScale = 1f;
        
        ResetStaticVariables();
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        SetupCanvasCamera();
        
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            fadePanel.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            yield return null;
        }
        fadePanel.alpha = 0f;

        isFading = false;
    }
    
    private void ResetUI()
    {
        fadePanel.alpha = 0f;
        fadePanel.blocksRaycasts = false;
        
        PopupTrigger.ClosePopupForAll();
    }

    private void ResetStaticVariables()
    { 
        PopupTrigger.ClosePopupForAll();
    }
}

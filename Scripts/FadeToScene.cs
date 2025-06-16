using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeToScene : MonoBehaviour
{
    public Animator fadeAnimator;
    public string nextSceneName;

    private bool sceneIsLoading = false;

    public void StartFade()
    {
        if (fadeAnimator != null && !sceneIsLoading)
        {
            fadeAnimator.SetTrigger("FadeIn");
            sceneIsLoading = true;
        }
    }
    
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

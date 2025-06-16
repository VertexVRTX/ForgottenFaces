using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorPuzzleManager : MonoBehaviour
{
    public int[] correctDoorSequence = { 0, 2, 1, 1, 0 };

    private int currentLevel = 0;

    public GameObject wrongChoiceDialog;
    private bool hasShownWrongDialog = false;
    public TypewriterEffect typingEffect;
    [TextArea] public string wrongMessage = "Hmm... I guess I need to find the right door.";
    
    public GameObject level2DialogWindow;
    public TypewriterEffect level2TypingEffect;
    [TextArea] public string level2DialogText = "Each time, I find scraps of some kind of paper in my pockets... I’ll keep them, just in case.";
    
    public GameObject level5DialogWindow;
    public TypewriterEffect level5TypingEffect;
    [TextArea] public string level5DialogText = "Creepy room. The maid I saw earlier, she looks different...";

    public GameObject level6DialogWindow;
    public TypewriterEffect level6TypingEffect;
    [TextArea] public string level6DialogText = "There are images on the torn sheets. I think I should put it together.";
    
    private HashSet<int> shownDialogs = new HashSet<int>();
    public void CheckDoor(int doorIndex)
    {
        if (doorIndex == correctDoorSequence[currentLevel])
        {
            currentLevel++;

            if (currentLevel >= correctDoorSequence.Length)
            {
                OnPuzzleComplete();
            }
            else
            {
                if (!shownDialogs.Contains(currentLevel))
                {
                    shownDialogs.Add(currentLevel);

                    if (currentLevel == 1)
                    {
                        StartCoroutine(LevelTransition.Instance.TransitionToLevel(currentLevel, () =>
                        {
                            StartCoroutine(ShowLevelDialog(level2DialogWindow, level2TypingEffect, level2DialogText));
                        }));
                        return;
                    }
                    else if (currentLevel == 4)
                    {
                        StartCoroutine(LevelTransition.Instance.TransitionToLevel(currentLevel, () =>
                        {
                            StartCoroutine(ShowLevelDialog(level5DialogWindow, level5TypingEffect, level5DialogText));
                        }));
                        return;
                    }
                    else if (currentLevel == 5)
                    {
                        StartCoroutine(LevelTransition.Instance.TransitionToLevel(currentLevel, () =>
                        {
                            StartCoroutine(ShowLevelDialog(level6DialogWindow, level6TypingEffect, level6DialogText));
                        }));
                        return;
                    }
                }
                
                StartCoroutine(LevelTransition.Instance.TransitionToLevel(currentLevel));
            }
        }
        else
        {
            if (!hasShownWrongDialog)
            {
                hasShownWrongDialog = true;
                StartCoroutine(RestartPuzzleWithDialog());
            }
            else
            {
                RestartPuzzle();
            }
        }
    }

    private IEnumerator RestartPuzzleWithDialog()
    {
        currentLevel = 0;

        yield return LevelTransition.Instance.TransitionToLevel(currentLevel, () =>
        {
            if (wrongChoiceDialog != null)
            {
                wrongChoiceDialog.SetActive(true);
                if (typingEffect != null)
                    typingEffect.StartTyping(wrongMessage);
            }
        });

        yield return new WaitForSeconds(6f);
        wrongChoiceDialog?.SetActive(false);
    }

    private IEnumerator ShowLevelDialog(GameObject dialogWindow, TypewriterEffect effect, string message)
    {
        if (dialogWindow != null)
        {
            dialogWindow.SetActive(true);

            if (effect != null)
                effect.StartTyping(message);

            yield return new WaitForSeconds(10f);
            dialogWindow.SetActive(false);
        }
    }

    private void RestartPuzzle()
    {
        currentLevel = 0;
        StartCoroutine(LevelTransition.Instance.TransitionToLevel(0));
    }

    private void OnPuzzleComplete()
    {
       
    }
}

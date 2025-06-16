using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    public static LevelTransition Instance;

    public GameObject[] levelRooms;
    public Transform player;
    public Vector3 centerPosition = Vector3.zero;

    private void Awake()
    {
        Instance = this;
    }
    
    public void GoToLevel(int level)
    {
        StartCoroutine(TransitionToLevel(level));
    }
    
    public IEnumerator TransitionToLevel(int level, System.Action onFinished = null)
    {
        yield return FadeEffect.Instance.FadeOut();

        for (int i = 0; i < levelRooms.Length; i++)
            levelRooms[i].SetActive(i == level);

        if (player != null)
            player.position = centerPosition;

        yield return FadeEffect.Instance.FadeIn();
        
        FindObjectOfType<FinalLevelHandler>()?.OnLevelEntered(level);
        
        InventoryDisplay.Instance.ShowItem(level);
        
        onFinished?.Invoke();
    }
    
}

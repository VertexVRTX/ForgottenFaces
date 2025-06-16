using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public static InventoryDisplay Instance;

    public GameObject[] itemsToShow;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowItem(int level)
    {
        if (level >= 0 && level < itemsToShow.Length)
        {
            itemsToShow[level].SetActive(true);
        }
    }
}

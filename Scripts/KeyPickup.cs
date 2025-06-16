using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public GameObject keyIconUI;


    private void OnMouseDown()
    {
        Inventory.hasKey = true;
        if (keyIconUI != null)
            keyIconUI.SetActive(true);
        
        Destroy(gameObject);
    }
}

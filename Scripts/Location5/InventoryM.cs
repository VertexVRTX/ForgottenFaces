using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryM : MonoBehaviour
{
    public GameObject table;
    public GameObject boneIcon;
    public GameObject[] fragmentIcons;
    
    public GameObject bonePanel;
    public GameObject fragmentsPanel;

    void Start()
    {
        bonePanel.SetActive(false);
        fragmentsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == table)
            {
                if (boneIcon.activeInHierarchy)
                {
                    OpenBonePanel();
                }
                if (AreAllFragmentsCollected())
                {
                    OpenFragmentsPanel();
                }
            }
        }
    }

    bool AreAllFragmentsCollected()
    {
        foreach (GameObject fragmentIcon in fragmentIcons)
        {
            if (!fragmentIcon.activeInHierarchy)
                return false;
        }
        return true;
    }

    public void OpenBonePanel()
    {
        bonePanel.SetActive(true);
        boneIcon.SetActive(false);
    }

    public void CloseBonePanel()
    {
        bonePanel.SetActive(false);
        boneIcon.SetActive(true);
    }

    public void OpenFragmentsPanel()
    {
        fragmentsPanel.SetActive(true);
        foreach (GameObject fragmentIcon in fragmentIcons)
        {
            fragmentIcon.SetActive(false);
        }
    }

    public void CloseFragmentsPanel()
    {
        fragmentsPanel.SetActive(false);
        foreach (GameObject fragmentIcon in fragmentIcons)
        {
            fragmentIcon.SetActive(true);
        }
    }
}

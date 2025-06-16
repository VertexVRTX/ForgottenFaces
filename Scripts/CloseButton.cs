using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public GameObject settingsPanel;

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}

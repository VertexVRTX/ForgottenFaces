using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}

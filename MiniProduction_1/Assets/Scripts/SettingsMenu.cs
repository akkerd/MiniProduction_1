using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    bool settingsVisible = false;

    public GameObject settingsMenu;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle musicToggle;
    public Toggle sfxToggle;

    public Color chosen;
    public Color unChosen;
    public Image english;
    public Image danish;

    public void ChangeSettingsMenu()
    {
        if (settingsVisible)
        {
            settingsVisible = false;
            settingsMenu.SetActive(false);
        }
        else
        {

            settingsVisible = true;
            settingsMenu.SetActive(true);
        }
        SetupFlags();
    }

    public void ChangeMusicValue()
    {
        SettingsFlags.Instance.MusicVolume = (int)musicVolumeSlider.value;
        AkSoundEngine.SetRTPCValue("music_mix", musicVolumeSlider.value);
    }

    public void SwithMusic()
    {
        SettingsFlags.Instance.IsMusicOn = musicToggle.isOn;

        if (SettingsFlags.Instance.IsMusicOn)
        {
            AkSoundEngine.SetRTPCValue("music_mix", SettingsFlags.Instance.MusicVolume);
            Debug.Log("Music muted");
        }
        else
        {
            AkSoundEngine.SetRTPCValue("music_mix", 0);
            Debug.Log("Music unmuted");
        }
    }

    public void ChangeSFXValue()
    {
        SettingsFlags.Instance.SFXVolume = (int)sfxVolumeSlider.value;
        AkSoundEngine.SetRTPCValue("sfx_mix", sfxVolumeSlider.value);

    }

    public void SwithSFX()
    {
        SettingsFlags.Instance.IsSFXOn = sfxToggle.isOn;

        if (SettingsFlags.Instance.IsSFXOn)
        {
            AkSoundEngine.SetRTPCValue("sfx_mix", SettingsFlags.Instance.SFXVolume);
            Debug.Log("SFX muted");
        }
        else 
        {
            AkSoundEngine.SetRTPCValue("sfx_mix", 0);
            Debug.Log("SFX unmuted");
        }
    }

    public void ChangeLanguage(int value)
    {
        SettingsFlags.Instance.CurrentLanguage = (SettingsFlags.Language)value;
        SetupFlags();
    }

    void SetupFlags()
    {
        if (SettingsFlags.Instance.CurrentLanguage == 0)
        {
            english.color = chosen;
            danish.color = unChosen;
        } else
        {
            english.color = unChosen;
            danish.color = chosen;
        }
    }
}

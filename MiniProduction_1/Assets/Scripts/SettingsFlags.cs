using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsFlags : Manager<SettingsFlags> {
    public enum Language { English, Danish};
    private Language currentLanguage = Language.English;
    public AudioMixer masterMixer;

    private bool isMusicOn = true;
    private bool isSFXOn = true;
    private int musicVolume = 20;
    private int sFXVolume = 20;

    

    public int MusicVolume
    {
        get
        {
            return musicVolume;
        }

        set
        {
            musicVolume = value;
            if (IsMusicOn)
            {
                masterMixer.SetFloat("MusicVolume", value);
            }
        }
    }

    public int SFXVolume
    {
        get
        {
            return sFXVolume;
        }

        set
        {
            sFXVolume = value;
            if (IsSFXOn)
            {
                masterMixer.SetFloat("SFXVolume", value);
            }
        }
    }

    public bool IsMusicOn
    {
        get
        {
            return isMusicOn;
        }

        set
        {
            isMusicOn = value;
            if (value)
            {
                masterMixer.SetFloat("MusicVolume", musicVolume);
            }
            else
            {
                masterMixer.SetFloat("MusicVolume", -80);
            }

        }
    }

    public bool IsSFXOn
    {
        get
        {
            return isSFXOn;
        }

        set
        {
            isSFXOn = value;
            if (value)
            {
                masterMixer.SetFloat("SFXVolume", sFXVolume);
            } else
            {
                masterMixer.SetFloat("SFXVolume", -80);
            }

        }
    }

    public Language CurrentLanguage
    {
        get
        {
            return currentLanguage;
        }

        set
        {
            currentLanguage = value;
        }
    }

    
}

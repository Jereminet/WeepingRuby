using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenuScript : MonoBehaviour
{
    public AudioManager audioManager;

    public void setVolume(float vol)
    {
        audioManager.ChangeVolume("Theme", vol);
    }

    public void setMaxSound(float s)
    {
        audioManager.setSound(s);
    }

}

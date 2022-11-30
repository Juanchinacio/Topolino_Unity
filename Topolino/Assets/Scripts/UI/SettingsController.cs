using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    [SerializeField] Slider slider_sound;
    [SerializeField] Slider slider_music;
    [SerializeField] AudioManager audioManager;

    public void SoundVolume()
    {
        float currentValue = slider_sound.value;
        audioManager.ChangeSoundVolume(currentValue);
    }
    public void MusicVolume()
    {
        float currentValue = slider_music.value;
        audioManager.ChangeMusicVolume(currentValue);
    }
}

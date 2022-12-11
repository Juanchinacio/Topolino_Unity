using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]AudioSource[] musics;
    [SerializeField] AudioSource[] sounds;


    private void Awake()
    {
        ChangeMusicVolume(GameManager.manager.musicVolume);
        ChangeSoundVolume(GameManager.manager.soundVolume);
    }

    public void PlayMusic(Music type)
    {
        musics[(int)type].Play();
    }
    public void PlaySound(Sound type)
    {
        sounds[(int)type].Play();
    }

    public void ChangeMusicVolume(float musicVolume)
    {
        GameManager.manager.musicVolume = musicVolume;

        foreach (AudioSource a in musics)
        {
            a.volume = musicVolume;
        }

    }

    public void ChangeSoundVolume(float soundVolume)
    {
        GameManager.manager.soundVolume = soundVolume;

        foreach (AudioSource a in sounds)
        {
            a.volume = soundVolume;
        }
    }

}

public enum Music
{
    lobby
}
public enum Sound
{
    ui, click, collectable
}
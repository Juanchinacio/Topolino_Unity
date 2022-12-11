using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    /*
     * GammeManager is created on a preload scene, being used to define logic of the game, since its not victory and lose condition for the hole game, its ussed for the time being by a Scene controller.
     */


    #region Variables

    //Game manager instance
    public static GameManager manager;

    //Variables for Scene manager
    [SerializeField]private string[] scenes;
    private int activeScene = 0;

    //Variables for Audio manager
    public float musicVolume = 0.5f;
    public float soundVolume = 0.5f;

    #endregion

    void Start()
    {
        //Load scene menu
        LoadScene(0);
    }

    private void Awake()
    {
        //Create only instance in game of GameManager
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Pause its not used yet, it can stop time so phycis and timer will be stoped
    public void Pause(bool pause)
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    //Load scene using index defined in inspector to easy define next scene
    public void LoadScene(int sceneNum)
    {
        activeScene = sceneNum;
        SceneManager.LoadScene(scenes[sceneNum]);
    }

    public void PlayAudio(AudioSource audio, Audio type)
    {
        audio.volume = (type == Audio.mussic) ? musicVolume : soundVolume;
        Debug.Log(type == Audio.mussic);
        audio.Play();
    }

}

public enum Audio
{
    mussic, sound
}

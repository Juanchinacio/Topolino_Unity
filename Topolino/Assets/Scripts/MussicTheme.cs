using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MussicTheme : MonoBehaviour
{
    [SerializeField]
    public AudioSource theme;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.manager.PlayAudio(theme,Audio.mussic);
    }

}

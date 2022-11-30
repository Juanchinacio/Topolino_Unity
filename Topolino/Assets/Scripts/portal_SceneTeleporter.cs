using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_SceneTeleporter : MonoBehaviour
{
    public GameObject sceneController;
    public string Scene_Name;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sceneController.GetComponent<SceneController>().CargarEscena(Scene_Name);
        }
    }
}

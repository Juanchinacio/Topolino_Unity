using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggersUI : MonoBehaviour
{
    public GameObject worldUI_E;
    private GameObject ui;

    void Start()
    {
        ui = Instantiate(worldUI_E, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        ui.SetActive(false);
        ui.transform.parent = transform;
    }
}

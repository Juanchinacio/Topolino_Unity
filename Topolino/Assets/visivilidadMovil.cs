using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class visivilidadMovil : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            this.gameObject.SetActive(false);
             return IsMobile();
#endif
        return false;
    }
}

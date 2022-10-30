using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerIcon : MonoBehaviour
{
    public Icons PlayStation;
    public Icons Xbox;
    public Icons Nintendo;
}
[System.Serializable]
public struct Icons
{
    [Header("Buttons")]
    public Sprite Button_South;
    public Sprite Button_North;
    public Sprite Button_East;
    public Sprite Button_West;

    [Header("Sticks")]
    public Sprite left_Stick;
    public Sprite right_Stick;

    [Header("D-PAD")]
    public Sprite DPAD_Down;
    public Sprite DPAD_North;
    public Sprite DPAD_South;
    public Sprite DPAD_West;
}
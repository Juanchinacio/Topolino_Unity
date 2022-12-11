using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerLevelSelector : MonoBehaviour
{
    [SerializeField]
    public int ind;

    void Start()
    {
        //If the sticker isnt collected yet it turn it black
        Image c = GetComponent<Image>();

        if (!BagManager.bag.CheckItem(ind))
            c.color = Color.black;
    }

}

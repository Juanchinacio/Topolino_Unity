using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberStickersLevel : MonoBehaviour
{
    TextMeshProUGUI text;

    [SerializeField]
    public List<int> idStickers;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        
        //Print number of stickers collected of total
        Print();
    }

    void Print()
    {
        int stickersCollect = 0;

        foreach (int i in idStickers)
        {
            if (BagManager.bag.CheckItem(i))
                stickersCollect++;
        }

        text.text = stickersCollect + "/" + idStickers.Count;
    }
}

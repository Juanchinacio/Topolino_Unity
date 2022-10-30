using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readCSV : MonoBehaviour
{

    void Start()
    {
        var dataset = Resources.Load<TextAsset>("CSV_Carteles");
        var dataLines = dataset.text.Split('\n'); // Split also works with simple arguments, no need to pass char[]

        for (int i = 0; i < dataLines.Length; i++)
        {
            var data = dataLines[i].Split(',');
            for (int d = 0; d < data.Length; d++)
            {
                print(data[d]); // what you get is split sequential data that is column-first, then row
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    public static BagManager bag;
    private bool[] items;
    [SerializeField] public int size;
    private string bagKey = "Bag";

    private void Awake()
    {
        //Create only instance in game of BagManager
        if (bag == null)
        {
            bag = this;
            items = new bool[size];
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private bool OutsideBounds(int id)
    {
        return id >= items.Length;
    }

    public void CollectItem(int id)
    {
        if (!OutsideBounds(id))
            items[id] = true;
    }

    public void LoseItem(int id)
    {
        if(!OutsideBounds(id))
            items[id] = false;
    }

    public void Clean()
    {
        for (int i  = 0; i < items.Length; i++)
        {
            items[i] = false;
        }
    }

    public bool CheckItem(int id)
    {
        if (OutsideBounds(id))
            return false;
        return items[id]; 
    }

    public void SaveBag()
    {
        string save = "";
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i])
                save += 1;
            else
                save += 0;
        }
        PlayerPrefs.SetString(bagKey, save);
        PlayerPrefs.Save();
        
    }
    public void LoadBag()
    {
        var data = PlayerPrefs.GetString(bagKey, "");
        if(data.Length == items.Length)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '0')
                    items[i] = false;
                if (data[i] == '1')
                    items[i] = true;
            }
        }
        else
        {
            Debug.Log("Error reading collectables");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectablesController : MonoBehaviour
{

    [SerializeField] public List<Collectable> collectables;
    [SerializeField] public TextMeshProUGUI t_description;
    [SerializeField] public AudioManager audioManager;

    public float textTimer;
    private float currentTime;

    private void Start()
    {
       // BagManager.bag.Clean();
       // BagManager.bag.SaveBag();
        BagManager.bag.LoadBag();
        ShowCollectables();
    }

    public void ItemClicked(int id, string description)
    {
        audioManager.PlaySound(Sound.collectable);
        if (BagManager.bag.CheckItem(id))
        {
            t_description.text = description;
        }
        else
        {
            t_description.text = "No tienes este item";
        }
        StartCoroutine(ShowDescription());
    }

    public void ShowCollectables()
    {
        int ind = 0;
        foreach (Collectable c in collectables)
        {
            if (!BagManager.bag.CheckItem(ind))
                c.img.color = Color.black;
            ind++;
        }
    }

    public IEnumerator ShowDescription()
    {
        currentTime += textTimer;
        float myTime = textTimer;
        while(myTime >0)
        {
            myTime -= Time.deltaTime;
            yield return null;
        }
        currentTime -= textTimer;
        if (currentTime<=0)
            t_description.text = "";
        
    }


}

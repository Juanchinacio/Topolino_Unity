using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] int id;

    [SerializeField] public AudioSource sticker;

    private void Start()
    {
        //Si ya tiene este objeto se destruye, importante guardar y cargar los preferences del bag
        if (BagManager.bag.CheckItem(id))
        {
            Destroy(this.gameObject);
            BagManager.bag.SaveBag();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GameManager.manager.PlayAudio(sticker, Audio.sound);
            new WaitForSeconds(10f);
            StartCoroutine(DestroyCollectable());
        }
    }

    IEnumerator DestroyCollectable()
    {
        Debug.Log("Sonar audio");
        BagManager.bag.CollectItem(id);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        BagManager.bag.SaveBag();
    }

}

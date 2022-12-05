using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] int id;

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
            BagManager.bag.CollectItem(id);
            Destroy(this.gameObject);
            BagManager.bag.SaveBag();
        }
    }
}

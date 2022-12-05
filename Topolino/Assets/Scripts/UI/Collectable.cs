using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Collectable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int id;
    [SerializeField] public Image img;
    [SerializeField] public string description;
    [SerializeField] CollectablesController controller;

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.ItemClicked(id, description);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeCircle : MonoBehaviour
{
    [SerializeField] float rotationVelocity;
    RectTransform rectTransform;
    private bool charging;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        charging = true;
        StartCoroutine(Charging());
    }

    public IEnumerator Charging()
    {
        float valueToAdd = Time.deltaTime * rotationVelocity;
        float currentValue = 0f;

        while (charging)
        {
            //Get actual state of object rotation
            Vector3 currentRotation = rectTransform.rotation.eulerAngles;

            //Reset rotation
            rectTransform.Rotate(-currentRotation);

            currentValue -= valueToAdd;

            Debug.Log(currentValue);
            //Apply new rotation
            rectTransform.Rotate(Vector3.forward * currentValue);

            yield return null;
        }
    }

    public void StartCharging()
    {
        charging = true;
        StartCoroutine(Charging());
    }

    public void StopCharging()
    {
        charging = false;
    }

}

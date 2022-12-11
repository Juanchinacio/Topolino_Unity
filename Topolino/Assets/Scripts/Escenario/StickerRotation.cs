using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerRotation : MonoBehaviour
{
    [SerializeField] float rotationVelocity;
    Transform t;
    private bool charging;

    private void Start()
    {
        t = GetComponent<Transform>();

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
            Vector3 currentRotation = t.rotation.eulerAngles;

            //Reset rotation
            t.Rotate(-currentRotation);

            currentValue -= valueToAdd;

            Debug.Log(currentValue);
            //Apply new rotation
            t.Rotate(Vector3.up * currentValue);

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

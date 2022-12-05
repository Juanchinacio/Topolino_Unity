using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityScale : MonoBehaviour
{
    public float scale = 1f; //The gravity scale
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * scale, ForceMode.Acceleration); //It has to be FixedUpdate, because it applies force to the rigidbody constantly.
    }
}
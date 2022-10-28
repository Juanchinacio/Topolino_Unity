using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class new_PlayerMovement : MonoBehaviour
{
    //[Header("Movement")]
    public float groundDrag;
    public float moveSpeed;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    Vector2 inputMovement;
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public float rotationSpeed;
    Transform cameraTransform;
    Rigidbody rb;
    Grounded ground;

    //public Transform ori

    void Start()
    {
        cameraTransform = Camera.main.transform;
        rb = transform.GetComponent<Rigidbody>();
        ground = GetComponent<Grounded>();
    }
    void Update()
    {
        // Control de velocidad
        SpeedControl();

        // Comprobar si esta en el suelo
        grounded = ground.GetOnGround();

        //Aplicar drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0f;
        }

        // Rotar orientacion
        Vector3 viewDir = player.position - new Vector3(cameraTransform.position.x, player.position.y, cameraTransform.position.z);
        orientation.forward = viewDir.normalized;

        // Rotar el modelo del jugador
        Vector3 inputDir = orientation.forward * inputMovement.y + orientation.right * inputMovement.x;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    public void OnMovement(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
    }

    public void PlayerMove()
    {
        Vector3 moveDirection = orientation.right * inputMovement.x + orientation.forward * inputMovement.y;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
        
    }

}

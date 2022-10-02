using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier = 0;
    bool releaseJump = false;

    public float jumpMinAltitud_Y;
    public float jumpInitialPoint_Y;
    public float actual_Y;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public bool grounded;
    public bool isGrounded;

    public Transform groundCheckPoint, groundCheckPoint2;

    public Transform orientation;

    // Valor mayor a 1
    public float yVelJumpReleaseMod = 2;

    float horizontalInput;
    float verticalInput;

    public Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


    }

    private void Update()
    {
        MyInput();
        SpeedControl();

        actual_Y = transform.position.y;

        //isGrounded = Physics.OverlapSphere(groundCheckPoint.position, 0.1f);

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //var jumpInputReleased = Input.GetButtonUp("Jump");


        if (Input.GetButtonDown("Jump") && grounded)
        {
            releaseJump = false;
            grounded = false;
            jumpInitialPoint_Y = this.transform.position.y;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            //grounded = false;
        }
        if (Input.GetButtonUp("Jump"))
        {
            releaseJump = true;
            
        }
        if (releaseJump == true && rb.velocity.y > 0 && actual_Y > jumpInitialPoint_Y + jumpMinAltitud_Y)
        {
            rb.velocity = new Vector3(rb.velocity.x, (rb.velocity.y / yVelJumpReleaseMod) * Time.deltaTime, rb.velocity.z);
        }

    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

}
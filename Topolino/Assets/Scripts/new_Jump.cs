using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class new_Jump : MonoBehaviour
{

    
    [Header("Jump Settings")]
    public float jumpHeight = 5;
    public float jumpBuffer = .15f;
    public float coyoteTime = .15f;
    public float buttonTime = 0.5f;
    //
    public float cancelRate = 100;
    public float baseGravityScale = 5;
    public float fallingGravityScale = 10;
    //
    float second = 60;

    [Header("Ground Checker")]
    public Grounded groundChecker;
    public bool onGround;
    
    [Header("Debug")]
    public bool canJump = true;
    public bool desiredJump;
    public bool jumping = false;
    public float jumpBufferCounter;
    public float jumpTime;

    // Necesario para calculos


    bool jumpCancelled;
    float jumpForce;
    float actualGravityScale;
    float coyoteTimeCounter = 0;
    
    bool pressingJump;
    Rigidbody rb;  
    


    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        actualGravityScale = baseGravityScale;
        //groundChecker = GetComponent<Grounded>();
    }

    void Update()
    {
        ////if (transform.GetComponent<Rigidbody>().velocity.y <= 0)
        ////{
        ////    jumping = false;
        ////}
        onGround = groundChecker.GetOnGround();
        //jumpBufferCounter = 0;
        //#region JumpBuffer
        //
        //
        //if (jumpBuffer > 0)
        //{
        //
        //    if (desiredJump)
        //    {
        //        Debug.Log("AUMENTO JUMPBUFFERCOUNTER");
        //        jumpBufferCounter += Time.deltaTime * second;
        //    }
        //    if (jumpBufferCounter > jumpBuffer)
        //    {
        //        Debug.Log("DESACTIVO JUMPBUFFERCOUNTER");
        //        desiredJump = false;
        //        jumpBufferCounter = 0;
        //    }
        //}
        //
        //
        //#endregion
        //#region Coyote time
        //if (!jumping && !onGround)
        //{
        //    coyoteTimeCounter += Time.deltaTime * second;
        //}
        //else
        //{
        //    coyoteTimeCounter = 0;
        //}
        //#endregion
        //
        //// Cambio de gravedad
        //if (!pressingJump && jumping && rb.velocity.y > 0)
        //{
        //    rb.AddForce(Vector3.down * cancelRate);
        //}
        //if (rb.velocity.y >= 0)
        //{
        //    Debug.Log("Cambio escala gravedad 1");
        //    actualGravityScale = baseGravityScale;
        //}
        //else if (rb.velocity.y < 0)
        //{
        //    Debug.Log("Cambio escala gravedad 2");
        //    actualGravityScale = fallingGravityScale;
        //}
        //
        //
    }

    void FixedUpdate()
    {
        //// Unico que hacer aqui
        //if (desiredJump && onGround)
        //{
        //    Jump();
        //    return;
        //}
        //// Unico que hacer aqui
        //
        //
        //
        //
        //
        //
        ////rb.AddForce(Physics.gravity * (actualGravityScale - 1) * rb.mass);
        ////jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * actualGravityScale));


    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && onGround)
        {
            Jump();
        }
        //// Unico que hacer aqui
        //if (value.isPressed)
        //{
        //    desiredJump = true;
        //    pressingJump = true;
        //}
        //if (!value.isPressed)
        //{
        //    pressingJump = false;
        //}
        //// Unico que hacer aqui
        //
        //
        //
        //
        //
        //
        //if (jumping && value.isPressed)
        //{
        //    desiredJump = true;
        //}
        //if (value.isPressed && onGround)
        //{
        //    //rb.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
        //    jumping = true;
        //    desiredJump = true;
        //    jumpCancelled = false;
        //    jumpTime = 0;
        //}
        //if (jumping)
        //{
        //    jumpTime += Time.deltaTime * second;
        //
        //    if (jumpTime > buttonTime)
        //    {
        //        jumping = false;
        //    }
        //    //    //Jump();
        //    //    rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
        //    //    jumpTime += Time.deltaTime;
        //}
    }

    public void Jump()
    {
        //if ((onGround || (coyoteTimeCounter > 0.03f && coyoteTimeCounter < coyoteTime)) && canJump)
        //{
            Debug.Log("Saltar");
            jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * actualGravityScale));
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            jumping = true;
            desiredJump = false;
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
        //}
    }

    public bool Get_canJump() { return canJump; }
    public void Set_canJump(bool _canJump) { canJump = _canJump; }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class new_Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public float buttonTime = 0.5f;
    public float jumpHeight = 5;
    public float cancelRate = 100;
    float jumpTime;
    bool jumping;
    bool jumpCancelled;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }
}
//public float velocidad_Y;
//
//Rigidbody rb;
//public float buttonTime = 0.5f;
////public float jumpAmount = 10;
//public float jumpHeight = 5;
//public float cancelRate = 100;
//
//float jumpTime;
//bool jumping;
//bool jumpCancelled;
//
//float jumpForce;
//
//float actualGravityScale;
//public float baseGravityScale = 5;
//public float fallingGravityScale = 10;
//
//// How far from ground should we cache your jump?
//public float jumpBuffer = .15f;
//// How long should coyote time last?
//public float coyoteTime = .15f;
//
//float coyoteTimeCounter = 0;
////float jumpBufferCounter;
//
//bool pressingJump;
//
//public bool onGround;
//Grounded ground;
//public bool desiredJump;
//
//
//void Start()
//{
//    rb = transform.GetComponent<Rigidbody>();
//    actualGravityScale = baseGravityScale;
//    ground = GetComponent<Grounded>();
//}
//
//void Update()
//{
//    // Debug
//    velocidad_Y = rb.velocity.y;
//
//    onGround = ground.GetOnGround();
//    //jumpBufferCounter = 0;
//    //#region JumpBuffer
//    //if (jumpBuffer > 0)
//    //{
//    //    if (desiredJump)
//    //    {
//    //        jumpBufferCounter += Time.deltaTime;
//    //    }
//    //    if (jumpBufferCounter > jumpBuffer)
//    //    {
//    //        desiredJump = false;
//    //        jumpBufferCounter = 0;
//    //    }
//    //}
//    //#endregion
//    #region Coyote time
//if (!jumping && !onGround)
//        {
//            coyoteTimeCounter += Time.deltaTime;
//        }
//        else
//        {
//            coyoteTimeCounter = 0;
//        }
//        #endregion
//    //
//    //    // Cambio de gravedad
//    //    if (!pressingJump && jumping && rb.velocity.y > 0)
//    //    {
//    //        rb.AddForce(Vector3.down * cancelRate);
//    //    }
//    //    if (rb.velocity.y >= 0)
//    //    {
//    //        Debug.Log("Cambio escala gravedad 1");
//    //        actualGravityScale = baseGravityScale;
//    //    }
//    //    else if (rb.velocity.y < 0)
//    //    {
//    //        Debug.Log("Cambio escala gravedad 2");
//    //        actualGravityScale = fallingGravityScale;
//    //    }
//    //}
//    //
//    //void FixedUpdate()
//    //{
//    //    // Unico que hacer aqui
//    //    if (desiredJump && onGround)
//    //    {
//    //        Jump();
//    //        return;
//    //    }
//    //    // Unico que hacer aqui
//    //
//    //
//    //
//    //
//    //
//    //
//    //    //rb.AddForce(Physics.gravity * (actualGravityScale - 1) * rb.mass);
//    //    //jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * actualGravityScale));
//    //
//    //
//    //}
//    //
//    //public void OnJump(InputValue value)
//    //{
//    //    // Unico que hacer aqui
//    //    if (value.isPressed)
//    //    {
//    //        desiredJump = true;
//    //        pressingJump = true;
//    //    }
//    //    if (!value.isPressed)
//    //    {
//    //        pressingJump = false;
//    //    }
//    //    // Unico que hacer aqui
//    //
//    //
//    //
//    //
//    //
//    //
//    //    //if (jumping && value.isPressed)
//    //    //{
//    //    //    desiredJump = true;
//    //    //}
//    //    //if (value.isPressed && onGround)
//    //    //{
//    //    //    //rb.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
//    //    //    jumping = true;
//    //    //    desiredJump = true;
//    //    //    jumpCancelled = false;
//    //    //    jumpTime = 0;
//    //    //}
//    //    //if (jumping)
//    //    //{
//    //    //    jumpTime += Time.deltaTime;
//    //    //
//    //    //    if (jumpTime > buttonTime)
//    //    //    {
//    //    //        jumping = false;
//    //    //    }
//    //    ////    //Jump();
//    //    ////    rb.velocity = new Vector3(rb.velocity.x, jumpAmount, rb.velocity.z);
//    //    ////    jumpTime += Time.deltaTime;
//    //    //}
//    //}
//    //
//    //public void Jump()
//    //{
//    //    if (onGround)// || (coyoteTimeCounter > 0.03f && coyoteTimeCounter < coyoteTime))
//    //    {
//    //        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * actualGravityScale));
//    //        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
//    //
//    //        jumping = true;
//    //        desiredJump = false;
//    //        //jumpBufferCounter = 0f;
//    //        coyoteTimeCounter = 0f;     
//    //    }
//    //}
//}

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

    [Header("Ground Checker")]
    public Grounded groundChecker;
    public bool onGround;
    
    [Header("Debug")]
    public bool canJump = true;
    public bool desiredJump;
    public bool jumping = false;
    public float jumpTime;

    // Necesario para calculos
    float jumpForce;
    float actualGravityScale;

    [Header("Animator")]
    public Animator _animator;
    private int _idJump;

    Rigidbody rb;  
    


    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        actualGravityScale = baseGravityScale;


        _idJump = Animator.StringToHash("isJumping");
    }

    void Update()
    {
        onGround = groundChecker.GetOnGround();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && onGround)
        {
            Jump();
        }
    }

    public void Jump()
    {
            Debug.Log("Saltar");
            jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * actualGravityScale));

            _animator.SetBool(_idJump, true);

            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            jumping = true;
            desiredJump = false;
    }

    public bool Get_canJump() { return canJump; }
    public void Set_canJump(bool _canJump) { canJump = _canJump; }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Jump : MonoBehaviour
{

    Controles controls;

    Rigidbody rb3D;
    Grounded ground;
    GravityScale gravityScale;

    // Maximum jump height
    public float jumpHeight = 7f;
    // How long it takes to reach that height before coming back down
    public float timeToJumpApex;
    // How far from ground should we cache your jump?
    public float jumpBuffer = .15f;
    // How long should coyote time last?
    public float coyoteTime = .15f;
    
    // Gravity multiplier to apply when going up
    public float upwardMovementMultiplier = 1f;
    // Gravity multiplier to apply when coming down
    public float downwardMovementMultiplier = 6.17f;
    // The fastest speed the character can fall
    public float speedLimit;
    // Gravity multiplier when you let go of jump
    public float jumpCutOff;

    public float gravMultiplier;

    Vector3 velocity;

    float jumpSpeed;
    float defaultGravityScale;
    float coyoteTimeCounter = 0;
    float jumpBufferCounter;
    
    bool desiredJump;
    bool pressingJump;
    bool onGround;
    bool currentlyJumping;
    bool variableJumpHeight = true;

    void Awake()
    {
        rb3D = GetComponent<Rigidbody>();
        ground = GetComponent<Grounded>();
        gravityScale = GetComponent<GravityScale>();
        defaultGravityScale = 1f;
        controls = new Controles();
    }

    void Update()
    {
        setPhysics();
        onGround = ground.GetOnGround();

        // buffer de salto
        if (jumpBuffer > 0)
        {
            if (desiredJump)
            {
                jumpBufferCounter += Time.deltaTime;
            }
            if (jumpBufferCounter > jumpBuffer)
            {
                // Si el tiempo excede el del jumpBuffer, desireJump pasa a falso y el buffer a 0
                desiredJump = false;
                jumpBufferCounter = 0;
            }
        }

        // Coyote time
        if (!currentlyJumping && !onGround)
        {
            coyoteTimeCounter += Time.deltaTime;
        }
        else
        {
            // Si toca el suelo se resetea
            coyoteTimeCounter = 0;
        }
    }

    void FixedUpdate()
    {
        velocity = rb3D.velocity;

        // Tratar de saltar, siempre que se desee saltar
        if (desiredJump)
        {
            DoAJump();
            rb3D.velocity = velocity;
            return;
        }
        calculateGravity();

    }

    //public void OnJump(InputAction.CallbackContext context)
    public void OnJump(InputValue value)
    {
        //Debug.Log("QUE PASAAAAAAAAAAAAAAAAAA");
        if (value.isPressed)
        {
            //Debug.Log("Salto");
            desiredJump = true;
            pressingJump = true;
        }
        if (value.isPressed == false)
        {
            //Debug.Log("Dejo de saltar");
            pressingJump = false;
        }
    }
    void setPhysics()
    {
        // Calculo de la escala de gravedad del personaje
        Vector3 newGravity = new Vector3(0, (-2 * jumpHeight) / (timeToJumpApex * timeToJumpApex));
        gravityScale.scale = (newGravity.y / Physics.gravity.y) * gravMultiplier;
    }

    void calculateGravity()
    {
        // Velocidad positiva en y
        if (velocity.y > 0.1f)
        {
            if (onGround)
            {
                gravMultiplier = defaultGravityScale;
            }
            else
            {
                if (variableJumpHeight)
                {
                    if (pressingJump && currentlyJumping)
                    {
                        // multiplicador de movimiento ascendente
                        gravMultiplier = upwardMovementMultiplier;
                    }
                    else
                    {
                        // multiplicador descendente si se suelta el salto
                        gravMultiplier = jumpCutOff;
                    }
                }
                else
                {
                    gravMultiplier = upwardMovementMultiplier;
                }
            }
        }
        else if (rb3D.velocity.y < -0.01f)
        {
            if (onGround)
            {
                // No cambiar la gravedad si el personaje si permanece sobre algo 
                gravMultiplier = defaultGravityScale;
            }
            else
            {
                gravMultiplier = downwardMovementMultiplier;
            }
        }
        else
        {
            if (onGround)
            {
                currentlyJumping = false;
            }

            gravMultiplier = defaultGravityScale;
        }
        rb3D.velocity = new Vector3(velocity.x, Mathf.Clamp(velocity.y, -speedLimit, 100), velocity.z);
    }

    void DoAJump()
    {
        // Ejecutar salto si toco el suelo o estoy en coyoteTime
        if (onGround || (coyoteTimeCounter > 0.03f && coyoteTimeCounter < coyoteTime))
        {
            desiredJump = false;
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;

            // calculo de la fuerza del salto, en base a la gravedad del personaje y atributos
            jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * gravityScale.scale * jumpHeight);

            // Si el personaje tiene una velocidad en "y" negativa o positiva, hay que cambiar jumpSpeed
            if (velocity.y > 0f)
            {
                // Contraresya la velocidad positica en "y" previa a realizar el salto
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0);
            }
            else if (velocity.y < 0f)
            {
                // Contraresta la velocidad negativa en "y" previa a realizar el salto
                jumpSpeed += Mathf.Abs(rb3D.velocity.y);
            }

            velocity.y += jumpSpeed;

            currentlyJumping = true;
            
            if (jumpBuffer == 0)
            {
                desiredJump = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb3D;
    Grounded ground;
    Vector3 inputVector;
    Vector3 velocity;
    Vector3 desiredVelocity;

    Vector3 moveDirection;

    Vector2 inputMovement;

    public bool onGround;
    public bool useAcceleration = true;

    float acceleration;
    float deceleration;
    float turnSpeed;
    public float maxSpeedChange;

    public float maxSpeed = 10f;
    public float maxAcceleration = 52f;
    public float maxDecceleration = 52f;
    public float maxTurnSpeed = 80f;
    public float maxAirAcceleration;
    public float maxAirDeceleration;
    public float maxAirTurnSpeed = 80f;
    private float friction;
    public Transform orientation;

    public bool move_X_Block = false;
    public bool move_Z_Block = false;


    public bool pressingKey;

    void Awake()
    {
        rb3D = GetComponent<Rigidbody>();
        ground = GetComponent<Grounded>();
    }

    public void OnMovement(InputValue value)
    {
        //Debug.Log("MOVIENDOMEEEEEEEEEEEEEEEEEEEEEE");
        inputMovement = value.Get<Vector2>();
        //moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //inputVector = new Vector3(inputMovement.x, 0, inputMovement.y);

        //inputVector = (orientation.forward * inputMovement.y + orientation.right * inputMovement.x).normalized;
    }

    void Update()
    {
        if (inputVector.x != 0 || inputVector.y != 0)
        {
            pressingKey = true;
        }
        else
        {
            pressingKey = false;
        }

        // bloquo movimiento topolino
        if (move_X_Block == true)
        {
            desiredVelocity = new Vector3(0f, 0f, inputVector.z) * Mathf.Max(maxSpeed - friction, 0f);
        }
        else if (move_Z_Block == true)
        {
            desiredVelocity = new Vector3(inputVector.x, 0f, 0f) * Mathf.Max(maxSpeed - friction, 0f);
        }
        else
        {
            desiredVelocity = new Vector3(inputVector.x, 0f, inputVector.z) * Mathf.Max(maxSpeed - friction, 0f);
        }

        
    }

    void FixedUpdate()
    {
        inputVector = (orientation.forward * inputMovement.y + orientation.right * inputMovement.x).normalized;

        onGround = ground.GetOnGround();

        velocity = rb3D.velocity;

        if (useAcceleration)
        {
            runWithAcceleration();
        }
        else
        {
            if (onGround)
            {
                runWithoutAcceleration();
            }
            else
            {
                runWithAcceleration();
            }
        }
    }

    void runWithoutAcceleration()
    {
        velocity.x = desiredVelocity.x;
        velocity.z = desiredVelocity.z;

        rb3D.velocity = velocity;
    }

    void runWithAcceleration()
    {
        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        deceleration = onGround ? maxDecceleration : maxAirDeceleration;
        turnSpeed = onGround ? maxTurnSpeed : maxAirTurnSpeed;

        if (pressingKey)
        {
            if (Mathf.Sign(inputVector.x) != Mathf.Sign(velocity.x))
            {
                maxSpeedChange = turnSpeed * Time.deltaTime;
            }
            else
            {
                maxSpeedChange = acceleration * Time.deltaTime;
            }
            if (Mathf.Sign(inputVector.z) != Mathf.Sign(velocity.z))
            {
                maxSpeedChange = turnSpeed * Time.deltaTime;
            }
            else
            {
                maxSpeedChange = acceleration * Time.deltaTime;
            }
        }
        else
        {
            maxSpeedChange = deceleration * Time.deltaTime;
        }

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

        rb3D.velocity = velocity;
    }
}

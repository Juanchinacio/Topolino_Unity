using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class new_PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;
    public float rotationSpeed;
    public float groundDrag;
    public float iceDrag = 0f;
    public float airDrag = 2f;
    public float fangoDrag = 6f;

    [Header("Ground Checker")]
    public LayerMask whatIsGround;
    public Grounded groundChecker;
    

    [Header("Transforms")]
    public Transform Camera_Direction;
    public Transform player_Transform;
    public Transform player_Direction;
    public Transform cameraTransform;   // Para que la direccion rote hacia donde mira la camara
    Transform other_Direction;



    [Header("Debug")]
    public bool MoveBlock_Z = false;
    public bool MoveBlock_X = false;
    public bool otherPlayerViewDirection = false;
    public Transform otherViewDirection;
    public bool grounded;

    [Header("Animator")]
    public Animator _animator;
    private int _idRun;

    Rigidbody rb;
    Vector2 inputMovement;

    void Start()
    {
        //cameraTransform = Camera.main.transform;
        rb = transform.GetComponent<Rigidbody>();
        //groundChecker = GetComponent<Grounded>();

        _idRun = Animator.StringToHash("isRunning");


    }
    void Update()
    {
        // Control de velocidad
        SpeedControl();

        // Comprobar si esta en el suelo
        grounded = groundChecker.GetOnGround();

        //Aplicar drag
        if (grounded)
        {
            if (groundChecker.GetGroundTag() == "Ice")
            {
                rb.drag = iceDrag;
            }
            else if (groundChecker.GetGroundTag() == "Fango")
            {
                rb.drag = fangoDrag;
            }
            else
            {
                rb.drag = groundDrag;
            }
        }
        else
        {
            rb.drag = airDrag;
        }


        // Rotar orientacion
        if (otherPlayerViewDirection == false)
        {
            Vector3 viewDir = player_Transform.position - new Vector3(cameraTransform.position.x, player_Transform.position.y, cameraTransform.position.z);
            Camera_Direction.forward = viewDir.normalized;
        }
        else
        {
            player_Direction.LookAt(new Vector3(otherViewDirection.position.x, player_Direction.position.y, otherViewDirection.position.z));
        }
        


        // Rotar el modelo del jugador
        Vector3 inputDir = Camera_Direction.forward * inputMovement.y + Camera_Direction.right * inputMovement.x;

        if (inputDir != Vector3.zero)
        {
            player_Direction.forward = Vector3.Slerp(player_Direction.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
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
        Vector3 moveDirection;
        if (MoveBlock_X)
        {
            moveDirection = other_Direction.right * 0 + other_Direction.forward * inputMovement.y;
        }
        else if (MoveBlock_Z)
        {
            moveDirection = other_Direction.right * inputMovement.x + other_Direction.forward * 0;
        }
        else
        {
            moveDirection = Camera_Direction.right * inputMovement.x + Camera_Direction.forward * inputMovement.y;
        }

        if (moveDirection != Vector3.zero)
            _animator.SetBool(_idRun, true);
        else
            _animator.SetBool(_idRun, false);

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
    public void Set_MoveBlock_Z(bool _MoveBlock_Z) { MoveBlock_Z = _MoveBlock_Z; MoveBlock_X = false; }
    public void Set_MoveBlock_X(bool _MoveBlock_X) { MoveBlock_X = _MoveBlock_X; MoveBlock_Z = false; }

    public void Set_Other_Direction(Transform _other_Direction) { other_Direction = _other_Direction; }

    public void Set_OtherPlayerViewDirection(bool _otherPlayerViewDirection) { otherPlayerViewDirection = _otherPlayerViewDirection; }

    public void Set_OtherViewDirection(Transform _otherViewDirection) { otherViewDirection = _otherViewDirection; }
    public Transform Get_OtherViewDirection() { return otherViewDirection; }

}

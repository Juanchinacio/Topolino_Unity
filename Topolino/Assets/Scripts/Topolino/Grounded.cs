using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public GameObject playerRoot;
    public LayerMask groundLayers;
    public bool onGround;
    public string groundTag;

    [Header("Animator")]
    public Animator _animator;
    private int _idJump;
    private void Start()
    {

        _idJump = Animator.StringToHash("isJumping");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _animator.SetBool(_idJump, false);
            onGround = true;
            groundTag = other.gameObject.tag;
        }
        if (other.tag == "PlataformaMovil")
        {
            playerRoot.transform.parent = other.transform;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            onGround = true;
            groundTag = other.gameObject.tag;
        }
        if (other.tag == "PlataformaMovil")
        {
            playerRoot.transform.parent = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            onGround = false;
            groundTag = "null";
        }
        if (other.tag == "PlataformaMovil")
        {
            playerRoot.transform.parent = null;
        }
    }

    public bool GetOnGround() { return onGround; }
    public string GetGroundTag() { return groundTag; }

}

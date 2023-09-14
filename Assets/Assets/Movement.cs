
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    
    public float speed = 2f; //movement speed
    public float jumpPower = 15f; //jump
    public float gravity = -9.81f; //gravity
    public float currentVelY = 0; // Y velocity

    public bool isSprinting = false; //sprint bool
    public float sprintingMultiplier; //sprint speed

    public bool isCrouching = false; //Crouch bool
    public float standingHeight = 1.8f; //standing height
    public float crouchingMultiplier; //Crouch speed
    public float crouchingHeight = 1.25f; //Crouch Height

    public CharacterController controller;
    public LayerMask groundMask;
    public Transform groundDetectionTransform;

    public bool isGrounded; // Ground bool

    private void Start()
    {
       controller = GetComponent<CharacterController>();
    }

//---------------Check Ground--------------------
    public void CheckIsGrounded()
    {
        Collider [] cols = Physics.OverlapSphere(groundDetectionTransform.position, 50f, groundMask);
        
        if (cols.Length > 0)
        {
            isGrounded = true;

        } else {

            isGrounded = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {   
        
//--------------------jump--------------------
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        CheckIsGrounded();

        if (isGrounded == false)
        {

            currentVelY += gravity * Time.deltaTime;

        } else if ( isGrounded == true)
        
        {
            currentVelY = -2f;

        }
    //--------------------jump button--------------------
        if(Input.GetKeyDown("space") && isGrounded == true){

            currentVelY = jumpPower;

        }
    //--------------------sprint--------------------

    //--------------------sprint button--------------------
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;

        } else {
            
            isSprinting = false;

        }
    //-------------------- crouch button--------------------
        if(Input.GetKey(KeyCode.LeftControl)){

            isCrouching = true;

        } else {

            isCrouching = false;

            }
    Vector3 movement = new Vector3();
    movement = horizontal * transform.right + vertical * transform.forward;

        if (isSprinting == true){
            
            movement *= sprintingMultiplier;
        }
//--------------------crouching--------------------

        if (isCrouching == true){
            
            controller.height = crouchingHeight;
            movement *= crouchingMultiplier;

        } else {

            controller.height = standingHeight;

        }
//--------------------handling slopes--------------------
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)){

            controller.slopeLimit = 90f;

        } else {
            
            controller.slopeLimit = 45f;
        }

//--------------------handling stairs--------------------

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W)){

            controller.stepOffset = 0.5f;

        } else {
            
            controller.stepOffset = 0.3f;
        }


//--------------------Character controller--------------------
    controller.Move(movement* speed * Time.deltaTime);
    controller.Move(new Vector3(0, currentVelY * Time.deltaTime,0));

    }

}

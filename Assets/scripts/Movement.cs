using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Transform))]
public class SimpleController : MonoBehaviour
{ 
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = 9.81f;

    private CharacterController controller;
    private bool isGrounded = false;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

            isGrounded = GroundControl();

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        bool wantJump = Input.GetButtonDown("Jump");

   
        if (isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = 0;
        }

    
        if (isGrounded)
        {
            moveDirection = new Vector3(h, moveDirection.y, v).normalized * moveSpeed;

       
            if (h != 0 || v != 0)
            {
                transform.forward = new Vector3(h, 0f, v);
            }
        }

  
        if (isGrounded && wantJump)
        {
            moveDirection.y = Mathf.Sqrt(2f * gravity * jumpHeight);
        }

   
        moveDirection.y -= gravity * Time.deltaTime;

 
        controller.Move(moveDirection * Time.deltaTime);
    }

    private bool GroundControl()
    {
        return Physics.Raycast(
            transform.position + controller.center,                    
            Vector3.down,                                              
            controller.bounds.extents.y + controller.skinWidth + 0.2f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag == "obstacle")
        {

        }
    }
}




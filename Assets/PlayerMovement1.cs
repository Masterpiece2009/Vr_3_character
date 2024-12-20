﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playermovement1 : MonoBehaviour
{

    public float speed = 4f;
    public float gravity = 20f;
    public float jump = 8f;
    public float rotSpeed = 80f;
    float rot = 0f;

    CharacterController controller;

    Animator anam;

    float horizontal;
    float vertical;

    Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anam = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0.0f, vertical);
            moveDirection *= speed;
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Jump"))
            {
                anam.SetBool("IsJumping", true);
                moveDirection.y = jump;
            }
            else
            {
                anam.SetBool("IsJumping", false);
            }

            if (Input.GetKey(KeyCode.W))
            {
                anam.SetBool("IsWalking", true);
            }
            else
            {
                anam.SetBool("IsWalking", false);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);


        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.CompareTag("player"))
    //    {

    //        Destroy(hit.gameObject);

    //    }
    //}
}

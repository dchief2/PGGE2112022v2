using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    [SerializeField]
    float walkingSpeed = 5;
    [SerializeField]
    float rotationSpeed = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        float speed = walkingSpeed;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2.0f * walkingSpeed;
        }

        //rotate player
        transform.Rotate(0.0f, inputH * rotationSpeed * Time.deltaTime, 0.0f);

        Vector3 forward = transform.forward;
        characterController.Move(forward * speed * inputV * Time.deltaTime);

        //applying animations
        animator.SetFloat("PosX", 0.0f);
        animator.SetFloat("PosZ", speed * inputV / (2.0f * walkingSpeed));

    }
}

using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

// taltalyal
public class Player : MonoBehaviour
{
    public int speed = 3;
    float gravity = 7f;
    float verticalSpeed = 0;

    CharacterController controller;

    public GameObject sprite;
    public Camera cam;

    string verticalStateMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        verticalStateMachine = "onGround";
    }


    // Update is called once per frame
    void Update()
    {
        //Movimiento

        Vector2 input = InputSystem.actions["Move"].ReadValue<Vector2>();
        Vector3 forward_dir = cam.transform.forward;
        forward_dir.Normalize();
        Vector3 right_dir = cam.transform.right;
        right_dir.Normalize();

        if (verticalStateMachine == "onAir")
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        if (verticalStateMachine == "onGround")
        {
            verticalSpeed = -1; // por alguna razón la frenada que funciona no es esta, sino la que esta puesta en el state machine
        }
            

        if (InputSystem.actions["jump"].WasPressedThisFrame() && verticalStateMachine == "onGround")
        {
            verticalSpeed = 5;
        }


        Vector3 direction = input.x * right_dir + input.y * forward_dir;
        direction *= speed;
        Vector3 moveDirection = new Vector3(direction.x,verticalSpeed,direction.z);

        controller.Move(moveDirection * speed * Time.deltaTime);
       


        //State Machine

        if (verticalStateMachine == "onGround" && controller.isGrounded == false)
        {
            verticalStateMachine = "leavingGround";
        }
        if (verticalStateMachine == "leavingGround" && controller.isGrounded == false)
        {
            verticalStateMachine = "onAir";
        }
        if (verticalStateMachine == "onAir" && controller.isGrounded == true)
        {
            verticalStateMachine = "landing";
        }
        if (verticalStateMachine == "landing" && controller.isGrounded == true)
        {
            verticalStateMachine = "onGround";
        }


        //Animaciones del sprite 


        //Rotaciones del sprite

        sprite.transform.rotation = cam.transform.rotation;
        Vector3 rot_provisional;
        rot_provisional = sprite.transform.rotation.eulerAngles;
        rot_provisional.x = 0;
        sprite.transform.rotation = Quaternion.Euler(rot_provisional);


        if (InputSystem.actions["Move"].ReadValue<Vector2>().x > 0)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (InputSystem.actions["Move"].ReadValue<Vector2>().x < 0)
        {
            sprite.GetComponent<SpriteRenderer>().flipX = false;
        }
        
    
    }
}

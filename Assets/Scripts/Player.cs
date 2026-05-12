using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

// taltalyal
public class Player : MonoBehaviour
{
    public int speed = 15;
    float gravity = 3f;
    float verticalSpeed = 0;

    public GameObject sprite;
    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

        Vector3 moveDirection = input.x * right_dir + input.y * forward_dir;


        transform.Translate(moveDirection * Time.deltaTime * speed);

        if (InputSystem.actions["jump"].WasPressedThisFrame())
        {
            //AddForce(9)
        }
       
        //State Machine



        //Rotación del sprite

        sprite.transform.rotation = cam.transform.rotation;
        Vector3 rot_provisional;
        rot_provisional = sprite.transform.rotation.eulerAngles;
        rot_provisional.x = 0;
        sprite.transform.rotation = Quaternion.Euler(rot_provisional);

        //Animaciones y espejos sprite

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

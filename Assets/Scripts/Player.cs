using UnityEngine;
using UnityEngine.InputSystem;

// taltalyal
public class Player : MonoBehaviour
{
    public int speed = 5;
    float gravity = 3f;
    float verticalSpeed = 0;

    public GameObject sprite;
    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.sprite.transform.localScale = new Vector3(10f, 10f, 10f);
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 input = InputSystem.actions["Move"].ReadValue<Vector2>();
        Vector2 forward_dir = cam.transform.forward;
        forward_dir.y = 0;
        Vector2 right_dir = cam.transform.right;
        right_dir.y = 0;


        Vector2 moveDirection = input.x * right_dir + input.y * forward_dir;

        transform.Translate(moveDirection * Time.deltaTime * speed);

        
    
        //verticalSpeed -= gravity * Time.deltaTime;
        //verticalSpeed = Mathf.Clamp(verticalSpeed, -10, 0);
        //transform.Translate(0, verticalSpeed * Time.deltaTime, 0);
    }
}

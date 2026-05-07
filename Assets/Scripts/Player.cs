using UnityEngine;
using UnityEngine.InputSystem;

// taltalyal
public class Player : MonoBehaviour
{
    public int speed = 5;
    float gravity = 3f;
    float verticalSpeed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(InputSystem.actions["Move"].ReadValue<Vector2>().x * speed * Time.deltaTime, 0, InputSystem.actions["Move"].ReadValue<Vector2>().y * speed * Time.deltaTime);

        verticalSpeed -= gravity * Time.deltaTime;
        verticalSpeed = Mathf.Clamp(verticalSpeed, -10, 0);
        transform.Translate(0, verticalSpeed * Time.deltaTime, 0);
    }
}

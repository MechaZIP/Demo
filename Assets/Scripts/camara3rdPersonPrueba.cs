using UnityEngine;
using UnityEngine.InputSystem;

public class camara3rdPersonPrueba : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseRot = Mouse.current.delta.ReadValue();
        Vector3 targetRot = transform.rotation.eulerAngles;
        targetRot.z += mouseRot.y * 100f * Time.deltaTime;
        targetRot.y += mouseRot.x * 100f * Time.deltaTime;
        transform.rotation = Quaternion.Euler(targetRot);
    }
}

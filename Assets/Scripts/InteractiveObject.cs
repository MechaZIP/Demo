using UnityEngine;
using UnityEngine.InputSystem;

public class InteractiveObject : MonoBehaviour
{

    bool insideArea;

    public GameObject interactiveObject;
    public string function;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        insideArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.actions["Interact"].WasPressedThisFrame() && insideArea == true)
        {
            UnityEngine.Debug.Log("pressed");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            insideArea = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            insideArea = false;
        }
    }
}

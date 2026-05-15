
using UnityEngine;

public class cameraArea : MonoBehaviour
{
    //Variable de Personaje, Camara
    GameObject jugador;
    GameObject cameraMov;
    private Transform target;
    private Vector3 camRot;
    public GameObject referencia;
    public bool dentroArea = false;
    public float clampMax = 50f;
    public float clampMin = 50f;
    GameObject triggers;
    void Start()
    {
        jugador = GameObject.FindWithTag("Player");
        cameraMov = GameObject.FindWithTag("MainCamera");
        target = referencia.transform;
        clampMax = target.transform.eulerAngles.y + clampMax;
        clampMin = target.transform.eulerAngles.y - clampMin;
        triggers = GameObject.FindWithTag("Triggers");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            //areaController.seleccionArea(this);
           //Debug.Log(gameObject.name);
           triggers.GetComponent<areaController>().seleccionArea(gameObject);
           cameraMov.transform.position = target.position;

        }
    }

    void Update()
    {
        if (dentroArea)
        {
            Debug.Log(dentroArea);
            cameraMov.transform.LookAt(jugador.transform);
            camRot = cameraMov.transform.eulerAngles;
            camRot.x = 0;
            camRot.z = 0;
            camRot.y = Mathf.Clamp(camRot.y,clampMin,clampMax);
            cameraMov.transform.rotation = Quaternion.Euler(camRot);
            Debug.Log(Mathf.Clamp(camRot.y,clampMin,clampMax));
        }
    }
}

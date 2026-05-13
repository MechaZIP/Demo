
using UnityEngine;

public class areaController : MonoBehaviour
{
    GameObject Area;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void seleccionArea(GameObject targetArea)
    {

        Area = targetArea;

        for(int i = 0; i < this.transform.childCount; i++)
        {

            if(this.transform.GetChild(i).name == Area.name)
            {
                this.transform.GetChild(i).GetComponent<cameraArea>().dentroArea = true;
                Debug.Log(Area.name+" "+this.transform.GetChild(i).name);
            }
            else
            {
                this.transform.GetChild(i).GetComponent<cameraArea>().dentroArea = false;
            }
            
        }
    } 
}

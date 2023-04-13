using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject cameraa;
    public bool pickUp;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Physics.Raycast(cameraa.transform.position, cameraa.transform.forward, out hit, 3))
            {
                if(pickUp == true)
                {
                    
                    if (hit.transform.tag == "Deur")
                    {
                        pickUp = false;
                        Destroy(hit.transform.gameObject);
                    }
                }
                
               

                if (hit.transform.tag == "Sleutel") 
                {
                    Destroy(hit.transform.gameObject);
                    pickUp = true;
                }
            }
        } 
        
    }
    
}

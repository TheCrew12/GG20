using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
 RaycastHit hit;
         
 if( Physics.Raycast(ray, out hit, 100) )
     Debug.DrawLine(ray.origin, hit.point, Color.green);
 
             // Allows zooming in and out via the mouse wheel
             if(Input.GetAxis("Mouse ScrollWheel") < 0)
             {
                 transform.Translate(0, 1, 0, Space.World);
                 transform.position = new Vector3 (transform.position.x ,Mathf.Clamp(transform.position.y,6,10), transform.position.z) ;                    
             }                
             if(Input.GetAxis("Mouse ScrollWheel") > 0)
             {
                 transform.Translate(0,-1,0, Space.World);
                 transform.position = new Vector3 (hit.point.x ,Mathf.Clamp(transform.position.y,6,10), hit.point.z);
             }

    }
}

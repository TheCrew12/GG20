using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnCharacter : MonoBehaviour
{
    // Start is called before the first frame update
   
   public GameObject monster;
   private bool toggle = true;
    void Start()                                                        
    {
    
    }

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(toggle)
                {
                     monster.SetActive(!monster.activeSelf);  
                     toggle = false; 
                }
                else{
                    monster.SetActive(monster.activeSelf);
                     toggle = true;   
                }
            }      
    }
    
}

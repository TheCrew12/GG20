using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Monster")
        {
            other.gameObject.GetComponent<MonsterScript>().Burn();
        }
    }
}

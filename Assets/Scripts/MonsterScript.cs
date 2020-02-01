using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Gets all the body parts of a monster
    public List<PartScript> GetBodyParts()
    {
        List<PartScript> parts = new List<PartScript>();

        foreach (Transform child in this.transform)
        {
            var part = child.GetComponent<PartScript>();
            if(part != null) { parts.Add(part); }
        }

        return parts;
    }
}

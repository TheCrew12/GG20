using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotelScript : MonoBehaviour
{
    public void MakeBaby( MonsterScript parent1, MonsterScript parent2 )
    {
        List<PartScript> parts = new List<PartScript>();
        parts.AddRange(parent1.GetBodyParts());
        parts.AddRange(parent2.GetBodyParts());

        
    }
}

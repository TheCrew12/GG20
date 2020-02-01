using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotelScript : MonoBehaviour
{
    private List<MonsterScript> monstersInMotel;

    void Start() 
    {
        monstersInMotel = new List<MonsterScript>();
    }

    public void MakeBaby( MonsterScript parent1, MonsterScript parent2 )
    {
        List<PartScript> parts = new List<PartScript>();
        parts.AddRange(parent1.GetBodyParts());
        parts.AddRange(parent2.GetBodyParts());

        parts = Utils.Shuffle<PartScript>(parts); //Randomize parts

        //Attach bodyparts
        foreach (Transform child in this.transform)
        {
            var part = child.GetComponent<PartScript>();
            var type = part.type;

            foreach( PartScript parentPart in parts )
            {
                if( parentPart.type.Equals(type) )
                {
                    child = parentPart;
                    break;
                }
            }
        }
    }
}

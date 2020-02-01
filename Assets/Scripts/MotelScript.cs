using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotelScript : MonoBehaviour
{
    public int CoolDown = 60;
    public GameObject monster;
    private List<MonsterScript> monstersInMotel;
    private int Timer = -1;

    void Start() 
    {
        monstersInMotel = new List<MonsterScript>();
    }

    private void Update() 
    {
        if(Timer > -1 && Timer < CoolDown)
        {
            Timer++;
        }
        if(Timer >= CoolDown)
        {
            Timer = -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(Timer > -1) {return;}

        var monster = other.gameObject.GetComponent<MonsterScript>();
        if(monster == null ) {return;} //ITS NOT A MONSTER
        if(monster.isInMotel) {return;} //ITS ALLREADY IN THE MOTEL

        monster.isInMotel = true;
        monster.canMove = false;
        monstersInMotel.Add(monster);

        //THE HOTEL IS FULL GET TO THE MAKING
        if(monstersInMotel.Count >= 2)
        {
            MakeBaby(monstersInMotel[0], monstersInMotel[1]);
            foreach(MonsterScript motelMonster in monstersInMotel) { motelMonster.isInMotel = false; monster.canMove = true; }
            monstersInMotel.Clear();
            Timer = 0;
        }
    }

    public void MakeBaby( MonsterScript parent1, MonsterScript parent2 )
    {
        List<PartScript> parts = new List<PartScript>();
        parts.AddRange(parent1.GetBodyParts());
        parts.AddRange(parent2.GetBodyParts());

        parts = Utils.Shuffle<PartScript>(parts); //Randomize parts

        var baby = Instantiate(monster);

        //Attach bodyparts
        foreach (Transform child in baby.transform)
        {
            var part = child.GetComponent<PartScript>();
            if(part == null) {Debug.Log("MMMOOXX");}
            var type = part.type;

            foreach( PartScript parentPart in parts )
            {
                if( parentPart.type.Equals(type) )
                {
                    //child = parentPart;
                    break;
                }
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotelScript : MonoBehaviour
{
    public int CoolDown = 60;
    public int BirthDelay = 10;
    public float BirthScale = 0.001f;
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

    void OnTriggerStay2D(Collider2D other)
    {
        if(Timer > -1) {return;}

        var monster = other.gameObject.GetComponent<MonsterScript>();

        if(monster.transform.localScale.x < monster.AdultAgeScale) {return;}//TOO YOUNG
        if(monster == null ) {return;} //ITS NOT A MONSTER
        if(monster.isInMotel) {return;} //ITS ALLREADY IN THE MOTEL

        other.gameObject.transform.position = new Vector2(1000,1000);

        monster.isInMotel = true;
        monster.canMove = false;
        monstersInMotel.Add(monster);

        //THE HOTEL IS FULL GET TO THE MAKING
        if(monstersInMotel.Count >= 2)
        {
            MakeBaby(monstersInMotel[0], monstersInMotel[1]);
            foreach(MonsterScript motelMonster in monstersInMotel) 
            { 
                motelMonster.isInMotel = false;
                monster.canMove = true;
                motelMonster.transform.position = this.transform.position;
            }
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

        var baby = Instantiate(monster, this.transform.position, new Quaternion());
        baby.transform.localScale = new Vector3(BirthScale,BirthScale,BirthScale);

        //Attach bodyparts
        foreach (Transform child in baby.transform)
        {
            var part = child.GetComponent<PartScript>();
            if(part == null) {return;}
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

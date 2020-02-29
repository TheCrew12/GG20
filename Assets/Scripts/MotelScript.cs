using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotelScript : MonoBehaviour
{
    public float AgeToBreed = 0.15f;
    public int CoolDown = 60;
    public float BirthScale = 0.001f;
    public int ClicksForBirth = 10;
    public GameObject monster;
    public GameObject returnPoint;
    public ParticleSystem loveParticles;
    public AudioSource EnterSound;
    private List<MonsterScript> monstersInMotel;
    private int Timer = -1;
    private int ClickCounter = 0;

    private Shaker shaker;

    void Start() 
    {
        monstersInMotel = new List<MonsterScript>();
        shaker = GetComponent<Shaker>();
        loveParticles.Stop();
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
        if (monstersInMotel.Count >= 2)
        {
            return; //No more monsters in motel
        }

        var monster = other.gameObject.GetComponent<MonsterScript>();
        if(monster == null) {return;}

        if(monster.transform.localScale.x < AgeToBreed) {return;}//TOO YOUNG
        if(monster == null ) {return;} //ITS NOT A MONSTER
        if(monster.isInMotel) {return;} //ITS ALLREADY IN THE MOTEL

        other.gameObject.transform.position = new Vector2(1000,1000);

        monster.isInMotel = true;
        monster.canMove = false;
        monstersInMotel.Add(monster);
        EnterSound.Play();

        if(monstersInMotel.Count >= 2)
        {
            shaker.CanShake = true;
            loveParticles.Play();
        }
    }

    void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(monstersInMotel.Count >= 2)
            {
                ClickCounter++;
                if(ClickCounter > ClicksForBirth)
                {
                    MakeBaby(monstersInMotel[0], monstersInMotel[1]);
                    foreach(MonsterScript motelMonster in monstersInMotel) 
                    { 
                        motelMonster.isInMotel = false;
                        motelMonster.canMove = true;
                        motelMonster.transform.position = returnPoint.transform.position;
                    }
                    monstersInMotel.Clear();
                    loveParticles.Stop();
                    shaker.CanShake = false;
                    Timer = 0;
                    ClickCounter = 0;
                }
            }
        }
    }

    private void MakeBaby( MonsterScript parent1, MonsterScript parent2 )
    {
        var parentParts = new List<PartScript>();
        parentParts.AddRange(parent1.GetBodyParts());
        parentParts.AddRange(parent2.GetBodyParts());
        parentParts = Utils.Shuffle(parentParts); //Randomize parts

        var baby = Instantiate(monster, returnPoint.transform.position, new Quaternion());
        baby.transform.localScale = new Vector3(BirthScale,BirthScale,BirthScale);
        var babyMonsterScript = baby.GetComponent<MonsterScript>();
        
        //Attach bodyparts
        foreach (var babyPart in babyMonsterScript.GetBodyParts())
        {
            for(var i = parentParts.Count-1 ; i >= 0 ; i--)
            {
                var parentPart = parentParts[i];
                if(parentPart == null) {continue;}
                if( parentPart.type.Equals(babyPart.type) )
                {
                    babyPart.SetPartImage(parentPart.GetPartImage());
                    parentParts[i] = null;
                    break;
                }
            }
        }
    }
}

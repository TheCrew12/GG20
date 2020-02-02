using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazaScript : MonoBehaviour
{
    public GameObject monster;

    Object[] arms;
    Object[] bodys;
    Object[] boobs;
    Object[] crotchs;
    Object[] ears;
    Object[] eyes;
    Object[] hairs;
    Object[] heads;
    Object[] legs;
    Object[] mouths;
    Object[] noses;

    void Start()
    {
        arms = Resources.LoadAll("Images/BodyParts/Arms", typeof(Sprite));
        bodys = Resources.LoadAll("Images/BodyParts/Bodys", typeof(Sprite));
        boobs = Resources.LoadAll("Images/BodyParts/Boobs", typeof(Sprite));
        crotchs = Resources.LoadAll("Images/BodyParts/Crotch", typeof(Sprite));
        ears = Resources.LoadAll("Images/BodyParts/Ear", typeof(Sprite));
        eyes = Resources.LoadAll("Images/BodyParts/Eye", typeof(Sprite));
        hairs = Resources.LoadAll("Images/BodyParts/Hair", typeof(Sprite));
        heads = Resources.LoadAll("Images/BodyParts/Heads", typeof(Sprite));
        legs = Resources.LoadAll("Images/BodyParts/Legs", typeof(Sprite));
        mouths = Resources.LoadAll("Images/BodyParts/Mouths", typeof(Sprite));
        noses = Resources.LoadAll("Images/BodyParts/Noses", typeof(Sprite));

        StartUpStuff();
    }
    void Update()
    {
        
    }

    private void StartUpStuff()
    {
        SpawnRandomMonster();
        SpawnRandomMonster();
        SpawnRandomMonster();
    }

    private void SpawnRandomMonster()
    {
        var baby = Instantiate(monster, this.transform.position, new Quaternion());

        foreach (Transform child in baby.transform)
        {
            var part = child.GetComponent<PartScript>();
            if(part == null) {return;}
            var type = part.type;

            switch (type)
            {
                case BodyPartType.Arm:
                    part.PartImage = GetRandomArm(); break;
                case BodyPartType.Body:
                    part.PartImage = GetRandomBody(); break;
                case BodyPartType.Boob:
                    part.PartImage = GetRandomBoob(); break;
                case BodyPartType.Crotch:
                    part.PartImage = GetRandomCrotch(); break;
                case BodyPartType.Ear:
                    part.PartImage = GetRandomEar(); break;
                case BodyPartType.Eye:
                    part.PartImage = GetRandomEye(); break;
                case BodyPartType.Hair:
                    part.PartImage = GetRandomHair(); break;
                case BodyPartType.Leg:
                    part.PartImage = GetRandomLeg(); break;
                case BodyPartType.Mouth:
                    part.PartImage = GetRandomMouth(); break;
                case BodyPartType.Nose:
                    part.PartImage = GetRandomNose(); break;
            }
        }
    }

    public Sprite GetRandomArm(){ return (Sprite)arms[Random.Range(0, arms.Length)]; }
    public Sprite GetRandomBody(){ return (Sprite)bodys[Random.Range(0, bodys.Length)]; }
    public Sprite GetRandomBoob(){ return (Sprite)boobs[Random.Range(0, boobs.Length)]; }
    public Sprite GetRandomCrotch(){ return (Sprite)crotchs[Random.Range(0, crotchs.Length)]; }
    public Sprite GetRandomEar(){ return (Sprite)ears[Random.Range(0, ears.Length)]; }
    public Sprite GetRandomEye(){ return (Sprite)eyes[Random.Range(0, eyes.Length)]; }
    public Sprite GetRandomHair(){ return (Sprite)hairs[Random.Range(0, hairs.Length)]; }
    public Sprite GetRandomHead(){ return (Sprite)heads[Random.Range(0, heads.Length)]; }
    public Sprite GetRandomLeg(){ return (Sprite)legs[Random.Range(0, legs.Length)]; }
    public Sprite GetRandomMouth(){ return (Sprite)mouths[Random.Range(0, mouths.Length)]; }
    public Sprite GetRandomNose(){ return (Sprite)noses[Random.Range(0, noses.Length)]; }
}

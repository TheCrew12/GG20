using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlazaLoader
{
    public static Object[] arms;
    public static Object[] bodys;
    public static Object[] boobs;
    public static Object[] crotchs;
    public static Object[] ears;
    public static Object[] eyes;
    public static Object[] hairs;
    public static Object[] hands;
    public static Object[] heads;
    public static Object[] legs;
    public static Object[] mouths;
    public static Object[] noses;

    public static Sprite GetRandomArm(){ return (Sprite)arms[Random.Range(0, arms.Length)]; }
    public static Sprite GetRandomBody(){ return (Sprite)bodys[Random.Range(0, bodys.Length)]; }
    public static Sprite GetRandomBoob(){ return (Sprite)boobs[Random.Range(0, boobs.Length)]; }
    public static Sprite GetRandomCrotch(){ return (Sprite)crotchs[Random.Range(0, crotchs.Length)]; }
    public static Sprite GetRandomEar(){ return (Sprite)ears[Random.Range(0, ears.Length)]; }
    public static Sprite GetRandomEye(){ return (Sprite)eyes[Random.Range(0, eyes.Length)]; }
    public static Sprite GetRandomHair(){ return (Sprite)hairs[Random.Range(0, hairs.Length)]; }
    public static Sprite GetRandomHand(){ return (Sprite)hands[Random.Range(0, hands.Length)]; }
    public static Sprite GetRandomHead(){ return (Sprite)heads[Random.Range(0, heads.Length)]; }
    public static Sprite GetRandomLeg(){ return (Sprite)legs[Random.Range(0, legs.Length)]; }
    public static Sprite GetRandomMouth(){ return (Sprite)mouths[Random.Range(0, mouths.Length)]; }
    public static Sprite GetRandomNose(){ return (Sprite)noses[Random.Range(0, noses.Length)]; }

    public static Sprite GetRandomPartOfType( BodyPartType type )
    {
        switch (type)
        {
            case BodyPartType.Arm:
                return GetRandomArm(); break;
            case BodyPartType.Body:
                return GetRandomBody(); break;
            case BodyPartType.Boob:
                return GetRandomBoob(); break;
            case BodyPartType.Crotch:
                return GetRandomCrotch(); break;
            case BodyPartType.Ear:
                return GetRandomEar(); break;
            case BodyPartType.Eye:
                return GetRandomEye(); break;
            case BodyPartType.Hair:
                return GetRandomHair(); break;
            case BodyPartType.Leg:
                return GetRandomLeg(); break;
            case BodyPartType.Mouth:
                return GetRandomMouth(); break;
            case BodyPartType.Nose:
                return GetRandomNose(); break;
            case BodyPartType.Head:
                return GetRandomHead(); break;
            case BodyPartType.Hand:
                return GetRandomHand(); break;
            default:
                return GetRandomArm();
        }
    }
}

public class PlazaScript : MonoBehaviour
{
    public GameObject monster;

    void Start()
    {
        PlazaLoader.arms = Resources.LoadAll("Images/BodyParts/Arms", typeof(Sprite));
        PlazaLoader.bodys = Resources.LoadAll("Images/BodyParts/Bodys", typeof(Sprite));
        PlazaLoader.boobs = Resources.LoadAll("Images/BodyParts/Boobs", typeof(Sprite));
        PlazaLoader.crotchs = Resources.LoadAll("Images/BodyParts/Crotch", typeof(Sprite));
        PlazaLoader.ears = Resources.LoadAll("Images/BodyParts/Ear", typeof(Sprite));
        PlazaLoader.eyes = Resources.LoadAll("Images/BodyParts/Eye", typeof(Sprite));
        PlazaLoader.hairs = Resources.LoadAll("Images/BodyParts/Hair", typeof(Sprite));
        PlazaLoader.hands = Resources.LoadAll("Images/BodyParts/Hand", typeof(Sprite));
        PlazaLoader.heads = Resources.LoadAll("Images/BodyParts/Heads", typeof(Sprite));
        PlazaLoader.legs = Resources.LoadAll("Images/BodyParts/Legs", typeof(Sprite));
        PlazaLoader.mouths = Resources.LoadAll("Images/BodyParts/Mouths", typeof(Sprite));
        PlazaLoader.noses = Resources.LoadAll("Images/BodyParts/Noses", typeof(Sprite));

        //StartUpStuff();
    }

    private void StartUpStuff()
    {
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
            part.SetPartImage(PlazaLoader.GetRandomPartOfType(type));
        }
    }
}

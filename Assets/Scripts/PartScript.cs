using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyPartType
{
    Head,
    Body,
    Leg,
    Arm,
    Eye,
    Nose,
    Mouth,
    Boob,
    Ear,
    Hair,
    Crotch,
    Hand
}

public class PartScript : MonoBehaviour
{
    public Sprite PartImage;
    public BodyPartType type;
    public int dominance = 100; //How lightly is this part to show up v being recessive
    public float heightScale = 1; // How high is the image
    public float widthScale = 1; // How wide is the image
    public bool invert = false;

    private SpriteRenderer sp;

    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sp.sprite = PartImage;
        if(invert) { sp.flipX = true; }
    }
}

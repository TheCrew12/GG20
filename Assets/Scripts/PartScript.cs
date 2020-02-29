using System;
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

public enum BodyPartSide
{
    Center,
    Left,
    Right
}

public class PartScript : MonoBehaviour
{
    private Sprite partImage;
    public BodyPartType type;
    public BodyPartSide side = BodyPartSide.Center;
    public bool invert = false;

    private SpriteRenderer sp;

    void Start()
    {
        sp = this.GetComponent<SpriteRenderer>();
        if(invert) { sp.flipX = true; }
    }

    public void SetPartImage(Sprite newImage) => partImage = newImage;

    public void Update() => sp.sprite = partImage;
}

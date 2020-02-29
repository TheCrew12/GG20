using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float stepSize = 0.2f;
    public bool isInMotel = false;
    public bool canMove = true;

    public int StepTime = 30;
    public int counter = 0;

    public Vector2 UpperLeft = new Vector2(-10, 4);
    public Vector2 LowerRight = new Vector2(10, -4);

    //Age system
    public float AdultAgeScale = 0.15f;
    public float AgeUpScaleStep = 0.01f;
    public int AgeUpRate = 30;
    private float age = 0;
    private int ageCounter = 0;

    void FixedUpdate()
    {
        if(ageCounter < AgeUpRate)
        {
            ageCounter++;
        }
        else
        {
            ageCounter = 0;
            age++;
            var scale = this.transform.localScale.x + AgeUpScaleStep;
            if(this.transform.localScale.x < AdultAgeScale)
            {
                this.transform.localScale = new Vector3(scale,scale,scale);
            }
        }

        if(canMove && counter > StepTime)
        {
            RandomMovement();
            counter = 0;
        }

        counter++;
    }

    //Gets all the body parts of a monster
    public List<PartScript> GetBodyParts()
    {
        return GetAllBodyParts(transform);
    }
    
    private static List<PartScript> GetAllBodyParts(Transform body)
    {
        var parts = new List<PartScript>();
        
        foreach (Transform child in body)
        {
            var part = child.GetComponent<PartScript>();
            if(part != null) { parts.Add(part); }

            parts.AddRange(GetAllBodyParts(child));
        }

        return parts;
    }

    private int direction;
    private void RandomMovement()
    {
        //Process direction movement
        switch (direction)
        {
            case 0:
                if(transform.position.x < LowerRight.x) {
                transform.position = new Vector2(transform.position.x + stepSize, transform.position.y); }
                break;
            case 1:
                if(transform.position.x > UpperLeft.x) {
                transform.position = new Vector2(transform.position.x - stepSize, transform.position.y);}
                break;
            case 2:
                if(transform.position.y < UpperLeft.y) {
                transform.position = new Vector2(transform.position.x, transform.position.y + stepSize);}
                break;
            case 3:
                if(transform.position.y > LowerRight.y) {
                transform.position = new Vector2(transform.position.x, transform.position.y - stepSize);}
                break;

        }

        direction = Random.Range(0,4);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Monster")
        {
            FindObjectOfType<AudioSource>().Play();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Monster")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}

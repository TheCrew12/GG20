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

    void Start()
    {
        
    }

    void Update()
    {
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
        List<PartScript> parts = new List<PartScript>();

        foreach (Transform child in this.transform)
        {
            var part = child.GetComponent<PartScript>();
            if(part != null) { parts.Add(part); }
        }

        return parts;
    }

    private int direction;
    public void RandomMovement()
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
}

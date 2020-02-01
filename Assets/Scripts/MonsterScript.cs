using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float stepSize = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        RandomMovement();
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
                transform.position = new Vector2(transform.position.x + stepSize, transform.position.y);
                break;
            case 1:
                transform.position = new Vector2(transform.position.x - stepSize, transform.position.y);
                break;
            case 2:
                transform.position = new Vector2(transform.position.x, transform.position.y + stepSize);
                break;
            case 3:
                transform.position = new Vector2(transform.position.x, transform.position.y - stepSize);
                break;

        }

        direction = Random.Range(0,3);
    }
}

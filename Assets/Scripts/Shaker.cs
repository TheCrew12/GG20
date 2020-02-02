using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{

    public float initPower;
    public float power = 0.7f;
    public float duration = 3f;
    public Transform shake;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    public float durationAffector = 0.1f;
    public float powerAffector = 0.2f;

    Vector3 startPosition;
    float initialDuration;
    public bool CanShake = true;


    // Start is called before the first frame update
    void Start()
    {
        shake = gameObject.transform; 
        startPosition = shake.localPosition;
        initialDuration = duration;
        initPower = power;
    }

    // Update is called once per frame
    void Update()
    {
        if(!CanShake) {return;}

        if(shouldShake)
        {
            if(duration > 0)
            {
                shake.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                duration = initialDuration;
                power = initPower;
                shake.localPosition = startPosition;
                shouldShake = false;

            }
        }
    }

    void OnMouseDown() 
    {
        if(Input.GetMouseButton(0))
        {
            shouldShake = true;
            power += 0.2f;
            duration = initialDuration;
        }
        
    }
}

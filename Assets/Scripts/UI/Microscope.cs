using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microscope : MonoBehaviour
{
    Camera myCam;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = mousePos;
    }
}

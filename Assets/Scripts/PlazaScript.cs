using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlazaScript : MonoBehaviour
{
    Object[] heads;

    void Start()
    {
        heads = Resources.LoadAll("Images/BodyParts/Heads", typeof(Texture2D));
        Debug.Log(heads.Length);
    }
    void Update()
    {
        
    }
}

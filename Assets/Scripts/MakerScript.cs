using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerScript : MonoBehaviour
{
    public List<PartSwap> swapParts;
    public Vector3 SpawnPoint;
    public GameObject monster;

    public void MakeDaMonster()
    {
        var baby = Instantiate(monster, SpawnPoint, new Quaternion());

        foreach (Transform child in baby.transform)
        {
            var part = child.GetComponent<PartScript>();
            if(part == null) {return;}
            var type = part.type;
            foreach( PartSwap swapPart in swapParts )
            {
                if(swapPart.type.Equals(type)) { part.PartImage = swapPart.GetSelectedPart(); break; }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

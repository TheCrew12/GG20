using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakerScript : MonoBehaviour
{
    public Button makeButton;
    public Button closeButton;
    public Button randomButton;
    
    public List<PartSwap> swapParts;
    public GameObject SpawnPoint;
    public GameObject monster;
    public GameObject monsterMakerUI;

    void Start()
    {
        makeButton.onClick.AddListener(MakeDaMonster);
        closeButton.onClick.AddListener(CloseMenuOk);
        randomButton.onClick.AddListener(RandomizerOfMonsters);
    }
    
    private void MakeDaMonster()
    {
        var baby = Instantiate(monster, SpawnPoint.transform.position, new Quaternion());
        var babyMonsterScript = baby.GetComponent<MonsterScript>();
        
        foreach (var part in babyMonsterScript.GetBodyParts())
        {
            var type = part.type;
            var side = part.side;
            foreach( PartSwap swapPart in swapParts )
            {
                if (side.Equals(swapPart.side) && swapPart.type.Equals(type))
                {
                    part.SetPartImage(swapPart.GetSelectedPart());
                    break;
                }
            }
        }
        
        monsterMakerUI.SetActive(false);
    }

    private void CloseMenuOk()
    {
        monsterMakerUI.SetActive(false);
    }
    
    private void RandomizerOfMonsters()
    {
        foreach (var part in swapParts)
        {
            part.RandomisePart();
        }
    }
}

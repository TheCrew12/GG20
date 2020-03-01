using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MakerScript : MonoBehaviour
{
    public Button makeButton;
    public Button closeButton;
    public Button randomButton;
    public TMP_InputField nameBox;
    
    public List<PartSwap> swapParts;
    public GameObject SpawnPoint;
    public GameObject monster;
    public float BirthScale = 0.001f;
    public GameObject monsterMakerUI;

    void Start()
    {
        makeButton.onClick.AddListener(MakeDaMonster);
        closeButton.onClick.AddListener(CloseMenuOk);
        randomButton.onClick.AddListener(RandomizerOfMonsters);
        
        nameBox.text = Utils.GetRandomFirstName() + " " + Utils.GetRandomLastName();
    }
    
    private void MakeDaMonster()
    {
        var baby = Instantiate(monster, SpawnPoint.transform.position, new Quaternion());
        baby.transform.localScale = new Vector3(BirthScale,BirthScale,BirthScale);
        var babyMonsterScript = baby.GetComponent<MonsterScript>();

        var name = ParseName();
        babyMonsterScript.FirstName = name.Item1;
        babyMonsterScript.LastName = name.Item2;
        
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

    private (string,string) ParseName()
    {
        var rawText = nameBox.text;
        var words = rawText.Split(' ');
        
        if (words.Length == 0)
        {
            return (Utils.GetRandomFirstName(), Utils.GetRandomLastName());
        }
        if (words.Length == 1)
        {
            return (words[0], Utils.GetRandomLastName());
        }
        
        var firstName = words[0].Trim();
        var secondName = words[1].Trim();
        return (firstName, secondName);
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

        nameBox.text = Utils.GetRandomFirstName() + " " + Utils.GetRandomLastName();
    }
}

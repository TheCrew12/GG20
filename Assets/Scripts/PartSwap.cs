using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PartSwap : MonoBehaviour
{
    public BodyPartType type;
    public BodyPartSide side = BodyPartSide.Center;
    private Image imagePic;

    private void Start() 
    {
        GetComponent<Button>().onClick.AddListener(RandomisePart);
        imagePic = GetComponent<Image>();
        RandomisePart(); //Randomise on startup
    }

    public void RandomisePart()
    {
        imagePic.sprite = PlazaLoader.GetRandomPartOfType( type );
    }

    public Sprite GetSelectedPart()
    {
        return imagePic.sprite;
    }
}

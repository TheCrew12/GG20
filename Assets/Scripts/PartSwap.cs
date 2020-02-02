using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PartSwap : MonoBehaviour
{
    public BodyPartType type;
    private Image imagePic;
    private int step = 0;

    private void Start() 
    {
        this.GetComponent<Button>().onClick.AddListener(ClickedEVENT);
        imagePic = GetComponent<Image>();
    }

    public void ClickedEVENT()
    {
        imagePic.sprite = PlazaLoader.GetRandomPartOfType( type );
    }

    public Sprite GetSelectedPart()
    {
        return imagePic.sprite;
    }
}

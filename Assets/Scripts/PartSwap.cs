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
    private Sprite selectedPart;

    private void Start() 
    {
        this.GetComponent<Button>().onClick.AddListener(ClickedEVENT);
        imagePic = GetComponent<Image>();
    }

    public void ClickedEVENT()
    {
        selectedPart = PlazaLoader.GetRandomPartOfType( type );
        imagePic.sprite = selectedPart;
    }

    public Sprite GetSelectedPart()
    {
        return selectedPart;
    }
}

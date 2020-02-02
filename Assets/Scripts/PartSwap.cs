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
        imagePic = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        imagePic.sprite = PlazaLoader.GetRandomPartOfType( type );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesprite : MonoBehaviour
{
  private float StartPosX;
  private float StartPosY;
  private bool isBeingHeld = false;

  private MonsterScript monsterScript;
  
private void Start() {
    monsterScript = GetComponent<MonsterScript>();
}

  void Update()
  {
    //   Vector3 mousePos1;
    //   mousePos1 = Input.mousePosition;
    //   mousePos1 = Camera.main.ScreenToWorldPoint(mousePos1);
    //   Debug.Log(mousePos1.x + " - " + mousePos1.y);

      if(isBeingHeld == true)
      {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - StartPosX, mousePos.y - StartPosY, 0);
      }
  }

void OnMouseDown()
  {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            StartPosX = mousePos.x - this.transform.localPosition.x;
            StartPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
            monsterScript.canMove = false;
        }
  }
  private void OnMouseUp()
  {
      isBeingHeld = false;
      if(!monsterScript.isInMotel)
      {
        monsterScript.canMove = true;
      }
  }
  
  }

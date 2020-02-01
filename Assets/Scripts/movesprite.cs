using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesprite : MonoBehaviour
{
  private float StartPosX;
  private float StartPosY;
  private bool isBeingHeld = false;
  
  void Update()
  {
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
        }
  }
  private void OnMouseUp()
  {
      isBeingHeld = false;
  }
  
  }

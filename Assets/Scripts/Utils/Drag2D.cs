using UnityEngine;

public class Drag2D : MonoBehaviour
{
  private float StartPosX;
  private float StartPosY;
  private bool isBeingHeld = false;

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
    }
  }
  
  private void OnMouseUp()
  {
    isBeingHeld = false;
  }

}

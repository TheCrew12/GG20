using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float MinX = -7;
    public float MaxX = 9;
    public float MovementStep = 0.2f;
    public float CameraSpeed = 1;
    public float EdgeScrollingZone = 30f;
    
    private float movement = 0; //x axis of camera

    // Start is called before the first frame update
    void Start()
    {
        movement = Camera.main.transform.position.x;
    }
    
    void Update()
    {
        //Key Input
        if (Input.GetKey(KeyCode.LeftArrow)) { movement -= MovementStep; }
        if (Input.GetKey(KeyCode.RightArrow)) { movement += MovementStep; }
        
        //Mouse Input
        var mouseX = Input.mousePosition.x;
        if (mouseX >= 0 && mouseX < EdgeScrollingZone)
        {
            movement -= MovementStep;
        }
        else if (mouseX <= Screen.width && mouseX > Screen.width - EdgeScrollingZone)
        {
            movement += MovementStep;
        }
        
        //Camera movement
        var cameraPos = Camera.main.transform.position;
        
        if (cameraPos.x == movement) { return; } //Nothing to do
        if (movement < MinX) { movement = MinX; return; } //Too far left
        if (movement > MaxX) { movement = MaxX; return; } //Too far right
        
        Camera.main.transform.position = 
            Vector3.MoveTowards(cameraPos, 
            new Vector3(movement , cameraPos.y, cameraPos.z), 
            Time.deltaTime * CameraSpeed);
    }
}

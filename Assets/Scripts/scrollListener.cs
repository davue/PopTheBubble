using UnityEngine;

public class scrollListener : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.freezeAll || ScrollingText.instance.isActive()) return;
        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if(ScrollWheelChange != 0) {
            Camera.main.orthographicSize += Camera.main.orthographicSize * ScrollWheelChange;
        }
            
    }
}

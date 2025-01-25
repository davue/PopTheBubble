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
        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            ScrollWheelChange = 0.5f;   
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            ScrollWheelChange = -0.5f;   
        }
        if(ScrollWheelChange != 0) {
            Camera.main.orthographicSize += Camera.main.orthographicSize * ScrollWheelChange;
        }
            
    }
}

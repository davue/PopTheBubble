using UnityEngine;
using UnityEngine.InputSystem;

public class cursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float initSize;
    Vector3 initScale;

    void Start()
    {
        initSize = Camera.main.orthographicSize;
        initScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());       
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        
        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            ScrollWheelChange = 0.5f;   
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            ScrollWheelChange = -0.5f;   
        }
        if(ScrollWheelChange != 0) {
            transform.localScale += transform.localScale * ScrollWheelChange;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        col.gameObject.GetComponent<Bubble>()?.Pop(Bubble.PopType.INTRO);
    }
}

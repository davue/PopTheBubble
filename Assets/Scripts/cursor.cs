using UnityEngine;
using UnityEngine.InputSystem;

public class cursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject cursorObject;
    public Vector3 initialPosition;
    float initSize;
    Vector3 initScale;

    void Start()
    {
        initSize = Camera.main.orthographicSize;
        initScale = transform.localScale;
        initialPosition = cursorObject.transform.localPosition;   
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());       
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.rotation = Quaternion.identity;
        cursorObject.transform.localPosition = initialPosition;
        
        if(Globals.freezeAll || ScrollingText.instance.isActive()) return;

        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if(ScrollWheelChange != 0) {
            transform.localScale += transform.localScale * ScrollWheelChange;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        col.gameObject.GetComponent<Bubble>()?.Pop(Bubble.PopType.INTRO);
    }

    public void ResetScale()
    {
        transform.localScale = initScale;
    }
}

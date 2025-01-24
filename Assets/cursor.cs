using UnityEngine;
using UnityEngine.InputSystem;

public class cursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());       
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}

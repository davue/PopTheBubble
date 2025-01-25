using System.Data;
using UnityEngine;

public class swapCursor : MonoBehaviour
{

    public int currentCursorIndex = 0;
    public GameObject[] cursors;

    GameObject currentCursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCursor = Instantiate(cursors[currentCursorIndex]);
        currentCursor.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }

    // Update is called once per frame
    void Update()
    {
       // NOP
        
    }

    public void swap(int i) {
            Destroy(currentCursor);
            currentCursorIndex = i;
            currentCursor = cursors[currentCursorIndex];
            currentCursor = Instantiate(currentCursor);
            currentCursor.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }
}

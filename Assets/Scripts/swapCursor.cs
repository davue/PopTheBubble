using System.Data;
using UnityEngine;

public class swapCursor : MonoBehaviour
{

    public int currentCursorIndex = 0;
    public GameObject[] cursors;

    public GameObject currentCursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCursor = Instantiate(cursors[currentCursorIndex]);
        currentCursor.GetComponent<cursor>().cursorObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
    }

    

    public void swap(int i) 
    {

            Destroy(currentCursor);
            currentCursorIndex = i;
            currentCursor = cursors[currentCursorIndex];
            currentCursor = Instantiate(currentCursor);
            currentCursor.GetComponent<cursor>().cursorObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
            SettingsMenu.instance.SetCursor(i); 
    }

    public void ResetCursor()
    {
        currentCursor.GetComponent<cursor>().ResetScale();
    }
}

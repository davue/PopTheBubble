using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private GameObject currentBackground;
    private int backgroundIndex;
    public GameObject[] backgrounds;

    public swapCursor sc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBackground = backgrounds[0];
        currentBackground.SetActive(true);
    }

   

    public void SetBackground(int i)
    {
        Camera.main.orthographicSize = 5;
        sc.ResetCursor();
        currentBackground.SetActive(false);
        currentBackground = backgrounds[i];
        currentBackground.SetActive(true);
    }
}

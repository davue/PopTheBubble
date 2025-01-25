using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private GameObject currentBackground;
    private int backgroundIndex;
    public GameObject[] backgrounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBackground = backgrounds[0];
        currentBackground.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("b"))
        {
            backgroundIndex++;
            if(backgroundIndex >= backgrounds.Length)
                backgroundIndex = 0;
            SetBackground(backgroundIndex);
            
        }
    }

    public void SetBackground(int i)
    {
        currentBackground.SetActive(false);
        currentBackground = backgrounds[i];
        currentBackground.SetActive(true);
        currentBackground.GetComponent<Background>().ScaleSpriteToScreen();
    }
}

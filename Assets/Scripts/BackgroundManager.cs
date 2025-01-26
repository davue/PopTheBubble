using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private GameObject currentBackground = null;
    private int backgroundIndex;
    public GameObject[] backgrounds;

    public swapCursor sc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateBackground(0);
    }

    public void SetBackground(int i)
    {
        Bubble.instance.EndDance();
        Camera.main.orthographicSize = 5;
        sc.ResetCursor();
        ActivateBackground(i);

    }

    private void ActivateBackground(int index)
    {
        if(currentBackground != null) currentBackground.SetActive(false);
        //currentBackground?.SetActive(false); 
        currentBackground = backgrounds[index];
        currentBackground.SetActive(true);

        Background background = currentBackground.GetComponent<Background>();
        Debug.Log(background.InitialMessage());
        if (!background.openedOnce && background.InitialMessage() != null)
        {
            SettingsMenu.instance.ToggleWindow();
            ScrollingText.instance.AddText(background.InitialMessage());
            ScrollingText.instance.ActivateNextText();
            background.openedOnce = true;
        }
    }
}

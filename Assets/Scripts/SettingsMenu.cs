using Unity.VisualScripting;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Transform child;

    public ScrollingText scrollingText;

    public bool active = false;

    void Start()
    {
        child = transform.GetChild(0);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleWindow();
        }
    }

    public void ToggleWindow()
    
    {
        if(scrollingText.isActive()) return;

        active = !active;
        child.gameObject.SetActive(active);
        if(active){ Globals.freezeAll = true;}
        else { Globals.freezeAll = false;}
    }
}

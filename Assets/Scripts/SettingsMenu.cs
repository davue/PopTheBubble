using Unity.VisualScripting;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Transform child;

    public bool active = false;

    void Start()
    {
        child = transform.GetChild(0);
        Globals.isPaused = false;
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
        active = !active;
        child.gameObject.SetActive(active);
        if(active) Globals.isPaused = true;
        else Globals.isPaused = false;
    }
}

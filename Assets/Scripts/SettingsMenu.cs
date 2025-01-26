using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu instance;

    public Transform child;

    public TMP_Dropdown cursorDropdown;

    public ScrollingText scrollingText;

    public bool active = false;

    void Start()
    {
        child = transform.GetChild(0);
        instance = this;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleWindow();
        }
    }

    public void CloseWindow()
    {
        Globals.freezeAll = false; UnityEngine.Cursor.visible = false;
        if(active)
        {
            child.gameObject.SetActive(false);
            active = false;
        }
        
    }

    public void OpenWindow()
    {
        if(scrollingText.isActive()) return;

        active = true;
        child.gameObject.SetActive(true);
        Globals.freezeAll = true; UnityEngine.Cursor.visible = true;
    }

    public void ToggleWindow()
    
    {
        if(active)
        {
            CloseWindow();
        }
        else
        {
            OpenWindow();
        }

    }

    public void removeCursorOption()
    {
        cursorDropdown.interactable = false;
    }

    public void SetCursor(int i)
    {
        cursorDropdown.value = i;
    }
}

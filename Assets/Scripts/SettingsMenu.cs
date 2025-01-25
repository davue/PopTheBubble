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

    public void ToggleWindow()
    
    {
        if(scrollingText.isActive()) return;

        active = !active;
        child.gameObject.SetActive(active);
        
        if(active){ Globals.freezeAll = true; UnityEngine.Cursor.visible = true;}
        else { Globals.freezeAll = false; UnityEngine.Cursor.visible = false;}

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

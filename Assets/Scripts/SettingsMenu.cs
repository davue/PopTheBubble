using Unity.VisualScripting;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Transform child;

    public bool active = true;

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
        active = !active;
        child.gameObject.SetActive(active);
    }
}

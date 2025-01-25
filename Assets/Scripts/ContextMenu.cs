using UnityEngine;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    [SerializeField] private Bubble _bubble;
    [SerializeField] private GameObject _cutExtension;
    [SerializeField] private GameObject _recycleBin;
    public Button _cutButton;
    public Button _deleteButton;
    public Button _copyButton;
    public bool onBubble = false;
    public bool onRecycleBin = false;

    private Vector3 openPosition;

    void Start()
    {
        _cutExtension.SetActive(false);
    }

    public void OnOpen()
    {
        var screenMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        screenMouse.z = 0;

        if (screenMouse.magnitude < 2.1f)
        {
            onBubble = true;
            _deleteButton.interactable = true;
            _copyButton.interactable = true;
            _cutButton.interactable = true;
        }
        else if (screenMouse.x >= -7.5f && screenMouse.x <= -6.3f && screenMouse.y >= 3.5 && screenMouse.y <= 4.7)
        {
            _deleteButton.interactable = true;
            onRecycleBin = true;
        }
        else
        {
            _cutButton.interactable = false;
            _deleteButton.interactable = false;
            _copyButton.interactable = false;
            onBubble = false;
            onRecycleBin = false;
        }
    }
    
    public void Cut()
    {
        if (onBubble)
        {
            _bubble.Pop(Bubble.PopType.XP_CUT);
            _cutExtension.SetActive(true);
        }
    }

    public void Copy()
    {
        if (onBubble)
        {
            _bubble.Interact(Bubble.InteractionType.XP_COPY);
        }
    }

    public void Delete()
    {
        if (onBubble)
        {
            _bubble.Pop(Bubble.PopType.XP_DELETE);
        } else if (onRecycleBin)
        {
            _recycleBin.SetActive(false);
        }
    }
}

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
    public bool recycleBinActive = true;

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
            onRecycleBin = false;
            _copyButton.interactable = true;
            _cutButton.interactable = true;

            if (_bubble.xpFinalDelete)
            {
                _deleteButton.interactable = false;
            }
            else
            {
                _deleteButton.interactable = true;
            }
        }
        else if (screenMouse.x >= -5.3f && screenMouse.x <= -4f && screenMouse.y >= 0f && screenMouse.y <= 1.2f) 
        {
            _cutButton.interactable = false;
            _copyButton.interactable = false;
            _deleteButton.interactable = true;
            onRecycleBin = true;
            onBubble = false;
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
            if (recycleBinActive)
            {
                _bubble.Pop(Bubble.PopType.XP_DELETE);
            }
            else
            {
                _bubble.Pop(Bubble.PopType.XP_DELETE_RECYCLE);
            }
        } else if (onRecycleBin)
        {
            _recycleBin.SetActive(false);
            recycleBinActive = false;
        }
    }

    void Update()
    {
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}

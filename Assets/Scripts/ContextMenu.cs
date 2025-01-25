using UnityEngine;

public class ContextMenu : MonoBehaviour
{
    [SerializeField] private Bubble _bubble;
    
    public void Cut()
    {
        Debug.Log("CUT!!");
        _bubble.Pop(Bubble.PopType.XP);
    }

    public void Copy()
    {
        
    }

    public void Delete()
    {
        
    }
}

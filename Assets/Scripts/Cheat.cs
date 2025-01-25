using UnityEngine;

public class Cheat : MonoBehaviour
{
    public Bubble bubble;
    public int popStartLevel;
    public bool cheatMode = false;

    bool hasCheated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    void Start()
    {
        Globals.cheatMode = cheatMode;
        
    }

    void Update()
    {

        if(!hasCheated && Input.GetKeyDown(KeyCode.C))
        {
            hasCheated = true;
            for(int i = 0; i < popStartLevel; i++)
            {
                bubble.Pop();
                bubble.UnPop();
            }
            Globals.cheatMode = false;
        }
    }

}

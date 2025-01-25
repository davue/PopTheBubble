using UnityEngine;

public class Bubble : MonoBehaviour
{
    public ParticleSystem ps;
    private bool _isPopped;

    public bool debug = true;
    private SpriteRenderer renderer;
    public ScrollingText st;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<SpriteRenderer>();

    }

    public void Pop()
    {
        if(Globals.freezeAll) return;

        if(st.isActive()) return;
        

        if (!_isPopped)
        {
            _isPopped = true;
        
            // Play pop animation particle effect
            ps.Play();
            Globals.popCount++;

            st.ClearQueue();

            switch(Globals.popCount)
            {
                case 1:
                    st.AddText("OMG, you killed me! No worries, that happens, but please be more careful, ok?");
                    break;
                case 2:
                    st.AddText("Oh no, it happened again! Please, be more careful! :(");
                    break;
                case 3:
                    st.AddText("Hey, you killed me again! Please, stop! It really hurts me and I have only so many lifes!");
                    break;
                case 4:
                    st.AddText("Ouch! That hurts so much! Are you doing this on purpose? I thought we are friends! :'(");
                    break;
                case 5:
                    st.AddText("You Idiot, you killed me again! I'm so done with you! I tried to be nice to you but you are just a monster!");
                    break;
                default:
                    st.AddText("You allready killed me " + Globals.popCount + " times! Stop it! >:( ");
                    break;
            }
            st.ActivateNextText();
            
            // Hide bubble
            renderer.enabled = false;
        }

    }

    public void UnPop()
    {
        Debug.Log("Unpop");

        if (_isPopped)
        {
            // Show bubble
            renderer.enabled = true;
        
            _isPopped = false;

            switch(Globals.popCount)
            {
                case 1:
                    st.AddText("I can respawn though, so don't worry! Let's continue playing! :)");
                    break;
                case 2:
                    st.AddText("I have many lives, but no need to waste them. Please, be more careful!");
                    break;
                case 3:
                    st.AddText("Ugh, this is getting on my nerves....");
                    break;
                case 4:
                    st.AddText("Please show some respect! I'm not a toy! >:(");
                    break;
                case 5:
                    st.AddText("You bastard, I warn you! Don't anger me too much or you will regret it!!!");
                    break;
                default:
                    break;
            }
            st.ActivateNextText();
        }
    }
    
    // Update is called once per frame
    void Update()
    {   
        if(!debug) return;
        if(Input.GetKeyDown("p") && !_isPopped)
        {
             Pop();
        }
        
        if(Input.GetKeyDown("r") && _isPopped)
        {
            UnPop();
        }

        if(!st.isActive() && _isPopped)
        {
            UnPop();
        }
        
    }
}

using UnityEngine;

public class Bubble : MonoBehaviour
{
    public ParticleSystem ps;
    private bool _isPopped;

    public int introProgress = 0;
    
    // XP state
    public bool xpCut = false;
    public bool xpDelete = false;
    
    public int zoomProgress = 0;

    public enum PopType{
        INTRO,
        XP,
        DANCE,
        ZOOM,
        XP_CUT,
        XP_DELETE
    }

    public enum InteractionType
    {
        XP_COPY,
        XP_CUTE
    }

    PopType currentPopType;

    public bool debug = true;
    private SpriteRenderer renderer;
    public ScrollingText st;

    public swapCursor cursorSwap;

    public SettingsMenu settingsMenu; 

    public MiniButtons miniButtons;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<SpriteRenderer>();

    }

    public void Interact(InteractionType type)
    {
        if (type == InteractionType.XP_COPY)
        {
            ps.Play();
            st.AddText("Whoooohoo!! More bubbles!!");
            st.ActivateNextText();
        } else if (type == InteractionType.XP_CUTE)
        {
            st.AddText("Awww thanks, you're cute tooo :)");
            st.ActivateNextText();
        }
    }
    
    public void Pop(PopType type)
    {
        if(type == PopType.XP_CUT && xpCut) Interact(InteractionType.XP_CUTE);
        if(type == PopType.XP_DELETE && xpDelete) return;
        
        if(Globals.freezeAll) return;

        if(st.isActive()) return;
        

        if (!_isPopped)
        {
            _isPopped = true;
            currentPopType = type;
        
            // Play pop animation particle effect
            ps.Play();
            Globals.popCount++;

            st.ClearQueue();

            if(type == PopType.INTRO) 
            {
                introProgress++;
                switch(introProgress)
                {
                    case 1:
                        st.AddText("OMG, you killed me! No worries, that happens, but please be more careful, ok?");
                        break;
                    case 2:
                        st.AddText("Oh no, it happened again! Please, be more careful! :(");
                        st.AddText("I have many lives, but no need to waste them. Please, be more careful!");
                        break;
                    case 3:
                        st.AddText("Why did you do that? I went out of my way to switch the cursor for you! Are you doing this on purpose?");
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
            }
            
            if(type == PopType.ZOOM)
            {
                zoomProgress++;
                switch(zoomProgress)
                {
                    case 1:
                        st.AddText("Hey, what did you do? Can you not read or what? It told you not to press any buttons! You are such an Idiot!!!");
                        break;

                    case 2:
                        st.AddText("You are such a sadistic bastard! You know what you remind me of? Fucking marbles! I hate those Fuckers!!!");
                        break;
                    default:
                        st.AddText("You allready killed me " + Globals.popCount + " times! Stop it! >:( ");
                        break;
                }
                st.ActivateNextText();
            }
            
            if (type == PopType.XP_CUT)
            {
                st.AddText("Hey! You cut me!");
                st.ActivateNextText();
                xpCut = true;
            }
            
            if (type == PopType.XP_DELETE)
            {
                xpDelete = true;
                st.AddText("Oh no! I'm gone!");
                st.ActivateNextText();
            }
            
            // Hide bubble
            renderer.enabled = false;
        }

    }

    public void UnPop(PopType type)
    {
        Debug.Log("Unpop");

        if (_isPopped)
        {
            // Show bubble
            renderer.enabled = true;
        
            _isPopped = false;
            if(type == PopType.INTRO) 
            {
                switch(introProgress)
                {
                    case 1:
                        st.AddText("I can respawn though, so don't worry! Let's continue playing! :)");
                        break;
                    case 2:
                        st.AddText("Here, I switch the cursor for you, the one you use is quite pointy!");
                        cursorSwap.swap(1);
                        st.AddText("I hope you like it!");
                        Globals.cursorSwapPhase = true;
                        break;
                    case 3:
                        Globals.cursorSwapPhase = false;
                        st.AddText("Ugh, this is getting on my nerves....");
                        st.AddText("You are really a stupid one, aren't you? I'll make sure you can't hurt me anymore.");
                        cursorSwap.swap(1);
                        settingsMenu.removeCursorOption();
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

            if(type == PopType.ZOOM) 
            {
                switch(zoomProgress)
                {
                    case 1:
                        st.AddText("I lock these buttons away so you can't mess with them anymore!");
                        miniButtons.SpawnSecurity();
                        break;

                    case 2: 
                        st.textBox.fontSize = 13;
                        st.AddText("Those fucking marbles are even worse than you, you Monster!"
                        + "Those smug, solid little bastards rolling around like they own the damn world. Look at me—I’m a bubble, light, graceful, elegant."
                        + "I float with finesse. I reflect rainbows like it’s my goddamn job. But marbles? Oh no, they just plop their dense, self-important asses down and sit there, pretending to be all valuable and collectible. Newsflash, you shiny rocks: no one actually likes you."
                        + "What do marbles even do? They just roll. That’s it. Big whoop. Roll around, hit each other, and make those stupid little clinking noises like they’re so damn special. Meanwhile, I’m out here dancing on the wind, bringing actual joy to people—until..."
                        + "some dumb kid with sticky fingers pops me. And you know what? I get it. I’m fragile. Fleeting. But at least I go out in style. What happens when you break a marble? Nothing. Just a bunch of sad little glass shards sitting in a gutter somewhere. Pathetic."
                        + "And don’t even get me started on how they hog all the attention. “Oh wow, look at that cool swirl inside!” Are you fucking kidding me? I am a swirl. I embody swirls. I reflect the entire fucking spectrum of light in a way marbles could only dream of. But no, people want to collect those chunky hunks of glass instead. Marbles are basically just the try-hard cousins of actual gemstones, but without any of the class. They sit around in dusty jars or roll under couches, forgotten and useless. Meanwhile, bubbles like me? We’re fleeting magic. We make moments special. But do we get respect? Nope. Instead, we get laughed at, blown around, and popped like we’re disposable."
                        + "So yeah, fuck marbles. Overrated, overhyped, and over here taking up space in a world that deserves more bubbles.");
                        miniButtons.SpawnSecurity();
                        miniButtons.deactivateInputField();
                        break;
                    
                    default:
                        break;
                }
                st.ActivateNextText();
            }
            

            if (type == PopType.XP_CUT)
            {
                st.AddText("Please don't do that.");
                st.ActivateNextText();
            }
            
            if (type == PopType.XP_DELETE)
            {
                st.AddText("Ha! I just climbed out of the Recycling Bin!");
                st.ActivateNextText();
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {   
        if(!debug) return;
        if(Input.GetKeyDown("p") && !_isPopped)
        {
             Pop(PopType.INTRO);
        }
        
        if(Input.GetKeyDown("r") && _isPopped)
        {
            UnPop(PopType.INTRO);
        }

        if(!st.isActive() && _isPopped)
        {
            UnPop(currentPopType);
        }
        
    }
}

using UnityEngine;

public class Bubble : MonoBehaviour
{
    public ParticleSystem ps;
    private bool _isPopped;

    public int introProgress = 0;
    
    // XP state
    public bool xpCut = false;
    public bool xpFinalDelete = false;
    public int xpDelete = 0;
    
    public int zoomProgress = 0;

    public enum PopType{
        INTRO,
        XP,
        DANCE,
        ZOOM,
        XP_CUT,
        XP_DELETE,
        XP_DELETE_RECYCLE,
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
        EndDance();

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
        if((type == PopType.XP_DELETE || type == PopType.XP_DELETE_RECYCLE) && xpFinalDelete) return;
        
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
                        st.AddText("OMG, you killed me! But don't worry, that happens. This cursor can be lethal, if you touch me with it. Handle it with care please.");
                        break;
                    case 2:
                        st.AddText("Oh no, it happened again! :(");
                        st.AddText("I have many lives, but no need to waste them.");
                        st.AddText("Here, I'm going to switch the cursor for you, the one you are using is quite pointy.");
                        break;
                    case 3:
                        st.AddText("Why did you do that? I went out of my way to switch the cursor for you! Why would you switch it back? Are you stupid?");
                        st.AddText("Ugh, this is getting on my nerves....");
                        st.AddText("You must be a really stupid one. I guess I have to take the pointy cursor away from you to make sure that you can't hurt me anymore.");
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
                        st.AddText("Hey, what did you do?");
                        st.AddText("Listen. If management tells you not to press any buttons, you better not press any buttons. You do not want to mess with management.");
                        break;

                    case 2:
                        st.AddText("Ouch! Stop!");
                        st.AddText("Again?");
                        st.AddText("You are such a sadistic bastard! You know what you remind me of? Fucking marbles! I hate those Fuckers!!!");
                        break;
                    case 3:
                        st.AddText("...");
                        st.AddText("Did those button really promise you something so lucrative, that you would ignore everything you are told and go out of your way to get an admin password to press it?");
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
                xpDelete++;
                switch (xpDelete)
                {
                    case 1:
                        st.AddText("Oh no! I'm gone!");
                        break;
                    case 2:
                        st.AddText("You know this doesn't work.");
                        break;
                    default:
                        st.AddText("Go on. Try again.");
                        break;
                }
                
                st.ActivateNextText();
            }
            
            if (type == PopType.XP_DELETE_RECYCLE)
            {
                xpFinalDelete = true;
                st.AddText("I guess that one's on me. I should not have told you about the recycling bin.");
                st.AddText("If you delete the recycling bin, where does it go? Is there a second recycling bin containing the first one? And what happens if you delete that one as well?");
                st.AddText("And I guess no matter how deep this recursion grows, you'll keep destroing every last one of those recycling bins...");
                st.ActivateNextText();
            }

            if(type == PopType.DANCE)
            {
                st.AddText("Oh no, I can't handle your dance moves! Your sick rythm is killing me!!!");

                st.ActivateNextText();
            }
            
            // Hide bubble
            renderer.enabled = false;
        }

    }

    public void UnPop(PopType type)
    {
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
                        st.AddText("There you go. I hope you like it!");
                        cursorSwap.swap(1);
                        st.AddText("With this one, you don't have to worry to pop me by accident anymore.");
                        break;
                    case 3:
                        cursorSwap.swap(1);
                        st.AddText("Why do they always give me the idiots for play testing?");
                        settingsMenu.removeCursorOption();
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
                        st.AddText("Please. Most of those buttons seem suspicious anyways. No need to try your luck.");
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
                        st.AddText("...");
                        st.AddText("Anyways...");
                        st.AddText("Now you've done it. Management locked my buttons away, such that only admins can access them.");
                        miniButtons.SpawnSecurity();
                        break;
                    case 3:
                        st.AddText("I guess you have to be helped to help yourself. No more admin access for you!");
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
                st.AddText("Please don't do that. And to make sure it doesn't happen again, I made the cut a little nicer.");
                st.ActivateNextText();
            }
            
            if (type == PopType.XP_DELETE)
            {
                switch (xpDelete)
                {
                    case 1:
                        st.AddText("Ha! You can't get rid of me that easily! I just climbed out of the recycle bin again!");
                        break;
                    case 2:
                        st.AddText("Things are never permanently deleted in Windows... As long as there's a recycling bin, there's always a way back out of it. It's called 'Recycling' for a reason.");
                        break;
                    default:
                        st.AddText("This is getting boring.");
                        break;
                }
                st.ActivateNextText();
            }

            if (type == PopType.DANCE)
            {
                st.AddText("Anyways, I'll continue dancing!");
                st.ActivateNextText();
                this.StartDance();
                
            }

            if (type == PopType.XP_DELETE_RECYCLE)
            {
                st.AddText("Because you're behaving like a child, I deleted the delete menu for you. You're welcome.");
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

    public void EndDance()
    {
        
        GetComponent<Animator>().enabled = false;
        transform.position = Vector3.zero;
        
    }

    public void StartDance()
    {
        GetComponent<Animator>().enabled = true;
        
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disco : MonoBehaviour
{

    // provides the countdown, missed inputs add time punishments
    public CountDownTimer timer;

    // input sensitive zone
    public GameObject discoButtonNowField;

    // slider. if it crosses the discoButtonNowField, it listens to input
    public DiscoButton discoButton;

    Vector3 discoButtonStartPos;

    // used to detect screen wraps
    float prevDiscoPos;

    // notify this object of missed/hit inputs
    public GameObject bubble;
    Bubble b;

    // music
    public AudioSource musicSource;

    public int scoreTarget;

    public Transform buttonsBar;

    public const float initalPitch = 0.7f;
    public float pitchStepSize = 0.1f;
    public bool pitchSizeAdditive = true;

    public bool minigameFinished = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BoomBox boomBox;

    void OnEnable()
    {
        
        if(Bubble.instance.danceProgress < 2)
            bubble.GetComponent<Bubble>().StartDance();
        else bubble.GetComponent<Bubble>().EndDance();
    }

    void Start()
    {
        Cursor.visible = false;
        discoButtonStartPos = discoButton.transform.position;
        prevDiscoPos= discoButtonStartPos.x;
        musicSource.Play();
        b = bubble.GetComponent<Bubble>();
        DeactivateBoomBox();
    }

    // Update is called once per frame
    void Update()
    {
        if(minigameFinished) return;
        if(ScrollingText.instance.isActive()) return;
        if(Globals.freezeAll) return;

        if(timer.totalTime <= 0) { // time's up

            b.EndDance();

            if(timer.score >= scoreTarget)
            {
                b.Pop(Bubble.PopType.DANCE);
                teardownDisco(); 
            }
            else
            {
                ScrollingText.instance.AddText("Hahaha, you are a good dancer! But don't go too hard ok? I am pretty fragile and the sick beats hit me hard <3");
                ScrollingText.instance.AddText("Let's Dance again :)");
                ScrollingText.instance.ActivateNextText();
                ResetDisco();
            }
        }
        else {
            float discoPos = discoButton.transform.position.x;
            if(discoPos > prevDiscoPos) { //wrapped
                missedInput();
            }
            else {
                float zoneMin = discoButtonNowField.GetComponent<SpriteRenderer>().bounds.min.x;
                float zoneMax = discoButtonNowField.GetComponent<SpriteRenderer>().bounds.max.x;
                bool inZone = zoneMin <= discoPos && discoPos <= zoneMax;
                if(Input.anyKeyDown) {
                    if(Input.GetKeyDown(KeyCode.DownArrow)) {
                        if(inZone && discoButton.hittingKeyCode == KeyCode.DownArrow) hitInput();
                        else missedInput();
                    }
                    else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
                        if(inZone && discoButton.hittingKeyCode == KeyCode.LeftArrow) hitInput();
                        else missedInput();
                    }
                    else if(Input.GetKeyDown(KeyCode.RightArrow)) {
                        if(inZone && discoButton.hittingKeyCode == KeyCode.RightArrow) hitInput();
                        else missedInput();
                    }
                    else if(Input.GetKeyDown(KeyCode.UpArrow)) {
                        if(inZone && discoButton.hittingKeyCode == KeyCode.UpArrow) hitInput();
                        else missedInput();
                    }
                }else {
                    prevDiscoPos = discoButton.transform.position.x;
                }
            }
        }
        
    }

    void teardownDisco() 
    {
        musicSource.pitch = 1f;
        //if(musicSource.isPlaying) musicSource.Stop();

        discoButton.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
        buttonsBar.gameObject.SetActive(false);
        minigameFinished = true;
    }

    public void ResetDisco()
    {
        discoButton.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);
        buttonsBar.gameObject.SetActive(true);
        resetDiscoButton();
        timer.Reset();
        musicSource.pitch = initalPitch;
        discoButton.stepSize = discoButton.initStepSize;
        b.StartDance();
    }
    

    void hitInput() {
        Debug.Log("Hit Input");
        timer.addBonus();
        resetDiscoButton();
        if(pitchSizeAdditive)
            musicSource.pitch += pitchStepSize;
        else musicSource.pitch *= pitchStepSize + 1f;
        discoButton.stepSize *= 1.1f;
    }

    void missedInput() {
        Debug.Log("Missed Input");
        timer.addMalus();
        resetDiscoButton();
        discoButton.stepSize = discoButton.initStepSize;
        musicSource.pitch = initalPitch;
    }

    void resetDiscoButton() {
        prevDiscoPos = discoButtonStartPos.x;
        discoButton.transform.position = discoButtonStartPos;  
        discoButton.initArrow();
    }

    public void ActivateBoomBox()
    {
        boomBox.gameObject.SetActive(true);
    }
    public void DeactivateBoomBox()
    {
        boomBox.gameObject.SetActive(false);
    }
}

using System;
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

    // music
    public AudioSource musicSource;

    public const float initalPitch = 0.7f;
    public float pitchStepSize = 0.1f;
    public bool pitchSizeAdditive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        discoButtonStartPos = discoButton.transform.position;
        prevDiscoPos= discoButtonStartPos.x;
        musicSource.Play();
        bubble.GetComponent<Bubble>().StartDance();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScrollingText.instance.isActive()) return;
        if(Globals.freezeAll) return;

        if(timer.totalTime <= 0) { // time's up
            teardownDisco();
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

    void teardownDisco() {
        if(musicSource.isPlaying) musicSource.Stop();
        bubble.GetComponent<Bubble>().Pop(Bubble.PopType.DANCE);
        bubble.GetComponent<Bubble>().EndDance();

        discoButton.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
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
}

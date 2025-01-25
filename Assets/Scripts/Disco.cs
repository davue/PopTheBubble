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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        discoButtonStartPos = discoButton.transform.position;
        prevDiscoPos= discoButtonStartPos.x;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
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
                    }else {
                        missedInput();
                    }
                }else {
                    prevDiscoPos = discoButton.transform.position.x;
                }
            }
        }
        
    }

    void teardownDisco() {
        Cursor.visible = true;
        if(musicSource.isPlaying) musicSource.Stop();
        //TODO: stop bubble animation
    }

    void hitInput() {
        Debug.Log("Hit Input");
        resetDiscoButton();
    }

    void missedInput() {
        Debug.Log("Missed Input");
        timer.addMalus();
        resetDiscoButton();
    }

    void resetDiscoButton() {
        prevDiscoPos = discoButtonStartPos.x;
        discoButton.transform.position = discoButtonStartPos;
    }
}

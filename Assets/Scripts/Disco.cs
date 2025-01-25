using System;
using UnityEngine;

public class Disco : MonoBehaviour
{

    // provides the countdown, missed inputs add time punishments
    public CountDownTimer timer;

    // input sensitive zone
    public GameObject discoButtonNowField;

    // slider. if it crosses the discoButtonNowField, it listens to input
    public DiscoButton discoButton;

    Vector3 discoButtonStartPos;

    float prevDiscoPos;

    // notify this object of missed/hit inputs
    public GameObject bubble;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        discoButtonStartPos = discoButton.transform.position;
        prevDiscoPos= discoButtonStartPos.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.totalTime <= 0) { // time's up
            countdownSuccess();
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
                }
            }
            prevDiscoPos = discoButton.transform.position.x;
        }
        
    }

    void countdownSuccess() {
        //TODO:
    }

    void hitInput() {
        prevDiscoPos = discoButtonStartPos.x;
        discoButton.transform.position = discoButtonStartPos;
    }

    void missedInput() {
        timer.addMalus();
    }
}

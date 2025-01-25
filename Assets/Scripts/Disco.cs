using System;
using UnityEngine;

public class Disco : MonoBehaviour
{

    // provides the countdown, missed inputs add time punishments
    public GameObject timer;

    // input sensitive zone
    public GameObject discoButtonNowField;

    // slider. if it crosses the discoButtonNowField, it listens to input
    public DiscoButton discoButton;

    // notify this object of missed/hit inputs
    public GameObject bubble;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float discoMin = discoButton.transform.position.x;
        float zoneMin = discoButtonNowField.GetComponent<SpriteRenderer>().bounds.min.x;
        float zoneMax = discoButtonNowField.GetComponent<SpriteRenderer>().bounds.max.x;
        bool inZone = zoneMin <= discoMin && discoMin <= zoneMax;
        if(Input.anyKeyDown) {
            if(inZone) {
                Debug.Log("In zone.");
                Debug.Log("Disco Key:" + discoButton.hittingKeyCode);
            }
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

    void hitInput() {
        Debug.Log("Hit");
    }

    void missedInput() {
        Debug.Log("Miss");
    }
}

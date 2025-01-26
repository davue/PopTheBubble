using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    float initialTotalTime;
    public float totalTime = 60; //Set the total time for the countdown
    float elapsedTime = 0;

    public int score = 0;
    public TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      initialTotalTime = totalTime;
    }

  void Update()
  {
    if(ScrollingText.instance.isActive()) return;
    if(Globals.freezeAll) return;

    totalTime -= Time.deltaTime;
    if (totalTime > 0)
    {
      // Subtract elapsed time every frame

      // Divide the time by 60
      float minutes = Mathf.FloorToInt(totalTime / 60); 
      
      // Returns the remainder
      float seconds = Mathf.FloorToInt(totalTime % 60);

      // Set the text string
      timerText.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds) + "\nScore: " + score;
    }
    else
    {
        timerText.text = "Time left: 0" + "\nScore: " + score;
    }

  }

    public void addMalus() {
        score -= 10;
    }

    public void addBonus()
    {
      score += 10;
    }

    public void Reset()
    {
      totalTime = initialTotalTime;
      score = 0;
    }

}

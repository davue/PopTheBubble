using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniButtons : MonoBehaviour
{
    public Bubble bubble;

    public Transform securitySpawner;

    public TMP_InputField inputField;

    public Button inputFieldSubmission;

    public swapCursor sc;

    public string password = "FuckMarbles";

    public void SpawnSecurity()
    {
        securitySpawner.gameObject.SetActive(true);
    }

    public void SubmitPassword()
    {
        if(inputField.text == password)
        {

            securitySpawner.gameObject.SetActive(false);
            ScrollingText.instance.AddText("Wait?! How did you figure out the admin password? You're not supposed to know that! Management really needs to get their s**t together."
            + " But at least you also agree that Marbles are the worst!");
            ScrollingText.instance.AddText("Just don't touch the buttons, I beg you!!! Please let me live!");
            ScrollingText.instance.ActivateNextText();
        }
        else
        {
            ScrollingText.instance.AddText("Ha, nice try. That's not the password you fool!!! You are very far off!");
            ScrollingText.instance.ActivateNextText();
        }


    }

    public void MakeBubblePop()
    {
        if(Globals.freezeAll) return;
        Camera.main.orthographicSize = 5;
        sc.ResetCursor();
        bubble.Pop(Bubble.PopType.ZOOM);
    }

    public void deactivateInputField()
    {
        inputField.gameObject.SetActive(false);
        inputFieldSubmission.gameObject.SetActive(false);
    }
}

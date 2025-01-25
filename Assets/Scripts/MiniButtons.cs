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
            ScrollingText.instance.AddText("Nooo, you got it right! You're not supposed to know that password!"
            + " But at least you also agree that Marbles are the worst!");
            ScrollingText.instance.AddText("But don't touch the buttons, I beg you!!! Please let me live!");
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

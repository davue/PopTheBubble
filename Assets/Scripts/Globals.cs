using Unity.VisualScripting;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static bool freezeAll = false;

    public static bool cheatMode = false;

    public static int popCount = 0;

    public static int volumePercentage;

    public ScrollingText scrollingText;

    string introText = "Welcome to the game! My name is Bubbly McBubbleface. Play with me! uwu! But be careful, I'm very fragile!";
    string introText2 = "I am so happy to be here! I hope you are too! Let's have some fun together!";


    public void Start()
    {
        scrollingText.AddText(introText);
        scrollingText.AddText(introText2);
        scrollingText.ActivateNextText();
    }
}

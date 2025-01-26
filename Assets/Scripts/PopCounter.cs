using TMPro;
using UnityEngine;

public class PopCounter : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void Update()
    {
        text.text = "Bubble Pops: " + Globals.popCount + "/10";
    }
}

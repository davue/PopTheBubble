using System;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MySlider : MonoBehaviour
{

    public TMP_InputField inputField;
    public Slider slider;

    float defaultLength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Start()
    {
        defaultLength = ((RectTransform)(transform)).sizeDelta.x;
    }

    public void SliderValueChanged(int value)
    {
        value = (int)slider.value;
        inputField.text = value.ToString(); 
        Globals.volumePercentage = value;
    }

    public void TextInputChanged(string text)
    {
        text = inputField.text;
        if(text.All(Char.IsDigit))
        {
            int value = int.Parse(text);

            if(value <= 100)
            {
                slider.maxValue = 100;
                ((RectTransform)(transform)).sizeDelta = new Vector2(defaultLength, ((RectTransform)(transform)).sizeDelta.y);
                slider.value = value;
                Globals.volumePercentage = value;
                return;
            }

            float newLength = (value / 100f) * defaultLength;
            ((RectTransform)(transform)).sizeDelta = new Vector2(newLength, ((RectTransform)(transform)).sizeDelta.y);
            slider.maxValue = value;
            slider.value = value;
            Globals.volumePercentage = value;

        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    private readonly List<char> _punctuations = new() { '.', '!', '?' };
    private CanvasRenderer _renderer;

    [Header("Text Settings")]
    [SerializeField] [TextArea] private string text;
    [SerializeField] private float scrollSpeed = 0.01f;
    [SerializeField] private float punctuationPause = 0.02f;

    [Header("UI Elements")] [SerializeField]
    private TextMeshProUGUI textBox;
    [SerializeField] private float waitAfterText = 2.0f;

    [Header("Sound Settings")]
    [SerializeField] private GameObject audioSourcePrefab;

    private void Start()
    {
        _renderer = GetComponent<CanvasRenderer>();
    }

    public void SetText(string text)
    {
        this.text = text;
    }

    public void ActivateText()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        for (int i = 0; i < text.Length + 1; i++)
        {
            // Update text
            textBox.text = text.Substring(0, i);
            
            // Play bubble sound
            if (i % 3 == 0)
            {
                var bubbleSound = Instantiate(audioSourcePrefab).GetComponent<AudioSource>();
                bubbleSound.pitch = Random.Range(0.6f, 1.2f);
                bubbleSound.Play();
            }
            
            float waitTime = scrollSpeed;
            if (i > 0 && _punctuations.Contains(text[i - 1]))
            {
                waitTime += punctuationPause;
            }

            yield return new WaitForSeconds(waitTime);
        }
        
        // Hide text panel
        yield return new WaitForSeconds(waitAfterText);
        gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ActivateText();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    private readonly List<char> _punctuations = new() { '.', '!', '?' };
    private CanvasRenderer _renderer;
    private Transform _child;
    private bool _inCorutine = false;

    [Header("Text Settings")]
    [SerializeField] [TextArea] private string text;
    [SerializeField] private float scrollSpeed = 0.01f;
    [SerializeField] private float punctuationPause = 0.02f;

    [Header("UI Elements")] [SerializeField]
    private TextMeshProUGUI textBox;
    [SerializeField] private bool autoClose = false;
    [SerializeField] private float waitAfterText = 2.0f;

    [Header("Sound Settings")]
    [SerializeField] private GameObject audioSourcePrefab;

    public Queue<string> textQueue = new Queue<string>();

    private void Awake()
    {
        _child = transform.GetChild(0);
        _renderer = _child.GetComponent<CanvasRenderer>();
    }

    public void Start()
    {
        if(Globals.cheatMode) _child.gameObject.SetActive(false);
        
    }

    public bool isActive()
    {
        return _child.gameObject.activeSelf;
    }
    
    public void ClearQueue()
    {
        textQueue.Clear();
    }
    public void AddText(string text)
    {
        if(Globals.cheatMode) return;
        textQueue.Enqueue(text);
    }

    public void ActivateNextText()
    {
        if(Globals.cheatMode) return;

        if(textQueue.Count > 0)
        {
            _child.gameObject.SetActive(true);
            text = textQueue.Dequeue();
            StartCoroutine(AnimateText());
        }
        else
        {
            _child.gameObject.SetActive(false);
        }
    }

    IEnumerator AnimateText()
    {
        _inCorutine = true;
        
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
        
        // Hide text panel if auto-close
        if (autoClose)
        {
            yield return new WaitForSeconds(waitAfterText);
            gameObject.SetActive(false);
        }

        _inCorutine = false;
        

    }
    
    void Update()
    {
        if(Globals.freezeAll) return;

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if (!_inCorutine)
            {
                ActivateNextText();
            }
            
        }
    }
}
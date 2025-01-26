
using System.Security.Cryptography;
using UnityEngine;

public class DiscoButton : MonoBehaviour
{

    public GameObject[] arrowAssets;
    public GameObject arrow;
    public KeyCode hittingKeyCode;

    float minX;
    float maxX;
    Vector3 stageBounds;
    public float initStepSize = -10f;
    public float stepSize = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bounds spriteBounds =GetComponent<SpriteRenderer>().sprite.bounds;
        //stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

        GameObject discoBar = GameObject.Find("DiscoButtonsBar");
        minX = discoBar.transform.position.x - discoBar.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        maxX = discoBar.transform.position.x + discoBar.GetComponent<SpriteRenderer>().bounds.size.x / 2;

        Debug.Log("MinX: " + minX + ", MaxX: " + maxX);

        initArrow();
    }

    public void initArrow() {
        if(arrow != null) {
            Destroy(arrow);
        }
        
        int nextArrowIndex = RandomNumberGenerator.GetInt32(arrowAssets.Length);
        arrow = Instantiate(arrowAssets[nextArrowIndex]);
        arrow.transform.SetParent(this.transform);
        hittingKeyCode = getKeyCodeByArrow(nextArrowIndex);
        arrow.transform.position = transform.position;
        
        Vector2 spriteSize = GetComponent<SpriteRenderer>().size;
        float scale = spriteSize.x / arrow.GetComponent<SpriteRenderer>().size.x;
        arrow.transform.localScale *= scale;
    }

    static KeyCode getKeyCodeByArrow(int arrowIndex) {
        return arrowIndex switch {
            2 => KeyCode.RightArrow,
            3 => KeyCode.DownArrow,
            0 => KeyCode.LeftArrow,
            1 => KeyCode.UpArrow,
            _ => KeyCode.Escape
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(ScrollingText.instance.isActive()) return;
        if(Globals.freezeAll) return;

        float x = transform.position.x;
        //float xMin = -stageBounds.x;
        //float xMax = stageBounds.x;
        if(x <= minX) {
            initArrow();
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if(x >= maxX) {
            initArrow();
            transform.position = new Vector2(minX, transform.position.y);
        }
        transform.position += new Vector3(stepSize, 0, 0) * Time.deltaTime;
        arrow.transform.position = transform.position;
    }
}

using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class DiscoButton : MonoBehaviour
{

    public GameObject[] arrowAssets;
    public GameObject arrow;
    public KeyCode hittingKeyCode;

    Vector3 stageBounds;
    public float stepSize = -5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bounds spriteBounds =GetComponent<SpriteRenderer>().sprite.bounds;
        stageBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));

        initArrow();
    }

    void initArrow() {
        if(arrow!= null) {
            Destroy(arrow);
        }
        int nextArrowIndex = RandomNumberGenerator.GetInt32(arrowAssets.Length);
        arrow = Instantiate(arrowAssets[nextArrowIndex]);
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
        float x = transform.position.x;
        float xMin = -stageBounds.x;
        float xMax = stageBounds.x;
        if(x <= xMin) {
            initArrow();
            transform.position = new Vector2(xMax, transform.position.y);
        }
        if(x >= xMax) {
            initArrow();
            transform.position = new Vector2(xMin, transform.position.y);
        }
        transform.position += new Vector3(stepSize, 0, 0) * Time.deltaTime;
        arrow.transform.position = transform.position;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Background : MonoBehaviour
{
    public Sprite[] backgrounds;
    int currentBackground = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("b"))
        {
            currentBackground++;
            if(currentBackground >= backgrounds.Length)
                currentBackground = 0;
            SetBackground(currentBackground);
            
        }
    }

    void SetBackground(int i)
    {
        GetComponent<SpriteRenderer>().sprite = backgrounds[i];
        ScaleSpriteToScreen();
    }

    void ScaleSpriteToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject.");
            return;
        }

        // Get the size of the sprite
        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        // Get the world screen height and width
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Calculate the scale needed to fit the screen
        Vector3 scale = transform.localScale;
        scale.x = worldScreenWidth / width;
        scale.y = worldScreenHeight / height;

        // Apply the scale to the transform
        transform.localScale = scale;
    }

}


using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleSpriteToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

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


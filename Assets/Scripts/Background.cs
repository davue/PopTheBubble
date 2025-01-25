using UnityEngine;

public class Background : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        ScaleSpriteToScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScaleSpriteToScreen()
    {
        // Get the size of the sprite
        float width = spriteRenderer.bounds.size.x;
        float height = spriteRenderer.bounds.size.y;

        // Get the world screen height and width
        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Calculate the scale needed to fit the screen
        Vector3 scale = spriteRenderer.gameObject.transform.localScale;
        scale.x = worldScreenWidth / width;
        scale.y = worldScreenHeight / height;

        // Apply the scale to the transform
        spriteRenderer.gameObject.transform.localScale = scale;
    }
}


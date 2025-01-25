using UnityEngine;

public class flee : MonoBehaviour
{

    float dontTouchMeIMScared = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector2 center = transform.position;
        Vector2 mouse2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float rad = sr.sprite.bounds.size.x;
        float dist = Vector2.Distance(mouse2, center);
        if(dist < dontTouchMeIMScared + rad) {
            Vector3 mouse3 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0,0,Camera.main.transform.position.z);
            Vector3 closestPoint = sr.sprite.bounds.ClosestPoint(mouse3);
            Vector3 translation = closestPoint - mouse3;
            transform.position += translation;
        }
        
    }
}

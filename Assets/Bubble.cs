using UnityEngine;

public class Bubble : MonoBehaviour
{
    public ParticleSystem ps;
    private bool _isPopped;
    private SpriteRenderer renderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponentInChildren<ParticleSystem>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Pop()
    {
        if (!_isPopped)
        {
            _isPopped = true;
        
            // Play pop animation particle effect
            ps.Play();
        
            // Hide bubble
            renderer.enabled = false;
        }
    }

    public void UnPop()
    {
        if (_isPopped)
        {
            // Show bubble
            renderer.enabled = true;
        
            _isPopped = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown("p") && !_isPopped)
        // {
        //     Pop();
        // }
        //
        // if(Input.GetKeyDown("r") && _isPopped)
        // {
        //     UnPop();
        // }
    }
}

using UnityEngine;

public class DiscoBackground : Background
{

    public override string InitialMessage()
    {
        return "Welcome to the Disco! I love dancing, but don't go too fast or I could pop!";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

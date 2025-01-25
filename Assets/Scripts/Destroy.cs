using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float time = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Destroy(gameObject);
        }
    }
}

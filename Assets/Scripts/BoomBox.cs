using System.Collections;
using UnityEngine;

public class BoomBox : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule _emissionModule;
    private ParticleSystem.MainModule _mainModule;

    public Disco disco;

    public float burstMultiplier = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _emissionModule = particleSystem.emission;
        _emissionModule.rateOverTime = 0f;
        
        _mainModule = particleSystem.main;
        _mainModule.startSpeed = 5f;
    }

    public void Burst(int intensity)
    {
        StartCoroutine(internalBurst(intensity));
    }

    public void TestBurst()
    {
        StartCoroutine(internalBurst(100)); 
    }

    public void Burst()
    {
        if(Globals.freezeAll) return;
        StartCoroutine(internalBurst((int)(Globals.volumePercentage * burstMultiplier)));
        
        if(Globals.volumePercentage > 101)
        {
            Bubble.instance.Pop(Bubble.PopType.DANCE);
            disco.musicSource.Stop();
        }
        else if(Globals.volumePercentage > 50)
        {
            ScrollingText.instance.AddText("Oh wow, thats unconfortably loud! Can you keep it a little bit quieter please? I am a sensitive bubble after all.");
            ScrollingText.instance.ActivateNextText();
        }
        else
        {
            ScrollingText.instance.AddText("Wuhu, bubble shower!");
            ScrollingText.instance.ActivateNextText();
        }
    }

    private IEnumerator internalBurst(int intensity)
    {
        _emissionModule.rateOverTime = intensity * 10;
        _mainModule.startSpeed = intensity * 3;
        yield return new WaitForSeconds(0.1f);
        _emissionModule.rateOverTime = 0;
        _mainModule.startSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
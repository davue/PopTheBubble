using System.Collections;
using UnityEngine;

public class BoomBox : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    private ParticleSystem.EmissionModule _emissionModule;
    private ParticleSystem.MainModule _mainModule;

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

    private IEnumerator internalBurst(int intensity)
    {
        _emissionModule.rateOverTime = intensity * 10;
        _mainModule.startSpeed = intensity * 5;
        yield return new WaitForSeconds(0.1f);
        _emissionModule.rateOverTime = 0;
        _mainModule.startSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
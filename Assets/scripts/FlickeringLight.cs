using UnityEngine;
using Random = UnityEngine.Random;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity = 1000f;
    [SerializeField] private float timeBetweenIntensity = 0.1f;
    
    private float _currentTimer;

    private void Update()
    {
        _currentTimer += Time.deltaTime;
        if (!(_currentTimer >= timeBetweenIntensity)) return;
        light.intensity = Random.Range(minIntensity, maxIntensity);
        _currentTimer = 0f;
    }
}

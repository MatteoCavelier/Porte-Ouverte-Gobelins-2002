using UnityEngine;
using Random = UnityEngine.Random;

public class FlickeringLightTrigger : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity = 1000f;
    [SerializeField] private float timeBetweenIntensity = 0.1f;
    
    private float _currentTimer;
    private bool _canChangeIntensity;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) _canChangeIntensity = true;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            light.intensity = maxIntensity;
            _canChangeIntensity = false;
        }
    }

    private void Update()
    {
        if (!_canChangeIntensity) return;
        _currentTimer += Time.deltaTime;
        if (!(_currentTimer >= timeBetweenIntensity)) return;
        light.intensity = Random.Range(minIntensity, maxIntensity);
        _currentTimer = 0f;
    }
}

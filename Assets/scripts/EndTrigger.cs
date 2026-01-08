using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    
    [SerializeField] private GameObject globalLight;
    [SerializeField] private AudioSource levelMusic;
    
    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            globalLight.SetActive(true);
            levelMusic.Stop();
        }
    }
}

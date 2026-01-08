using UnityEngine;

public class TriggerLight : MonoBehaviour
{
    
    [SerializeField] private GameObject lightGroup;
    
    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Player"))
        {
            lightGroup.SetActive(true);
        }
    }
}

using UnityEngine;

public class TriggerToLowerTheLight : MonoBehaviour
{
    
    [SerializeField] private Light globalLight;
    
    void OnTriggerEnter(Collider other)
    {
        globalLight.color = Color.black;
    }
    
    void OnTriggerExit(Collider other)
    {
        globalLight.color = Color.white;
    }
}

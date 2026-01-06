using UnityEngine;

public class Teleporter : MonoBehaviour
{
    
    [SerializeField] private GameObject spawnPoint;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = spawnPoint.transform.position;
    }
}
